﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.UredjajAppService.Dto
{
    [AutoMap(typeof(Uredjaj))]
     public class UredjajPostDto : EntityDto
    {
        public string UredjajIme { get; set; }
        public int? OsobaId { get; set; }
    }
}
