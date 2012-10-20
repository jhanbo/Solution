using System;
using ITGateWorkDesk.Data.DAO.Impl;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services;
using System.Collections.Generic;
using ITGateWorkDesk.Data.Services.Base;
using System.Linq;
using Spring.Transaction.Interceptor;

namespace ITGateWorkDesk.Data.Services.Impl
{
    public class CorrespondenceService : ServiceBase<CorrespondenceDao, Correspondence, Int32>
    {

        #region Properties
        private CorrespondenceTypeService _corrTypeService;
        public CorrespondenceTypeService CorrespondenceTypeService
        {
            get { return _corrTypeService; }
            set { _corrTypeService = value; }
        }

        private OrgUnitService _orgUnitService;
        public OrgUnitService OrgUnitService
        {
            get { return _orgUnitService; }
            set { _orgUnitService = value; }
        }

        private CorrespondenceToOrgService _correspondenceDestinationsServices;
        public CorrespondenceToOrgService CorrespondenceDestinationsServices
        {
            get { return _correspondenceDestinationsServices; }
            set { _correspondenceDestinationsServices = value; }
        }

        private CorrespondenceTrailService _correspondenceTrailService;
        public CorrespondenceTrailService CorrespondenceTrailService
        {
            get { return _correspondenceTrailService; }
            set { _correspondenceTrailService = value; }
        }

        private CorrespondenceNoteService _correspondenceNoteSerivce;
        public CorrespondenceNoteService CorrespondenceNoteSerivce
        {
            get { return _correspondenceNoteSerivce; }
            set { _correspondenceNoteSerivce = value; }
        }

        private CorrespondenceAttachmentService _correspondenceAttachmentService;
        public CorrespondenceAttachmentService CorrespondenceAttachmentService
        {
            get { return _correspondenceAttachmentService; }
            set { _correspondenceAttachmentService = value; }
        }

        #endregion

        public int GetCountByType(bool isInternal, bool isIncome, int orgunitID, int userID, bool decisions = false)
        {
            if (decisions)
            {
                return isIncome ? Dao.GetIncomingDecisions(orgunitID, userID).Count() : Dao.GetOutcomingDecisions(orgunitID, userID).Count();
            }

            if (isIncome)
            {
                return isInternal ? Dao.GetInternalIncomingList(orgunitID, userID).Count() : Dao.GetExternalIncomingList(orgunitID, userID).Count();
            }

            return isInternal ? Dao.GetInternalOutcomingList(orgunitID, userID).Count() : Dao.GetExternalOutcomingList(orgunitID, userID).Count();
            //if (isIncome && isInternal)
            //{
            //    return Dao.GetInternalIncomingList(orgunitID, userID).Count();
            //}

            //if (!isIncome && isInternal)
            //{
            //    return Dao.GetInternalOutcomingList(orgunitID, userID).Count();
            //}

            //if (isIncome && !isInternal)
            //{
            //    return Dao.GetExternalIncomingList(orgunitID, userID).Count();
            //}

            //if (!isIncome && !isInternal)
            //{
            //    return Dao.GetExternalOutcomingList(orgunitID, userID).Count();
            //}

            //return 0;
        }

        public IEnumerable<Correspondence> GetByType(bool isInternal, bool isIncoming, int orgunitID, int userID)
        {
            if (isIncoming && isInternal)
            {
                return Dao.GetInternalIncomingList(orgunitID, userID);
            }

            if (!isIncoming && isInternal)
            {
                return Dao.GetInternalOutcomingList(orgunitID, userID);
            }

            if (isIncoming && !isInternal)
            {
                return Dao.GetExternalIncomingList(orgunitID, userID);
            }

            if (!isIncoming && !isInternal)
            {
                return Dao.GetExternalOutcomingList(orgunitID, userID);
            }

            return null;
        }
        public void SetCorrespondenceType(Correspondence entity, int corrTypeID)
        {
            entity.CorrespondeceType = _corrTypeService.GetByID(corrTypeID);
        }

        public void SetOrgunit(Correspondence entity, int orgunitID)
        {
            entity.Orgunit = _orgUnitService.GetByID(orgunitID);
        }

        public void SetDestinations(Correspondence entity, List<int> orgs, string type)
        {
            foreach (int org in orgs)
            {
                CorrespondenceToOrganization cto = new CorrespondenceToOrganization();
                cto.Correspondence = entity;
                cto.OrganizationUnit = _orgUnitService.GetByID(org);
                if (cto.OrganizationUnit.OrganizationType == 1)
                {
                    entity.IsInternal = 1;
                }
                cto.ToCcType = type;
                entity.CorrespondenceToOrgs.Add(cto);
            }
        }

        public IList<CorrespondenceType> GetTypesList()
        {
            return _corrTypeService.GetAll();
        }

        public void CreateNote(int correspondenceID, string corrNoteArea, User user)
        {
            Correspondence entity = GetByID(correspondenceID);
            CorrespondenceNote note = new CorrespondenceNote
                                          {
                                              Correspondence = entity,
                                              Note = corrNoteArea,
                                              NoteDate = DateTime.Now,
                                              User = user
                                          };
            _correspondenceNoteSerivce.Create(note);
        }

        [Transaction]
        public override int Create(Correspondence entity)
        {
            int id = base.Create(entity);
            CorrespondenceTrail ct = new CorrespondenceTrail
                                         {
                                             ActionDate = DateTime.Now,
                                             Correspondence = entity,
                                             Description = "Create the Correspondence",
                                             User = entity.User
                                         };
            _correspondenceTrailService.Create(ct);
            if (entity.CorrespondenceToOrgs != null)
            {
                foreach (CorrespondenceToOrganization org in entity.CorrespondenceToOrgs)
                {
                    _correspondenceDestinationsServices.Create(org);
                }
            }

            if (entity.CorrAttachments != null)
            {
                foreach (CorrespondenceAttachment atc in entity.CorrAttachments)
                {
                    _correspondenceAttachmentService.Create(atc);
                }
            }
            return id;
        }

        public IEnumerable<Correspondence> GetDecisions(int orgunit, int user, bool incoming)
        {
            return incoming ? Dao.GetIncomingDecisions(orgunit, user) : Dao.GetOutcomingDecisions(orgunit, user);
        }
    }
}
