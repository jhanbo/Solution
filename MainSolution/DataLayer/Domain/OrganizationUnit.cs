using System.Collections.Generic;


namespace ITGateWorkDesk.Data.Domain
{
    public class OrganizationUnit
    {
        private int _idOrgUnit;
        private string _name;
        private string _code;
        private int _orgType;
        private string _phone;
        private string _email;
        private string _fax;
        private string _notes;
        private IList<UserRolesOrg> _userRoleOrgs;
        private IList<User> _itgUsers;
        private IList<OrganizationUnit> _orgUnits;
        private IList<OrganizationUnitSettings> _orgUnitSettings;
        private IList<Correspondence> _correspondences;
        private IList<CorrespondenceToOrganization> _correspondenceToOrgs;
        private OrganizationUnit _parent;
        public OrganizationUnit()
        {
            _userRoleOrgs = new List<UserRolesOrg>();
            _itgUsers = new List<User>();
            _orgUnits = new List<OrganizationUnit>();
            _orgUnitSettings = new List<OrganizationUnitSettings>();
            _correspondences = new List<Correspondence>();
            _correspondenceToOrgs = new List<CorrespondenceToOrganization>();
        }

        public virtual int IdOrgUnit
        {
            get
            {
                return this._idOrgUnit;
            }
            set
            {
                this._idOrgUnit = value;
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


        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }


        public virtual int OrganizationType
        {
            get
            {
                return this._orgType;
            }
            set
            {
                this._orgType = value;
            }
        }


        public virtual string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                this._phone = value;
            }
        }


        public virtual string Fax
        {
            get
            {
                return this._fax;
            }
            set
            {
                this._fax = value;
            }
        }


        public virtual string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }


        public virtual string Notes
        {
            get
            {
                return this._notes;
            }
            set
            {
                this._notes = value;
            }
        }


        public virtual IList<UserRolesOrg>UserRoleOrgs
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


        public virtual IList<User> Users
        {
            get
            {
                return this._itgUsers;
            }
            set
            {
                this._itgUsers = value;
            }
        }


        public virtual IList<OrganizationUnit>OrgUnits
        {
            get
            {
                return this._orgUnits;
            }
            set
            {
                this._orgUnits = value;
            }
        }

        public virtual IList<OrganizationUnitSettings> Settings
        {
            get
            {
                return this._orgUnitSettings;
            }
            set
            {
                this._orgUnitSettings = value;
            }
        }

        public virtual IList<Correspondence> Correspondences
        {
            get
            {
                return this._correspondences;
            }
            set
            {
                this._correspondences = value;
            }
        }


        public virtual IList<CorrespondenceToOrganization> CorrespondenceToOrgs
        {
            get
            {
                return this._correspondenceToOrgs;
            }
            set
            {
                this._correspondenceToOrgs = value;
            }
        }

        public virtual OrganizationUnit Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
    }
}