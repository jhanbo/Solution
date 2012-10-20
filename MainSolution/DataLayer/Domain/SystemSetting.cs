using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{

    public class SystemSetting
    {
        public SystemSetting()
        {

        }

        public virtual int SystemSettingId { get; set; }


        public virtual string Name { get; set; }


        public virtual string Value { get; set; }
    }

}
