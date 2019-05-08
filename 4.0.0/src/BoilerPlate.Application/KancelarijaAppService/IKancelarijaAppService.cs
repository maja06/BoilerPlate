using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using BoilerPlate.KancelariajAppService.Dto;

namespace BoilerPlate.KancelariajAppService
{
    public interface IKancelarijaAppService : IApplicationService
    {
        List<KancelarijaGetDto> Get();
        KancelarijaGetDto GetById(int id);
        KancelarijaGetDto GetKancelarija(int id);
        void Insert(KancelarijaGetDto input);
        void Update (int id, KancelarijaPutDto input);
        void Delete(int id);
    }
}
