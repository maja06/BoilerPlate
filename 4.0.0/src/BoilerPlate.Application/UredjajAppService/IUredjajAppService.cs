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
        UredjajGetDto GetById(int id);
        int Insert(UredjajPostDto input);
        void Update(int id, UredjajPutDto input);
        void Delete(int id);
        Uredjaj GetUredjaj(int id);
    }
}
