using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.BufferUtil
{
    public class BufferUtilSuiteLevel
    {
        public static string? scenarioName;
        public static string? extentReportPath;
        public static string? screenshotPath;
        public static Exception? exception = null;

        public static List<Dictionary<string, string>>? keyValuePairsForLoginSheet = new List<Dictionary<string, string>>();
    }
}
