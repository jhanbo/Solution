using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ITGateWorkDesk.Data.Domain
{
    public class CorrespondenceDraft
    {
        public virtual int DraftID { get; set; }
        public virtual int CorrespondenceID { get; set; }

        public virtual string RecordNo { get; set; }

        public virtual string Devision { get; set; }

        public virtual DateTime? CreatedDate { get; set; }

        public virtual int? RequireFollowup { get; set; }

        public virtual int? Importance { get; set; }

        public virtual string Title { get; set; }

        public virtual string PersonName { get; set; }

        public virtual int? IsSecret { get; set; }

        public virtual int? IsInternal { get; set; }

        public virtual string LatestChangeUser { get; set; }

        public virtual DateTime? LatestChangeDate { get; set; }

        public virtual Correspondence Parent { get; set; }

        public virtual User User { get; set; }

        public virtual OrganizationUnit Orgunit { get; set; }

        public virtual IList<CorrespondenceToOrganization> CorrespondenceToOrgs { get; set; }

        public virtual DateTime? RecordDate { get; set; }

        public virtual string DeliveryMethod { get; set; }

        public virtual int? AttachementsCount { get; set; }

        public virtual CorrespondenceType CorrespondeceType { get; set; }

        public DateTime DraftCreateDate { get; set; }
    }
}
