using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class VaccineTracking:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VaccineId { get; set; }
        public DateTime VaccineDate { get; set; }
        public DateTime CovidDose1 { get; set; }
        public DateTime CovidDose2 { get; set; }
        public bool CovidPositive { get; set; }
        public DateTime CovidStart { get; set; }
        public DateTime CovidFinish { get; set; }
    }
}
