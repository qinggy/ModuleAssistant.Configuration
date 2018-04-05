using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAssistant.Configuration.Configuration
{
    public class Module : ConfigurationElement
    {
        [ConfigurationProperty("assemblyFile", IsRequired = true)]
        public string assemblyFile 
        {
            get { return (string)base["assemblyFile"]; }
            set { base["assemblyFile"] = value; }
        }

        [ConfigurationProperty("moduleName", IsRequired = true)]
        public string moduleName 
        {
            get { return (string)base["moduleName"]; }
            set { base["moduleName"] = value; }
        }
    }
}
