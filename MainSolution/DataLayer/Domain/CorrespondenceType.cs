using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ITGateWorkDesk.Data.Domain
{
    public class CorrespondenceType
    {
        public CorrespondenceType() { }

        public virtual int ID { get; set; }
        public virtual string CorrTypeCode { get; set; }
        public virtual string CorrTypeDesc { get; set; }
    }
}
