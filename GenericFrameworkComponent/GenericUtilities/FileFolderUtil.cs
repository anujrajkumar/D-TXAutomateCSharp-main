using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class FileFolderUtil
    {
        public static string projectFolderPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;
        public static string projectBinFolderPath = Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName;

        public static void createFolderIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                LogUtil.infoLog("Directory with path: " + path + " created.");
            }
            else
            {
                LogUtil.infoLog("Directory with path: " + path + " already exists.");
            }
        }

        public static void moveFileFromOneToAnotherFolder(string sourceWithFileName, string destinationWithFileName)
        {
            File.Move(sourceWithFileName, destinationWithFileName);
        }

        public static void copyFileFromOneToAnotherFolder(string sourceWithFileName, string destinationWithFileName, bool overwriteFlag)
        {
            File.Copy(sourceWithFileName, destinationWithFileName, overwriteFlag);
        }

        public static void deleteFile(string sourceWithFileName)
        {
            File.Delete(sourceWithFileName);
        }

        public static string GetTestDataExcelPath()
        {
            return projectFolderPath + CommonConstants.testDataExcelPath;
        }

        public static string GetAutomationControlSheetExcelPath()
        {
            return projectFolderPath + CommonConstants.automationControlSheetExcelPath;
        }

        public static string reportFolderCompletePath()
        {
            return projectFolderPath + CommonConstants.reportFolderName;
        }

        public static string extentReportFolderCompletePath()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.extentReportFolderName + "\\";
        }

        public static string screenshotFolderCompletePath()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.screenshotFolderName + "\\";
        }

        public static string logFolderCompletePath()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.logFolderName + "\\";
        }

        public static string extentReportConfigFileCompletePath()
        {
            return projectFolderPath + CommonConstants.extentReportConfigPath;
        }

        public static string extentReportDefaultFileName()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.extentReportDefaultFile;
        }

        public static string extentReportUpdatedFileName()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.extentReportFolderName + "\\" + CommonConstants.extentReportFileName;
        }

        public static string logDefaultFileName()
        {
            return projectBinFolderPath + CommonConstants.logFilePath;
        }

        public static string logUpdatedFileName()
        {
            return projectFolderPath + CommonConstants.reportFolderName + CommonConstants.logFolderName + "\\" + CommonConstants.logFileName;
        }

        public static string log4netConfigFileCompletePath()
        {
            return projectFolderPath + CommonConstants.log4netConfigPath;
        }

        public static string JSONFolderPath()
        {
            return projectFolderPath + CommonConstants.JSONfilePath;
        }

        public static string JSONFilePath(string JSONfileName)
        {
            return JSONFolderPath() + JSONfileName + ".json";
        }
    }
}
