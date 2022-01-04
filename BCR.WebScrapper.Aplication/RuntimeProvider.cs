using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace BCR.WebScrapper.Aplication
{
    public class RuntimeProvider : IRuntimeProvider
    {
        public dynamic GetRuntimePython(string path)
        {
            string pyPath = @$"{path}";
            ScriptRuntime py = Python.CreateRuntime();
            var pyEngine = py.GetEngine("python");
            var searchPaths = pyEngine.GetSearchPaths();
            searchPaths.Add(@"C:/Users/german.obregon/source/repos/BCR.ScrapperWeb/BCR.WebScrapper.AccesData/Scripts/BoletinesOficiales");
            searchPaths.Add(@"C:/Python27/Lib");
            searchPaths.Add(@"C:/Python27/Lib/site-packages");
            pyEngine.SetSearchPaths(searchPaths);

            dynamic pyProgram = py.UseFile(pyPath);

            return pyProgram;
        }
    }
}
