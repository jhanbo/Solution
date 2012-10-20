using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class SystemSettingsModel
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "SettingsName", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required]
        [Display(Name = "SettingsValue", ResourceType = typeof(Resources.Resources))]
        public string Value { get; set; }
    }
}