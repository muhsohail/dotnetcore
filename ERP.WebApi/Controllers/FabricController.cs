using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricController : ControllerBase
    {
        private readonly IFabricService _fabricService;

        public FabricController(IFabricService fabricService)
        {
            _fabricService = fabricService;

        }


        [HttpGet("GetFabricDescription/{fabricId}")]
        public ActionResult<string> GetFabricDescription(Guid fabricId)
        {
            return _fabricService.GetFabricDescription(fabricId);
        }
    }
}