using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{
    public class CorrespondenceTrail {

        private int _correspondenceTrailsId;

        private string _description;

        private DateTime? _actionDate;

        private User _user;

        private Correspondence _correspondence;
    


        public CorrespondenceTrail()
        {

        }

   
        public virtual int CorrespondenceTrailsId
        {
            get
            {
                return _correspondenceTrailsId;
            }
            set
            {
                _correspondenceTrailsId = value;
            }
        }


        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public virtual DateTime? ActionDate
        {
            get
            {
                return _actionDate;
            }
            set
            {
                _actionDate = value;
            }
        }

        public virtual User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
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
    }

}
