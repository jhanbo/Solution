using System;
using ITGateWorkDesk.Data.DAO.Impl;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services.Base;

namespace ITGateWorkDesk.Data.Services.Impl
{
    public class AssignmentService : ServiceBase<AssignmentDao, Assignment, Int32>
    {

        private AssignmentAttachmentService _attachmentService;
        public AssignmentAttachmentService AttachmentService
        {
            get { return _attachmentService; }
            set { _attachmentService = value; }
        }

        public override int Create(Assignment entity)
        {
            int id = base.Create(entity);
            if (entity.AssignmentAttachments != null)
            {
                foreach (AssignmentAttachment attachment in entity.AssignmentAttachments)
                {
                    _attachmentService.Create(attachment);
                }
            }
            return id;
        }
    }
}
