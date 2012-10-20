using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Domain;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class CreatePermissionModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Name")]
        public string Name { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Code")]
        public string Code { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Description")]
        public string Description { set; get; }

    }

    public class EditPermissionModel
    {

        [Display(Name = "Permission ID")]
        public int PermissionID { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Name")]
        public string Name { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Code")]
        public string Code { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Description")]
        public string Description { set; get; }

    }
}
