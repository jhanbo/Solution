using System;

namespace ITGateWorkDesk.Data.Domain
{

    public class AssignmentAttachment
    {

        private long _assignmentAttachmentId;
        private string _name;
        private string _description;
        private DateTime? _createdDate;
        private byte[] _dataFile;
        private Assignment _assignment;

        public AssignmentAttachment()
        {

        }

        public virtual long AssignmentAttachmentId
        {
            get
            {
                return _assignmentAttachmentId;
            }
            set
            {
                _assignmentAttachmentId = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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

        public virtual byte[] DataFile
        {
            get
            {
                return _dataFile;
            }
            set
            {
                _dataFile = value;
            }
        }

        public virtual Assignment Assignment
        {
            get
            {
                return _assignment;
            }
            set
            {
                _assignment = value;
            }
        }
    }

}
