using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAssistant.Configuration.Configuration
{
    public class SystemModules : ConfigurationSection
    {
        [ConfigurationProperty("modules", IsRequired = true)]
        public ModuleCollection modules
        {
            get { return (ModuleCollection)base["modules"]; }
        }
    }
}
