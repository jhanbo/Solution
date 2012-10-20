using System;

namespace ITGateWorkDesk.Data.Domain
{

    public class CorrespondenceToOrganization
    {
        private int _id;
        private string _toCcType;

        private Correspondence _correspondence;

        private OrganizationUnit _orgunit;

        public override bool Equals(object obj)
        {
          CorrespondenceToOrganization toCompare = obj as CorrespondenceToOrganization;
          if (toCompare == null)
          {
            return false;
          }
          if (!Object.Equals(_correspondence, toCompare.Correspondence))
            return false;
          if (!Object.Equals(_orgunit, toCompare.OrganizationUnit))
            return false;
          
          return true;
        }

        public override int GetHashCode()
        {
          int hashCode = 13;
          hashCode = (hashCode * 7) + Correspondence.GetHashCode();
          hashCode = (hashCode * 7) + _orgunit.GetHashCode();
          return hashCode;
        }


        public CorrespondenceToOrganization()
        {

        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    
        public virtual string ToCcType
        {
            get
            {
                return _toCcType;
            }
            set
            {
                _toCcType = value;
            }
        }

        public virtual Correspondence Correspondence
        {
            get
            {
                return _correspondence;
            }
            set
            {
                _correspondence = value;
            }
        }

        public virtual OrganizationUnit OrganizationUnit
        {
            get
            {
                return _orgunit;
            }
            set
            {
                _orgunit = value;
            }
        }
    }

}
