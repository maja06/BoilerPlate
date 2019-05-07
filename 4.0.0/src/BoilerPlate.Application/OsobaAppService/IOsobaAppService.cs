using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    public interface IOsobaAppService : IApplicationService
    {
        List<OsobaGetDto> Get();
        OsobaGetDto GetById(long id);
        Osoba GetOsoba(long id);
        void Insert(OsobaPostDto input);
        void Update(long id, OsobaPutDto input);
        void Delete(long id);
    }
}
