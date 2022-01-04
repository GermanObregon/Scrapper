using BCR.ScrepperWeb.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.WebScrapper.WebApi.Controllers
{
    [ApiController]
    [Route("api/boletinesStaFe")]
    public class BoletinStaFeController : ControllerBase
    {
        private readonly IBoletinStaFeService Service;

        public BoletinStaFeController(IBoletinStaFeService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public ActionResult GetCompanies()
        {
            try
            {
                return new JsonResult(Service.GetAllCompanies()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
        
    
}
