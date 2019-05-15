using System.Collections.Generic;
using Abp.Application.Services;
using BoilerPlate.KancelarijaAppService.Dto;

namespace BoilerPlate.KancelarijaAppService
{
    public interface IKancelarijaAppService : IApplicationService
    {
        List<KancelarijaGetDto> Get();
        KancelarijaDto GetById(int id);
        KancelarijaGetDto GetKancelarija(int id);
        void Insert(KancelarijaDto input);
        void Update (int id, KancelarijaPutDto input);
        void Delete(int id);
    }
}
