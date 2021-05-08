using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Personal:IEntity
    {
        public int PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int PersonalNumber { get; set; }
        public int BloodGroupId { get; set; }
        public string Gender { get; set; }
    }
}
