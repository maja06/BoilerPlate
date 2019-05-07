using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.KancelariajAppService.Dto
{
    [AutoMap(typeof(Kancelarija))]
    public class KancelarijaPutDto : EntityDto
    {
        public string Opis { get; set; }
    }
}
