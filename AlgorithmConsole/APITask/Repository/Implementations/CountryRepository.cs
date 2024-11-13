using APITask.Models.DTOs;
using APITask.Models.Entites;
using AutoMapper;
using System.Collections.Generic;
using System;
using APITask.Repository.Interfaces;
using APITask.Data;
using Microsoft.EntityFrameworkCore;

namespace APITask.Repository.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApiContext _context;
        private readonly DbSet<Country> _dbSet;
        private readonly IMapper _mapper;

        public CountryRepository(ApiContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Country>();
            _mapper = mapper;
        }
        public async Task<Response> GetCountryByNumber(string number)
        {
            var response = new Response();
            var countryIso = new List<char>();
            for (var i = 0; i < number.Length; i++)
            {
                if (i == 3)
                {
                    break;
                }
                countryIso.Add(number[i]);
                continue;
            }

            var countryIsoToString = new string(countryIso.ToArray());
            var country = await _dbSet.Where(c => c.CountryCode == countryIsoToString)
                .Include(c => c.CountryDetails)
                .FirstOrDefaultAsync();
            if (country == null)
            {
                response.Number = number;
                response.Country = null;
                return response;
            }

            var countryDto = _mapper.Map<CountryDTO>(country);
            response.Number = number;
            response.Country = countryDto;
            return response;
        }
    }
}
