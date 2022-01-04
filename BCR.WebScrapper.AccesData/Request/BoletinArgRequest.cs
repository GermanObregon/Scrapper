using BCR.WebScrapper.AccesData.Request.Interfaces;
using BCR.WebScrapper.Aplication;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCR.WebScrapper.AccesData.Request
{
    public class BoletinArgRequest : IBoletinArgRequest
    {
        private readonly IRuntimeProvider Provider;
        public BoletinArgRequest(IRuntimeProvider provider)
        {
            this.Provider = provider;
        }
        public List<string> GetAllCompanies()
        {
            try
            {
                List<string> companies = new List<string>();
                dynamic script = Provider.GetRuntimePython("C:/Users/german.obregon/source/repos/BCR.ScrapperWeb/BCR.WebScrapper.AccesData/Scripts/BoletinesOficiales/BoletinArg.py");
                var boletin = script.BoletinBot();
                boletin.get_url();
                boletin.scroll_page();
                var lst = boletin.empresas_report();
                boletin.close_page();

                foreach (string item in lst)
                {
                    companies.Add(item);
                }
                return companies;
            }
            catch (Exception e)
            {

                throw e;
            }
           

            

        }
    }
}
