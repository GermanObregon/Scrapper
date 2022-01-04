using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCR.WebScrapper.Aplication
{
    public interface IRuntimeProvider
    {
        dynamic GetRuntimePython(string path);
    }
}
