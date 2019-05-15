using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaAppService.Dto
{
    [AutoMap(typeof(Osoba))]
    public class OsobaGetDto : EntityDto
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }

}
