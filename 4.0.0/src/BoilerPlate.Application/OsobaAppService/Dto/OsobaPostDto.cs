﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Osoba))]
    public class OsobaPostDto : EntityDto
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int KancelarijaId { get; set; }

    }
}
