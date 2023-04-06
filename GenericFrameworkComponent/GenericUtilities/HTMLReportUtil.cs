using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class HTMLReportUtil
    {

        static string? html;

        public static string failStringRedColor(string log)
        {
            html = "<span style='color:red'>" + log + "</span>";
            return html;
        }

        public static string failStringRedColor(String stepName, string status)
        {
            html = "<span style='color:red'>" + status.ToUpper() + " - " + stepName + "</span>";
            return html;
        }

        public static string passStringGreenColor(String stepName)
        {
            html = "<span style='color:#008000'>" + "PASSED - " + stepName + "</span>";
            return html;
        }

        public static String infoStringBlueColor(String stepName, string status)
        {
            html = "<span style='color:#41B2DB'>" + status.ToUpper() + " - " + stepName + "</span>";
            return html;
        }

        public static String warningStringOrangeColor(String stepName, string status)
        {
            html = "<span style='color:#FF8D42'>" + status.ToUpper() + " - " + stepName + "</span>";
            return html;
        }

        public static String showBase64Image(string base64string)
        {
            html = "<a href=\"" + base64string + "\" data-featherlight=\"image\"> <img class=\"report - img\" src = \"" + base64string + "\" alt=\"Failure Screenshot\" width=\"400\" height=\"200\"></a>";
            return html;
        }
    }
}
