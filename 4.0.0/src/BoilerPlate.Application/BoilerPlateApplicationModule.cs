using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlate.Models;
using BoilerPlate.OsobaUredjajAppService.Dto;

namespace BoilerPlate
{
    [DependsOn(
        typeof(BoilerPlateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BoilerPlateApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateApplicationModule).GetAssembly());
        }


        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<OsobaUredjaj, OsobaUredjajGetDto>()
                    .ForMember(s => s.Osoba, d => d.MapFrom(x => x.Osoba.Ime + "" + x.Osoba.Prezime))
                    .ForMember(s => s.Uredjaj, d => d.MapFrom(x => x.Uredjaj.UredjajIme));
            });
        }
    }
}