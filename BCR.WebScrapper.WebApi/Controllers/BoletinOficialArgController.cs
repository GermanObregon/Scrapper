using BCR.ScrepperWeb.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.WebScrapper.WebApi.Controllers
{
    [ApiController]
    [Route("api/boletinesArg")]
    public class BoletinOficialArgController : ControllerBase
    {
        private readonly IBoletinOficialArgService Service;
        public BoletinOficialArgController(IBoletinOficialArgService service)
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
