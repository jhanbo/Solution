using System;
using System.Collections.Generic;
namespace ITGateWorkDesk.Data.Domain
{
    public class User
    {
        public virtual int IditgUser { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Pass { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string GfName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Mobile { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual DateTime JoinDate { get; set; }

        public virtual string Notes { get; set; }

        public virtual IList<UserRolesOrg> UserRoleOrgs { get; set; }

        public virtual IList<Assignment> Assignments { get; set; }

        public virtual IList<CorrespondenceTrail> CorrTrails { get; set; }

        public virtual IList<Correspondence> Correspondences { get; set; }

        public virtual OrganizationUnit Orgunit { get; set; }
    }
}
