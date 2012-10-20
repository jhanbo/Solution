using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{
    public class Correspondence
    {

        private int _correspondenceId;

        private string _recordNo;

        private string _devision;

        private DateTime? _createdDate;

        private int? _requireFollowup;

        private int? _importance;

        private string _title;

        private string _personName;

        private int? _isSecret;

        private int? _isInternal;

        private CorrespondenceState _state;

        private string _latestChangeUser;

        private DateTime? _latestChangeDate;

        private IList<Assignment> _assignments;

        private IList<CorrespondenceAttachment> _corrAttachments;

        private IList<CorrespondenceTrail> _corrTrails;

        private IList<Correspondence> _childs;

        private Correspondence _parent;

        private User _user;

        private OrganizationUnit _orgunit;

        private IList<CorrespondenceToOrganization> _correspondenceToOrgs;

        private DateTime? _recordDate;

        private string _deliveryMethod;

        private int? _attachementsCount;

        private CorrespondenceType _corrType;

        private IList<CorrespondenceNote> _notes;

        private int _isDecision;
        public Correspondence()
        {
            _assignments = new List<Assignment>();
            _corrAttachments = new List<CorrespondenceAttachment>();
            _corrTrails = new List<CorrespondenceTrail>();
            _childs = new List<Correspondence>();
            _correspondenceToOrgs = new List<CorrespondenceToOrganization>();

        }

        public virtual int CorrespondenceId
        {
            get
            {
                return _correspondenceId;
            }
            set
            {
                _correspondenceId = value;
            }
        }

        public virtual string RecordNo
        {
            get
            {
                return _recordNo;
            }
            set
            {
                _recordNo = value;
            }
        }

        public virtual string Devision
        {
            get
            {
                return _devision;
            }
            set
            {
                _devision = value;
            }
        }

        public virtual DateTime? CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
            }
        }

        public virtual int? RequireFollowup
        {
            get
            {
                return _requireFollowup;
            }
            set
            {
                _requireFollowup = value;
            }
        }

        public virtual int? Importance
        {
            get
            {
                return _importance;
            }
            set
            {
                _importance = value;
            }
        }

        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public virtual string PersonName
        {
            get
            {
                return _personName;
            }
            set
            {
                _personName = value;
            }
        }

        public virtual int? IsSecret
        {
            get
            {
                return _isSecret;
            }
            set
            {
                _isSecret = value;
            }
        }

        public virtual int? IsInternal
        {
            get
            {
                return _isInternal;
            }
            set
            {
                _isInternal = value;
            }
        }

        public virtual CorrespondenceState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public virtual string LatestChangeUser
        {
            get
            {
                return _latestChangeUser;
            }
            set
            {
                _latestChangeUser = value;
            }
        }

        public virtual DateTime? LatestChangeDate
        {
            get
            {
                return _latestChangeDate;
            }
            set
            {
                _latestChangeDate = value;
            }
        }


        public virtual IList<Assignment> Assignments
        {
            get
            {
                return _assignments;
            }
            set
            {
                _assignments = value;
            }
        }

        public virtual IList<CorrespondenceAttachment> CorrAttachments
        {
            get
            {
                return _corrAttachments;
            }
            set
            {
                _corrAttachments = value;
            }
        }

        public virtual IList<CorrespondenceTrail> CorrTrails
        {
            get
            {
                return _corrTrails;
            }
            set
            {
                _corrTrails = value;
            }
        }

        public virtual IList<Correspondence> Childs
        {
            get
            {
                return _childs;
            }
            set
            {
                _childs = value;
            }
        }

        public virtual Correspondence Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
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

        public virtual OrganizationUnit Orgunit
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

        public virtual IList<CorrespondenceToOrganization> CorrespondenceToOrgs
        {
            get
            {
                return _correspondenceToOrgs;
            }
            set
            {
                _correspondenceToOrgs = value;
            }
        }

        public virtual DateTime? RecordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }

        public virtual string DeliveryMethod
        {
            get { return _deliveryMethod; }
            set { _deliveryMethod = value; }
        }

        public virtual int? AttachementsCount
        {
            get { return _attachementsCount; }
            set { _attachementsCount = value; }
        }

        public virtual CorrespondenceType CorrespondeceType
        {
            get { return _corrType; }
            set { _corrType = value; }
        }

        public IList<CorrespondenceNote> Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public int IsDecision
        {
            get { return _isDecision; }
            set { _isDecision = value; }
        }
    }

}
