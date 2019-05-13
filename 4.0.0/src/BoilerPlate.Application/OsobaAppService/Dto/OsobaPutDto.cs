using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Osoba))]
    public class OsobaPutDto : EntityDto

    {
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public int KancelarijaId { get; set; }
    }
}
