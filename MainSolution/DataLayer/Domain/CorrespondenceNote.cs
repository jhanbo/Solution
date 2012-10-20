using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ITGateWorkDesk.Data.Domain
{
    public class CorrespondenceNote
    {
        public int ID { get; set; }
        public Correspondence Correspondence { get; set; }
        public User User { get; set; }
        public string Note { get; set; }
        public DateTime? NoteDate { get; set; }

    }
}
