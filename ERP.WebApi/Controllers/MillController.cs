using System.Collections.Generic;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MillController : ControllerBase
    {
        private readonly IMillService _millService;

        public MillController(IMillService millService)
        {
            _millService = millService;

        }

        [HttpGet]
        public ActionResult<List<Mill>> GetAllMills()
        {
            return _millService.GetAllMills();
        }


        [HttpGet("GetMillByCode/{millCode}")]
        public ActionResult<Mill> GetMillByCode(string millCode)
        {
            return _millService.GetMillByCode(millCode);
        }
        
    }
}