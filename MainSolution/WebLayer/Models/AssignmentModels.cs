using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITGateWorkDesk.Data.Domain;
using System.ComponentModel.DataAnnotations;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class AssignmentModel
    {
        [Display(Name = "AssignmentID", ResourceType = typeof(Resources.Resources))]
        public int AssignmentId { get; set; }

        [Required(ErrorMessageResourceName = "AssignedDateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "AssignedDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        public DateTime? AssignedDate { get; set; }

        [Required(ErrorMessageResourceName = "ReceivedDateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "ReceivedDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        public DateTime? ReceivedDate { get; set; }

        [Required(ErrorMessageResourceName = "DueDateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "DueDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "RemindedDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        public DateTime? RemindedDate { get; set; }

        [Required(ErrorMessageResourceName = "ActionsRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Actions", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Actions { get; set; }

        [Required(ErrorMessageResourceName = "StateRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public int? State { get; set; }

        /*[Required(ErrorMessageResourceName = "TheCorrenspondenceRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "TheCorrenspondence", ResourceType = typeof(Resources.Resources))]
        public int? Correspondence { get; set; }*/

        [Display(Name = "User", ResourceType = typeof(Resources.Resources))]
        public int User { get; set; }

        [Required(ErrorMessageResourceName = "OrgUnitRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrgUnit", ResourceType = typeof(Resources.Resources))]
        public int Orgunit { get; set; }

        [Display(Name = "Attachements", ResourceType = typeof(Resources.Resources))]
        public IList<HttpPostedFileBase> AssignmentAttachments { get; set; }
    }

    public static class AssignmentModelsHelper
    {
        public static Assignment CreateEntityFromModel(AssignmentModel model)
        {
            Assignment entity = new Assignment();
            entity.AssignmenId = model.AssignmentId;
            entity.AssignedDate = model.AssignedDate;
            entity.ReceivedDate = model.ReceivedDate;
            entity.DueDate = model.DueDate;
            entity.RemindedDate = model.RemindedDate;
            entity.Actions = model.Actions;
            entity.State = model.State;
            return entity;
        }

        public static AssignmentViewModel CreateViewModel(this Assignment entity)
        {
            return new AssignmentViewModel
                       {
                           Actions=entity.Actions,
                           AssignedDate = entity.AssignedDate,
                           AssignmentId = entity.AssignmenId,
                           Correspondence = entity.Correspondence.CorrespondenceId,
                           DueDate = entity.DueDate,
                           Orgunit = entity.Orgunit.Name,
                           ReceivedDate = entity.ReceivedDate,
                           RemindedDate = entity.RemindedDate,
                           State = entity.State,
                           User = entity.User == null ? "" : entity.User.FirstName
                       };
        }

    }

    public class AssignmentViewModel
    {
        [Display(Name = "AssignmentID", ResourceType = typeof(Resources.Resources))]
        public int AssignmentId { get; set; }

        [Display(Name = "AssignedDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "ReceivedDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? ReceivedDate { get; set; }

        [Display(Name = "DueDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? DueDate { get; set; }

        [Display(Name = "RemindedDate", ResourceType = typeof(Resources.Resources))]
        public DateTime? RemindedDate { get; set; }

        [Display(Name = "Actions", ResourceType = typeof(Resources.Resources))]
        public string Actions { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public int? State { get; set; }

        [Display(Name = "TheCorrenspondence", ResourceType = typeof(Resources.Resources))]
        public int Correspondence { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Resources))]
        public string User { get; set; }

        [Display(Name = "OrgUnit", ResourceType = typeof(Resources.Resources))]
        public string Orgunit { get; set; }

    }
}

