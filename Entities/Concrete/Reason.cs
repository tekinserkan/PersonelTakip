using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Reason:IEntity
    {
        public int ReasonId { get; set; }
        public string ReasonName { get; set; }
    }
}
