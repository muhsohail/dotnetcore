using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        //private readonly ApplicationDbContext _dbContext;
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;

        }

        // A binding source attribute defines the location at which an action parameter's value is found. 
        // The following binding source attributes exist:
        //https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2

        // Post api/city
        [HttpPost]
        public ActionResult<int> Add([FromBody] City city)
        {
            return _cityService.AddCity(city);
        }

        // Put api/city
        [HttpPut("{Id}")]
        public ActionResult<int> PutCityItem(Guid Id, City city)
        {
            return _cityService.UpdateCity(city);
        }

        // Delete api/city
        [HttpDelete("{Id}")]
        public ActionResult<int> DeleteCityItem(Guid Id)
        {
            return _cityService.DeleteCity(Id);
        }

        // GET api/city
        [HttpGet]
        public ActionResult<List<City>> GetCities()
        {
            return _cityService.GetAll();
        }

        // GET api/city/Id
        [HttpGet("GetCityById/{Id}")]
        public ActionResult<City> GetCityById(Guid Id)
        {
            return _cityService.GetCityById(Id);
        }

        [HttpGet("GetInactiveCities")]
        public ActionResult<List<City>> GetInactiveCities()
        {
            return _cityService.GetAll();
        }
        // GET api/city
        [HttpGet("GetRegionNo/{CityId}")]
        public ActionResult<List<City>> GetRegionNo()
        {
            return _cityService.GetAll();
        }
    }
}