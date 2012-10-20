using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITGateWorkDesk.Data.Domain;
using System.ComponentModel.DataAnnotations;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class OrgunitModel
    {
        [Display(Name = "OrgUnitID", ResourceType = typeof(Resources.Resources))]
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "OrgUnitNameErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrgUnitName", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "OrgUnitCodeErrorMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrgUnitCode", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }

        [Display(Name = "OrgUnitType", ResourceType = typeof(Resources.Resources))]
        public int OrganizationType { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resources.Resources))]
        public string Phone { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(Resources.Resources))]
        public string Fax { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "OrgUnitChildren", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<OrgunitModel> Children { get; set; }

        [Display(Name = "OrgUnitParent", ResourceType = typeof(Resources.Resources))]
        public int? Parent { get; set; }
    }

    public static class OrgunitModelsHelper
    {
        public static OrganizationUnit CreateEntity(this OrgunitModel model)
        {
            if (model == null) { return null; }
            OrganizationUnit organization = new OrganizationUnit
                                                {
                                                    IdOrgUnit = model.ID,
                                                    Name = model.Name,
                                                    Notes = model.Notes,
                                                    OrganizationType = model.OrganizationType,
                                                    Code = model.Code,
                                                    Email = model.Email,
                                                    Fax = model.Fax,
                                                    Phone = model.Phone
                                                };
            return organization;
        }

        public static OrgunitModel CreateModel(this OrganizationUnit entity)
        {
            OrgunitModel model = new OrgunitModel
                                     {
                                         Code = entity.Code,
                                         Email = entity.Email,
                                         Fax = entity.Fax,
                                         ID = entity.IdOrgUnit,
                                         Name = entity.Name,
                                         Notes = entity.Notes,
                                         OrganizationType = entity.OrganizationType,
                                         Phone = entity.Phone,
                                         Parent = entity.Parent == null ? (int?)null : entity.Parent.IdOrgUnit,
                                         Children = entity.OrgUnits == null ? new List<OrgunitModel>() : entity.OrgUnits.Select(o => o.CreateModel())
                                     };
            return model;
        }
    }
}