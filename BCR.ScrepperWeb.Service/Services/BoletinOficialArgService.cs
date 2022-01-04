using BCR.ScrepperWeb.Service.Services.Interfaces;
using BCR.WebScrapper.AccesData.Request.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCR.ScrepperWeb.Service.Services
{
    public class BoletinOficialArgService : IBoletinOficialArgService
    {
        private readonly IBoletinArgRequest BoltinArgRequest;

        public BoletinOficialArgService(IBoletinArgRequest boltinArgRequest)
        {
            this.BoltinArgRequest = boltinArgRequest;
        }
        public List<string> GetAllCompanies()
        {
            try
            {
                return this.BoltinArgRequest.GetAllCompanies();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
