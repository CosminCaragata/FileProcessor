using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class Repository : IDisposable
    {
        public Repository(SqlConnection sqlConnection)
        {
            //set sqlconnection
        }

        public void AddNewFiles(List<string> files)
        {
            foreach (var file in files)
            {
                var sqlInsert = @"inset into Files values (file, FileStatus.FoundOnDisk, DateTime.Now(""o"")";

            }
        }

        public void Dispose()
        {
            //close connection
        }

        public void UpdateFileStatus(string fileName,FileStatus fileStatus)
        {
            var sqlUpdate = $@"update Files
                              set status = {fileStatus}
                              where file_name = {fileName}";            
        }
    }
}
