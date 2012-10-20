using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGateWorkDesk.Data.Domain
{
    public class Permission
    {
       private int _idPermission;
       private string _name;
       private string _code;
       private string _description;
       private Role _role;



       public virtual int IdPermission
       {
           get
           {
               return this._idPermission;
           }
           set
           {
               this._idPermission = value;
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
    }
}
