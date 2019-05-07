using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;

namespace BoilerPlate.UredjajAppService.Dto
{
    [AutoMap(typeof(Uredjaj))]
    public class UredjajGetAllDto : EntityDto
    {
        public IReadOnlyList<UredjajGetDto> Uredjaj { get; }

        public UredjajGetAllDto(IReadOnlyList<UredjajGetDto> uredjaj)
        {
            Uredjaj = uredjaj;
        }

      
    }
}
