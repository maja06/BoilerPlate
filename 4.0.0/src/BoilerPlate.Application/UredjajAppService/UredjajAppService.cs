using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

         public UredjajGetDto GetById(long id)
         {
             Uredjaj uredjaj;

             try
             {

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

         public void Update(long id, UredjajPutDto input)
         {
             throw new NotImplementedException();
         }

         public void Delete(long id)
         {
             throw new NotImplementedException();
         }

         public void Update(int id, UredjajGetDto input)
         {


         _uredjajRepository.Update(id, ent =>
         { ObjectMapper.Map(input, ent); 
                 
         });
        
         }

         public Uredjaj GetUredjaj(long id)
         {
             var svi = _uredjajRepository.GetAll();
             var uredjaj = svi.FirstOrDefault(x => x.UredjajId == id);

             if (uredjaj == null)
             {
                 throw new Exception("Id Not Found");

             }

             return uredjaj;
         }

         public void IzmijeniKorisnika(long oId, long uId)
         {
             throw new NotImplementedException();
         }

       
     }
}
