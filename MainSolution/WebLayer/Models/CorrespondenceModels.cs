using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITGateWorkDesk.Data.Domain;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class CorrespondenceModel
    {

        [Required(ErrorMessageResourceName = "CorrespondenceIDRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "CorrespondenceID", ResourceType = typeof(Resources.Resources))]
        public int ID { get; set; }

        [Display(Name = "CorrespondenceParent", ResourceType = typeof(Resources.Resources))]
        public int? ParentID { get; set; }

        [Required(ErrorMessageResourceName = "RecordNoRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "RecordNo", ResourceType = typeof(Resources.Resources))]
        public string RecordNo { get; set; }


        [Required(ErrorMessageResourceName = "DevisionRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Devision", ResourceType = typeof(Resources.Resources))]
        public string Devision { get; set; }

        [Required(ErrorMessageResourceName = "CreateDateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "CreateDate", ResourceType = typeof(Resources.Resources))]
        public DateTime CreateDate { get; set; }

        [Display(Name = "RequireFollowup", ResourceType = typeof(Resources.Resources))]
        public bool RequireFollowup { get; set; }

        [Display(Name = "Importance", ResourceType = typeof(Resources.Resources))]
        public int Importance { get; set; }

        [Required(ErrorMessageResourceName = "CorrespondenceTitleRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "CorrespondenceTitle", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [Display(Name = "PersonName", ResourceType = typeof(Resources.Resources))]
        public string PersonName { get; set; }

        [Display(Name = "IsSecret", ResourceType = typeof(Resources.Resources))]
        public bool IsSecret { get; set; }

        [Display(Name = "IsInternal", ResourceType = typeof(Resources.Resources))]
        public bool IsInternal { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public int State { get; set; }

        [Required(ErrorMessageResourceName = "RecordDateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "RecordDate", ResourceType = typeof(Resources.Resources))]
        public DateTime RecordDate { get; set; }

        [Required(ErrorMessageResourceName = "DeliveryMethodRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "DeliveryMethod", ResourceType = typeof(Resources.Resources))]
        public string DeliveryMethod { get; set; }

        [Display(Name = "AttachmentsCount", ResourceType = typeof(Resources.Resources))]
        public int? AttachmentsCount { get; set; }

        [Display(Name = "IncomingFrom", ResourceType = typeof(Resources.Resources))]
        public int Orgunit { get; set; }

        [Required(ErrorMessageResourceName = "IncomingToRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "IncomingTo", ResourceType = typeof(Resources.Resources))]
        public string Destinations { get; set; }

        [Display(Name = "IncomingCC", ResourceType = typeof(Resources.Resources))]
        public string DestinationsCC { get; set; }

        [Required(ErrorMessageResourceName = "CorrespondenceTypeRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "CorrespondenceType", ResourceType = typeof(Resources.Resources))]
        public int CorrespondenceType { get; set; }

        [Display(Name = "Attachements", ResourceType = typeof(Resources.Resources))]
        public List<HttpPostedFileBase> Attachments { get; set; }

        public List<string> AttachmentsDescriptions { get; set; }

        public string submitBtnName { get; set; }
        public string OrgunitLabel{get;set;}
        public string DestinationsLabel { get; set; }
        public string DestinationsCCLabel{get;set;}
                              
    }

    public class CorrespondenceDetailsModel
    {
        [Display(Name = "CorrespondenceID", ResourceType = typeof(Resources.Resources))]
        public int CorrespondenceID { get; set; }

        public string CorrespondenceOrigin { get; set; }

        public string CorrespondenceType { get; set; }

        [Display(Name = "InDate", ResourceType = typeof(Resources.Resources))]
        public string CorrDate { get; set; }

        [Display(Name = "FromOrg", ResourceType = typeof(Resources.Resources))]
        public string FromOrg { get; set; }

        [Display(Name = "ToOrg", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<string> ToOrgs { get; set; }

        [Display(Name = "CcOrg", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<string> CcOrgs { get; set; }

        [Display(Name = "Referrals", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<AssignmentViewModel> Referrals { get; set; }

        [Display(Name = "Remarks", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<CorrespondenceNoteModel> Notes { get; set; }

        [Display(Name = "ChangeLog", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<CorrespondeceChangeLogModel> ChangeLog { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        public string CorrespondenceSubject { get; set; }

        public string Note { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public string State { get; set; }

        [Display(Name = "Attachements", ResourceType = typeof(Resources.Resources))]
        public IList<AttachmentModel> Attachments;

        public bool IsDecision { get; set; }
    }

    public class AttachmentModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class CorrespondenceNoteModel
    {
        public string User { get; set; }
        public string Note { get; set; }
        public string NoteDate { get; set; }
    }

    public class CorrespondeceChangeLogModel
    {
        public DateTime ChangeDate { get; set; }
        public string ChangeUser { get; set; }
        public string ChangeAction { get; set; }
    }

    public static class CorrespondenceModelsHelper
    {
        public static string GetCorrespondenceType(this Correspondence entity,int currOrgunit)
        {
            bool isInteral = entity.IsInternal == 1;
            bool isOutcoming = entity.Orgunit.IdOrgUnit == currOrgunit;

            if (isInteral)
            {
                return isOutcoming ? ITGateWorkDesk.Resources.Resources.InternalOutcomeType : ITGateWorkDesk.Resources.Resources.InternalIncomeType;
            }
            return isOutcoming ? ITGateWorkDesk.Resources.Resources.ExternalOutcomeType : ITGateWorkDesk.Resources.Resources.ExternalIncomeType;
        }
        public static CorrespondenceDetailsModel CreateDetailsModelFromEntity(Correspondence entity, int currentOrgunit)
        {
            CorrespondenceDetailsModel model = new CorrespondenceDetailsModel
                                                   {
                                                       CorrespondenceID = entity.CorrespondenceId,
                                                       CorrespondenceOrigin =
                                                           entity.GetCorrespondenceType(currentOrgunit),
                                                       CorrespondenceSubject = entity.Title,
                                                       CorrespondenceType = entity.CorrespondeceType.CorrTypeDesc,
                                                       FromOrg = entity.Orgunit.Name,
                                                       State = entity.State == null ? "" : entity.State.Description,
                                                       IsDecision = entity.IsDecision > 0,
                                                       Attachments =
                                                           entity.CorrAttachments == null
                                                               ? new List<AttachmentModel>()
                                                               : entity.CorrAttachments.Select(c => new AttachmentModel
                                                                                                        {
                                                                                                            ID =
                                                                                                                c.
                                                                                                                CorrespondenceAttachmentId,
                                                                                                            FileName =
                                                                                                                c.Name,
                                                                                                            Description
                                                                                                                =
                                                                                                                c.
                                                                                                                Description,
                                                                                                            CreateDate =
                                                                                                                c.
                                                                                                                CreatedDate
                                                                                                        }).ToList(),
                                                       Referrals =
                                                           entity.Assignments.Select(c => c.CreateViewModel())
                                                   };
            if (entity.CreatedDate != null) model.CorrDate = entity.CreatedDate.Value.ToShortDateString();
            if (entity.CorrespondenceToOrgs != null)
            {
                model.CcOrgs = entity.CorrespondenceToOrgs.Where(cto => cto.ToCcType.Equals("CC")).Select(c => c.OrganizationUnit.Name);
                model.ToOrgs = entity.CorrespondenceToOrgs.Where(cto => cto.ToCcType.Equals("TO")).Select(c => c.OrganizationUnit.Name);
            }

            if (entity.Notes != null)
            {
                model.Notes =
                    entity.Notes.Select(
                        n =>
                        new CorrespondenceNoteModel { Note = n.Note, NoteDate = n.NoteDate.Value.ToShortDateString(), User = n.User.UserName });
            }
            if (entity.CorrTrails != null)
            {
                model.ChangeLog = entity.CorrTrails.Select(t => t.CreateChangeLogModel());
            }
            return model;
        }
        public static Correspondence CreateEntityFromModel(CorrespondenceModel model)
        {
            Correspondence entity = new Correspondence
                                        {
                                            CorrespondenceId = model.ID,
                                            RecordNo = model.RecordNo,
                                            Devision = model.Devision,
                                            CreatedDate = model.CreateDate,
                                            RequireFollowup = model.RequireFollowup ? 1 : 0,
                                            Importance = model.Importance,
                                            Title = model.Title,
                                            PersonName = model.PersonName,
                                            IsSecret = model.IsSecret ? 1 : 0,
                                            IsInternal = model.IsInternal ? 1 : 0,
                                            RecordDate = model.RecordDate,
                                            DeliveryMethod = model.DeliveryMethod,
                                            AttachementsCount = model.AttachmentsCount
                                        };
            //entity.State = model.State;
            return entity;
        }

        public static CorrespondenceDraft CreateDraftEntityFromModel(CorrespondenceModel model)
        {
            CorrespondenceDraft entity = new CorrespondenceDraft
            {
                CorrespondenceID = model.ID,
                RecordNo = model.RecordNo,
                Devision = model.Devision,
                CreatedDate = model.CreateDate,
                RequireFollowup = model.RequireFollowup ? 1 : 0,
                Importance = model.Importance,
                Title = model.Title,
                PersonName = model.PersonName,
                IsSecret = model.IsSecret ? 1 : 0,
                IsInternal = model.IsInternal ? 1 : 0,
                RecordDate = model.RecordDate,
                DeliveryMethod = model.DeliveryMethod,
                AttachementsCount = model.AttachmentsCount
            };
            //entity.State = model.State;
            return entity;
        }

        public static CorrespondeceChangeLogModel CreateChangeLogModel(this CorrespondenceTrail entity)
        {
            CorrespondeceChangeLogModel model = new CorrespondeceChangeLogModel();
            model.ChangeAction = entity.Description;
            if (entity.ActionDate != null) model.ChangeDate = entity.ActionDate.Value;
            model.ChangeUser = entity.User.UserName;
            return model;
        }
    }

    public class CorrespondenceDraftModel
    {
        public int ID { get; set; }
        public int CorrespondenceID { get; set; }
        public string CorrespondenceTitle { get; set; }
        public DateTime DraftDate { get; set; }
    }
    public class CorrespondenceFilterModel
    {

        [Display(Name = "ToWhom", ResourceType = typeof(Resources.Resources))]
        public string To { get; set; }

        [Display(Name = "FromDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? FromDate { get; set; }

        [Display(Name = "ToDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? ToDate { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public int State { get; set; }
    }

    public class CorrespondenceTypeModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "TheCode", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }

        [Required]
        [Display(Name = "TheDescription", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }
    }
}