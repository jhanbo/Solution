using System;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{

    public class Assignment
    {
        public Assignment()
        {
            //_assignmentAttachments = new List<AssignmentAttachment>();
        }

        public virtual int AssignmenId { get; set; }

        public virtual DateTime? AssignedDate { get; set; }

        public virtual DateTime? ReceivedDate { get; set; }

        public virtual DateTime? DueDate { get; set; }

        public virtual DateTime? RemindedDate { get; set; }

        public virtual string Actions { get; set; }

        public virtual int? State { get; set; }

        public virtual Correspondence Correspondence { get; set; }

        public virtual User User { get; set; }

        public virtual OrganizationUnit Orgunit { get; set; }

        public virtual IList<AssignmentAttachment> AssignmentAttachments { get; set; }
    }

}
