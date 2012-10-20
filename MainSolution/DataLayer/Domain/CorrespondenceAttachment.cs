using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Domain
{

    public class CorrespondenceAttachment {

        private int _correspondenceAttachmentId;

        private string _name;

        private string _description;

        private DateTime _createdDate;

        private byte[] _dataFile;

        private Correspondence _correspondence;
    


        public CorrespondenceAttachment()
        {

        }

        public virtual int CorrespondenceAttachmentId
        {
            get
            {
                return _correspondenceAttachmentId;
            }
            set
            {
                _correspondenceAttachmentId = value;
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

        public virtual DateTime CreatedDate
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
