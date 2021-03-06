﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;

namespace BoilerPlate.UredjajAppService.Dto
{
    [AutoMap(typeof(Uredjaj))]
    public class UredjajGetAllDto : EntityDto
    {
        public IReadOnlyList<UredjajGetDto> ListaUredjaja { get; }

        public UredjajGetAllDto(IReadOnlyList<UredjajGetDto> listaUredjaja)
        {
            ListaUredjaja = listaUredjaja;
        }

      
    }
}
