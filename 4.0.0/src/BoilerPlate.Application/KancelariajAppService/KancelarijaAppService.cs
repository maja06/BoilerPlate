using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Abp.Domain.Repositories;
using Abp.UI;
using BoilerPlate.KancelariajAppService.Dto;
using BoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate.KancelariajAppService
{
    public class KancelarijaAppService : BoilerPlateAppServiceBase, IKancelarijaAppService
    {

        private readonly IRepository<Kancelarija> _kancelarijaRepository;

        public KancelarijaAppService(IRepository<Kancelarija> kancelarijaRepository)
        {
            _kancelarijaRepository = kancelarijaRepository;
        }

        public KancelarijaGetDto GetKancelarija(long id)
        {
            var all = _kancelarijaRepository.GetAll().Include(p => p.ListaOsobe);
            var kancelarija = all.FirstOrDefault(x => x.Id == id);
            if (kancelarija == null)
            {
                throw new Exception("Office Not Found");
            }

            return ObjectMapper.Map<KancelarijaGetDto>(kancelarija);
        }

        public List<KancelarijaDto> Get()
        {
            var kancelarija = _kancelarijaRepository.GetAll();
            return new List<KancelarijaDto>(ObjectMapper.Map<List<KancelarijaDto>>(kancelarija));
        }

        public KancelarijaDto GetById(long id)
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

        public void Update(long id, KancelarijaPutDto input)
        {
            _kancelarijaRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(long id)
        {
            _kancelarijaRepository.Delete(id);
        }
    }

}
}
