using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.UredjajAppService.Dto
{
    [AutoMap(typeof(Uredjaj))]
     public class UredjajPostDto : EntityDto
    {
        public string Ime { get; set; }
        public int OsobaId { get; set; }
    }
}
