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
        KancelarijaGetDto GetById(long id);
        KancelarijaGetDto GetOffice(long id);
        void Insert(KancelarijaGetDto input);
        void Update (long id, KancelarijaPutDto input);
        void Delete(long id);
    }
}
