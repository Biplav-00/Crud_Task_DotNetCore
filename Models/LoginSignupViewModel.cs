using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace todo_web_app2.Models
{
    public class LoginSignupViewModel
    {
        public int user_Id { get; set; }
        [Display(Name = "User Name")]
        
        public string user_Name { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        public string confirm_Password { get; set; }
        [Display(Name ="Branch Name")]
        public string branch_Name { get; set; }
        public bool is_Active { get; set; }
        public bool is_Remember { get; set; }
    }
}
