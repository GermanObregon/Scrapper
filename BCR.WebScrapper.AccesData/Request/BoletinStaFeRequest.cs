using BCR.WebScrapper.AccesData.Request.Interfaces;
using BCR.WebScrapper.Aplication;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BCR.WebScrapper.AccesData.Request
{
    public class BoletinStaFeRequest : IBoletinStaFeRequest
    {
        //private readonly IRuntimeProvider Provider;
        //public BoletinStaFeRequest(IRuntimeProvider provider)
        //{
        //    this.Provider = provider;
        //}
        private  RemoteWebDriver Driver;
        public BoletinStaFeRequest()
        {
            var options = new ChromeOptions();
            this.Driver = new RemoteWebDriver(new Uri("http://172.17.02:4444/wd/hub") , options);


        }
        public List<string> GetAllCompanies()
        {
            try
            {
                List<string> companies = new List<string>();
                GetUrl();
                IEnumerable<IWebElement> elementos = Driver.FindElements(By.XPath("//b"));
                //dynamic script = Provider.GetRuntimePython("C:/Users/german.obregon/source/repos/BCR.ScrapperWeb/BCR.WebScrapper.AccesData/Scripts/BoletinesOficiales/BoletinStaFe.py");
                //var bulletin = script.BoletinBot();
                //bulletin.get_url();
                //var lst = bulletin.empresas_report();
                //bulletin.close_page();
                ClosePage();
                foreach (IWebElement item in elementos)
                {
                    companies.Add(item.Text);
                }
                return companies;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        private void GetUrl()
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string año = DateTime.Now.ToString("yyyy");
            Driver.Url = "https://www.santafe.gov.ar/boletinoficial/ver.php?seccion=" + año + "/" + fecha + "contratos.html";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            Driver.Manage().Window.Maximize();
        }

        private void ClosePage()
        {
            Driver.Close();
        }
    }
}
