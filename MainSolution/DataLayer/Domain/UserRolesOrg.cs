using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGateWorkDesk.Data.Domain
{
    public class UserRolesOrg
    {
        private Role _role;
        private OrganizationUnit _orgUnit;
        private User _itgUser;

        public virtual Role Role
        {
            get
            {
                return this._role;
            }
            set
            {
                this._role = value;
            }
        }

        public virtual OrganizationUnit Orgunit
        {
            get
            {
                return this._orgUnit;
            }
            set
            {
                this._orgUnit = value;
            }
        }

        public virtual User User
        {
            get
            {
                return this._itgUser;
            }
            set
            {
                this._itgUser = value;
            }
        }

        public override bool Equals(object obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
