using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGateWorkDesk.Data.Domain
{
    public class CorrespondenceState
    {
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
