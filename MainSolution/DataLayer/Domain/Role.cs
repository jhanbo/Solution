using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{
    public class Role
    {
        private int _idRole;
        private string _name;
        private string _description;
        private IList<Permission> _permissions;
        private IList<UserRolesOrg> _userRoleOrgs;

        public virtual int IdRole
        {
            get
            {
                return this._idRole;
            }
            set
            {
                this._idRole = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }


        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public virtual IList<Permission> Permissions
        {
            get
            {
                return this._permissions;
            }
            set
            {
                this._permissions = value;
            }
        }

        public virtual IList<UserRolesOrg> UserRoleOrgs
        {
            get
            {
                return this._userRoleOrgs;
            }
            set
            {
                this._userRoleOrgs = value;
            }
        }
    }
}
