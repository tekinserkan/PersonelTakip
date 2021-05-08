using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Inspection:IEntity
    {
        public int InspectionId { get; set; }
        public int PersonalId { get; set; }
        public int CompanyId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int ReasonId { get; set; }
        public string Complaint { get; set; }
        public string Evidence { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public int ResultId { get; set; }
        public int UserId { get; set; }

    }
}
