using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Osoba))]
    public class OsobaGetAllDto 
    {
        public IReadOnlyList<OsobaGetDto> Osoba { get; }

        public OsobaGetAllDto(IReadOnlyList<OsobaGetDto> osoba)
        {
            Osoba = osoba;
        }

    }
}
