using ModuleAssistant.Configuration.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAssistant.Configuration
{
    public class LoadSystemModules
    {
        public static AggregateCatalog LoadModule(string assemblypath)
        {
            if (string.IsNullOrEmpty(assemblypath))
            {
                throw new ArgumentException("DLL路径不能为Empty！");
            }
            AggregateCatalog catalog = new AggregateCatalog();

            SystemModules softSettings = ConfigurationManager.GetSection("SystemModules") as SystemModules;
            ICollection<string> keys = softSettings.modules.Modules.Keys;

            if (keys == null || keys.Count == 0)
            {
                throw new IndexOutOfRangeException("没有配置Module模块！");
            }

            foreach (var item in keys)
            {
                if (!File.Exists(Path.Combine(assemblypath, softSettings.modules[item])))
                {
                    throw new FileNotFoundException("{0}丢失！");
                }
                catalog.Catalogs.Add(new DirectoryCatalog(assemblypath, softSettings.modules[item]));
            }

            return catalog;
        }
    }
}
