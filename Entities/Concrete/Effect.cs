using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Effect:IEntity
    {
        public int EffectId { get; set; }
        public string EffectName { get; set; }
    }
}
