using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using BoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate.OsobaUredjajAppService
{
   public class OsobaUredjajAppService : BoilerPlateAppServiceBase, IOsobaUredjajAppService 
   {
       private readonly IRepository<OsobaUredjaj> _osobaUredjajRepository;

       public OsobaUredjajAppService(IRepository<OsobaUredjaj> osobaUredjajRepository)
       {
           _osobaUredjajRepository = osobaUredjajRepository;
       }

       public void AddKoriscenje(int uId, int oId)
       {
           var koriscenje = new OsobaUredjaj
           {
               OsobaId = oId,
               UredjajId = uId,
               VrijemeOd = DateTime.Now
           };

           _osobaUredjajRepository.Insert(koriscenje);
       }

       public List<OsobaUredjaj> SvePoUredjaju(int id)
       {
           var all = _osobaUredjajRepository.GetAll().Include(o => o.Osoba).Include(u => u.Uredjaj);
           var found = all.Where(x => x.UredjajId == id).ToList();
           return found;
       }

       public void EndKoriscenje(int id)
       {
           var koriscenje = _osobaUredjajRepository.FirstOrDefault(u => u.UredjajId == id && u.VrijemeDo == null);
           if (koriscenje != null)
           {
               koriscenje.VrijemeDo = DateTime.Now;
           }
       }

      
   }
}
