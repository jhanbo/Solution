using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class CreateRoleModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Role Description")]
        public string Description { get; set; }

    }

    

}