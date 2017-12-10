using System;
using System.Reflection;

namespace Engine
{
    public class RessourceReader
    {
        public RessourceReader()
        {
            
        }
        
        private void read()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var name = new AssemblyName(args.Name) + ".dll";
                var ressource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(),
                    element => element.EndsWith(name));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ressource))
                {
                    if (stream == null) return null;
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    return Assembly.Load(data);
                }
            };
        }
    }
}