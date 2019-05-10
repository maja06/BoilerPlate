using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BoilerPlate.Models
{
  
    public class Kancelarija : Entity
    { 
        
        
        public string Opis { get; set; }

        public IList<Osoba> ListaOsobe { get; set; } = new List<Osoba>();



    }
}
