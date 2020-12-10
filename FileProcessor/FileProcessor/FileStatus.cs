using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public enum FileStatus
    {
        FoundOnDisk,
        StartedProcessing,
        Error,
        FinnishedProcessing
    }
}
