using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Vaccine:IEntity
    {
        public int VaccineId { get; set; }
        public string VaccineName { get; set; }
    }
}
