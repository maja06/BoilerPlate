using Abp.EntityFrameworkCore;
using BoilerPlate.Models;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate.EntityFrameworkCore
{
    public class BoilerPlateDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Kancelarija> Kancelarije { get; set; }
        public DbSet<Uredjaj> Uredjaji { get; set; }
        public DbSet<OsobaUredjaj> OsobeUredjaji { get; set; }

        public BoilerPlateDbContext(DbContextOptions<BoilerPlateDbContext> options)
            : base(options)
        {

        }


        
    }
}
