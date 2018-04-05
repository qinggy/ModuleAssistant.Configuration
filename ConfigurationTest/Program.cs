using ModuleAssistant.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadSystemModules.LoadModule(@"C:\Program Files");
        }
    }
}
