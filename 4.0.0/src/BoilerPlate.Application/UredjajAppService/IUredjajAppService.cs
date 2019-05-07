using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;
using BoilerPlate.UredjajAppService.Dto;

namespace BoilerPlate.UredjajAppService
{
    public interface IUredjajAppService : IApplicationService

    {
        List<UredjajGetDto> Get();
        UredjajGetDto GetById(long id);
        int Insert(UredjajPostDto input);
        void Update(long id, UredjajPutDto input);
        void Delete(long id);
        Uredjaj GetUredjaj(long id);
    }
}
