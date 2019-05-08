using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;
using BoilerPlate.OsobaAppService.Dto;

namespace BoilerPlate.KancelariajAppService.Dto
{
    [AutoMap(typeof(Kancelarija))]
    public class KancelarijaGetDto : EntityDto
    {
        public string Opis { get; set; }
        public List<OsobaGetDto> ListaOsobe { get; set; } = new List<OsobaGetDto>();
    }
}
