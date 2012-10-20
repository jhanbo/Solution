using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Domain;

namespace ITGateWorkDesk.Web.Mvc.Models
{
    public class CreateUserModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Middle Name")]
        public string MiddleName { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { set; get; }

        
        [DataType(DataType.Text)]
        [Display(Name = "GF Name")]
        public string GFname { set; get; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "the password and confirmation must be matched")]
        public string PasswordConfirm { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Phone Num")]
        public string Phone { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Cell Phone Num")]
        public string CellPhone { set; get; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { set; get; }

        

        [Required]
        public int OrganizationUnitID { set; get; }

        
        [DataType(DataType.Date)]
        [Display(Name="Birth Date")]
        public string BirthDate { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public string JoinDate { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Notes")]
        public string Notes { set; get; }




        
    }
}