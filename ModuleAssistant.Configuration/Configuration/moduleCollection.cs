using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAssistant.Configuration.Configuration
{
    public class ModuleCollection : ConfigurationElementCollection
    {
        private IDictionary<string, string> modules;

        protected override ConfigurationElement CreateNewElement()
        {
            return new Module();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            Module module = element as Module;
            return module.moduleName;
        }

        protected override string ElementName
        {
            get
            {
                return base.ElementName;
            }
        }

        public IDictionary<string, string> Modules
        {
            get
            {
                if (modules == null)
                {
                    modules = new Dictionary<string, string>();
                    foreach (Module item in this)
                    {
                        modules.Add(item.moduleName, item.assemblyFile);
                    }
                }
                return modules;
            }
        }

        public string this[string moduleName]
        {
            get
            {
                string assembly = string.Empty;
                if (modules.TryGetValue(moduleName, out assembly))
                {
                    return assembly;
                }
                else
                {
                    throw new ArgumentException("没有对'" + moduleName + "'节点进行配置。");
                }
            }
        }
    }
}
