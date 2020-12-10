using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace FileProcessor
{
    public partial class FileProcessorService : ServiceBase
    {
        EventLog EventLog1;
        Timer Timer = new Timer();
        Repository Repository;

        public FileProcessorService()
        {
            InitializeComponent();
            EventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("FileProcessor"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "FileProcessor", "FileProcessor");
            }
            EventLog1.Source = "FileProcessor";
            EventLog1.Log = "FileProcessor";
        }

        protected override void OnStart(string[] args)
        {
            Repository = new Repository(new SqlConnection());
            Timer.Enabled = true;
            Timer.Interval = Config.Interval;
            Timer.Elapsed += ProcessFiles;
            EventLog1.WriteEntry("In OnStart.");
            
        }

        private void ProcessFiles(object sender, ElapsedEventArgs e)
        {
            var filesPath = Directory.GetFiles(Config.FilesPath);
            Parallel.ForEach(filesPath, file => ProcessFile(file));
        }

        private void ProcessFile(string filePath)
        {
            Repository.UpdateFileStatus(filePath, FileStatus.StartedProcessing);
            var filename = Path.GetFileName(filePath);
            try
            {
                var fileContent = File.ReadAllLines(filePath);
                
                if (fileContent.Contains(Config.SearchString))
                {
                    File.Move(filePath, Config.FilesContainingStringPath + filename + DateTime.Now.ToString("o"));
                }
                else
                {
                    File.Move(filePath, Config.FilesNotContainingStringPath + filename + DateTime.Now.ToString("o"));
                }
                Repository.UpdateFileStatus(filePath, FileStatus.FinnishedProcessing);

            }
            catch (Exception ex)
            {                
                File.Move(filePath, Config.FilesWithErrorsPath + filename + DateTime.Now.ToString("o"));
                Repository.UpdateFileStatus(filePath, FileStatus.Error);
                EventLog1.WriteEntry("Error processing file " + filePath);
            }            
        }

        protected override void OnStop()
        {
            EventLog1.WriteEntry("In OnStop.");
            Repository.Dispose();
        }
    }
}
