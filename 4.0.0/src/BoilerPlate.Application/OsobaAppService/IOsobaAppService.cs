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
        OsobaGetDto GetById(int id);
        Osoba GetOsoba(int id);
        void Insert(OsobaPostDto input);
        void Update(int id, OsobaPutDto input);
        void Delete(int id);
    }
}
