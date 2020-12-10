using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public static class Config
    {
        //this should load the configs from app.config
        public static string FilesPath { get; set; } = "D:\\Test";
        public static string FilesContainingStringPath { get; set; } = "D:\\Test\\Containing";
        public static string FilesNotContainingStringPath { get; set; } = "D:\\Test\\NotContaining";
        public static string FilesWithErrorsPath { get; set; } = "D:\\Test\\Errors";

        public static int Interval = 30000;
        public static string SearchString = "CCjeuAhJNc4yxBfeMbbYX1U1Tn";
    }
}
