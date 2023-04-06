using GenericFrameworkComponent.UIFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.Modules
{
    public class CommonModule
    {
        public static void navigateToURL(string URL)
        {
            WebDriverUtils.GetURL(URL);
        }
    }
}
