using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFramework.Endpoints
{
    public class JIRAEndpoints
    {
        public static string createIssueURI()
        {
            return "/rest/api/2/issue";
        }

        public static string attachImageToIssueURI(string issueId)
        {
            return "/rest/api/2/issue/" + issueId + "/attachments";
        }
    }
}
