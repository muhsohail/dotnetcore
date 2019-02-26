using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.Services.Interface
{
    public interface ICityService
    {
        int GetRegionNo(Guid cityId);
        string GetCityCode(Guid cityId);
        int AddCity(City city);
        int UpdateCity(City city);
        int DeleteCity(Guid CityId);
        List<City> GetAll();
        City GetCityById(Guid Id);
    }
}
