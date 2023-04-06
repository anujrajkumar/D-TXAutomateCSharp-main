using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.POJOs
{
    public class TestDataInstances
    {
        public string TestData { get; set; }
        public string SheetName { get; set; }

        public static List<string> TestDataList = new List<string>();
        public static List<string> SheetNameList = new List<string>();
    }
}
