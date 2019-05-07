﻿using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using BoilerPlate.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace BoilerPlate.OsobaAppService.Dto
{
    public class OsobaAppService : BoilerPlateAppServiceBase, IOsobaAppService
    {
        private readonly IRepository<Osoba> _osobaRepository;

        public OsobaAppService(IRepository<Osoba> osobaRepository)
        {
            _osobaRepository = osobaRepository;
        }

        public List<OsobaGetDto> Get()
        {
            var osoba = _osobaRepository.GetAll();

            if (osoba == null)
            {
                throw new Exception("Kancelariaj nije nadjena");
            }

            return new List<OsobaGetDto>(ObjectMapper.Map<List<OsobaGetDto>>(osoba));

        }

        public OsobaGetDto GetById(long id)
        {
            Osoba osoba;

            try
            {

            }
            catch (Exception)
            {
                throw new Exception("Id nije nadjen");
            }

            return ObjectMapper.Map<OsobaGetDto>(osoba);
        }

        public Osoba GetOsoba(long id)
        {
            var osoba = _osobaRepository.FirstOrDefault(x => x.OsobaId == id);

            if (osoba == null)
            {
                throw new Exception("Id Not Found");
            }

            return osoba;
        }

        public void Insert(OsobaPostDto input)
        {
            var kancelarija = ObjectMapper.Map<Osoba>(input);
            _osobaRepository.Insert(kancelarija);
        }


        public void Update(long id, OsobaPutDto input)
        {
            _osobaRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(long id)
        {
            _osobaRepository.Delete(id);
        }

     

      
        

       
    }



}
}