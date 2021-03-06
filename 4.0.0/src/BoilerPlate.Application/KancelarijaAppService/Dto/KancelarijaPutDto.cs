﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.KancelarijaAppService.Dto
{
    [AutoMap(typeof(Kancelarija))]
    public class KancelarijaPutDto : EntityDto
    {
        public string Opis { get; set; }
    }
}
