using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Abp.Domain.Repositories;
using Abp.UI;
using BoilerPlate.KancelariajAppService;
using BoilerPlate.KancelariajAppService.Dto;
using BoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate.KancelarijaAppService
{
    public class KancelarijaAppService : BoilerPlateAppServiceBase, IKancelarijaAppService
    {

        private readonly IRepository<Kancelarija> _kancelarijaRepository;

        public KancelarijaAppService(IRepository<Kancelarija> kancelarijaRepository)
        {
            _kancelarijaRepository = kancelarijaRepository;
        }

        KancelarijaGetDto IKancelarijaAppService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public KancelarijaGetDto GetKancelarija(int id)
        {
            var all = _kancelarijaRepository.GetAll().Include(p => p.ListaOsobe);
            var kancelarija = all.FirstOrDefault(x => x.Id == id);
            if (kancelarija == null)
            {
                throw new Exception("Office Not Found");
            }

            return ObjectMapper.Map<KancelarijaGetDto>(kancelarija);
        }

        public void Insert(KancelarijaGetDto input)
        {
            throw new NotImplementedException();
        }

        public List<KancelarijaDto> Get()
        {
            var kancelarija = _kancelarijaRepository.GetAll();
            return new List<KancelarijaDto>(ObjectMapper.Map<List<KancelarijaDto>>(kancelarija));
        }


        List<KancelarijaGetDto> IKancelarijaAppService.Get()
        {
            throw new NotImplementedException();
        }

        public KancelarijaDto GetById(int id)
        {
            Kancelarija kancelarija;
            try
            {
                kancelarija = _kancelarijaRepository.Get(id);
            }
            catch (Exception)
            {
                throw new UserFriendlyException("ID Not Found");
            }
            return ObjectMapper.Map<KancelarijaDto>(kancelarija);
        }


        public void Insert(KancelarijaDto input)
        {
            var kancelarija = ObjectMapper.Map<Kancelarija>(input);
            _kancelarijaRepository.Insert(kancelarija);
        }


        public void Update(int id, KancelarijaPutDto input)
        {
            _kancelarijaRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(int id)
        {
            _kancelarijaRepository.Delete(id);
        }
    }

}

