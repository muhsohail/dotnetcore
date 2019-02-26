using System;
using System.Collections.Generic;
using System.Linq;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;

        }

        public int AddCity(City city)
        {
            _context.Add(city);
            return _context.SaveChanges();
        }

        public int DeleteCity(Guid CityId)
        {
            int result = 0;
            City city = _context.City.Find(CityId);

            if (city != null)
            {
                city.IsActive = false;
                //_context.City.Remove(City);
                result = _context.SaveChanges();
            }

            return result;
        }

        public List<City> GetAll()
        {
            return _context.City.ToList();
        }

        public City GetCityById(Guid Id)
        {
            return _context.City.Where(x => x.Id == Id).FirstOrDefault();
        }

        public string GetCityCode(Guid cityId)
        {
            return _context.City.Include(x => x.Region)
                .FirstOrDefault(x => x.Id == cityId).Code;
        }

        public int GetRegionNo(Guid cityId)
        {
           return  _context.City.Include(x => x.Region)
                           .FirstOrDefault(x => x.Id == cityId).Region.RegionNo;
        }

        public int UpdateCity(City city)
        {
            city.IsActive = true;
            _context.Attach(city).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
