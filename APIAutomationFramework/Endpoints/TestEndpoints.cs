using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFramework.Endpoints
{
    public class TestEndpoints
    {
        public static string userList(int pageNumber)
        {
            return "api/users?page=" + pageNumber;
        }
    }
}
