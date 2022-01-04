using BCR.ScrepperWeb.Service.Services.Interfaces;
using BCR.WebScrapper.AccesData.Request.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCR.ScrepperWeb.Service.Services
{
    public class BoletinStaFeService : IBoletinStaFeService
    {
        private readonly IBoletinStaFeRequest BoletinStaFeRequest;

        public BoletinStaFeService(IBoletinStaFeRequest boletinStaFeRequest)
        {
            this.BoletinStaFeRequest = boletinStaFeRequest;
        }
        public List<string> GetAllCompanies()
        {
            try
            {
                return this.BoletinStaFeRequest.GetAllCompanies();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
