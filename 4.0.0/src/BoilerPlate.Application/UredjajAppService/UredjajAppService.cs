using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.UredjajAppService.Dto;

namespace BoilerPlate.UredjajAppService
{
    public class UredjajAppService : BoilerPlateAppServiceBase, IUredjajAppService
    {
        private readonly IRepository<Uredjaj> _uredjajRepository;

        public UredjajAppService(IRepository<Uredjaj> uredjajRepository)
        {
            _uredjajRepository = uredjajRepository;
        }

        public List<UredjajGetDto> Get()
        {
            var sviUredaji = _uredjajRepository.GetAll();
            return new List<UredjajGetDto>(ObjectMapper.Map<List<UredjajGetDto>>(sviUredaji));
        }

        public UredjajGetDto GetById(int id)
        {
            Uredjaj uredjaj;

            try
            {
                uredjaj = _uredjajRepository.Get(id);
            }
            catch (Exception)

            {
                throw new Exception("Id nije nadjen");
            }

            return ObjectMapper.Map<UredjajGetDto>(uredjaj);
        }

        public int Insert(UredjajPostDto input)
        {
            var uredjaj = ObjectMapper.Map<Uredjaj>(input);
            var inserted = _uredjajRepository.InsertAndGetId(uredjaj);
            return inserted;
        }


        public Uredjaj GetUredjaj(int id)
        {
            var all = _uredjajRepository.GetAll();
            var uredjaj = all.FirstOrDefault(x => x.Id == id);

            if (uredjaj == null)
            {
                throw new Exception("Id Not Found");

            }

            return uredjaj;
        }

        public void Update(int id, UredjajPutDto input)
        {
            _uredjajRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(int id)
        {
            _uredjajRepository.Delete(id);
        }

        public void IzmijeniKorisnika(int oId, int uId)
        {
            var foundUredjaj = _uredjajRepository.Get(uId);

            if (foundUredjaj == null)
            {
                throw new Exception("Uredjaj ne postoji");
            }

            if (foundUredjaj.OsobaId == oId && foundUredjaj.Id == uId)
            {
                throw new Exception("Korisnik vec koristi trazeni uredjaj");
            }

            foundUredjaj.OsobaId = oId;
        }



     


    }
}
