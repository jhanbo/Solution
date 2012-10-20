namespace ITGateWorkDesk.Data.Domain
{
    public class OrganizationUnitSettings
    {
          private int _idOrgSetting;
          private string _name;
          private string _value;
          private OrganizationUnit _orgUnit;


          public virtual int IdOrgSetting
          {
              get
              {
                  return this._idOrgSetting;
              }
              set
              {
                  this._idOrgSetting = value;
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

          public virtual string Value
          {
              get
              {
                  return this._value;
              }
              set
              {
                  this._value = value;
              }
          }

          public virtual OrganizationUnit OrgUnit
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
        
    }
}
