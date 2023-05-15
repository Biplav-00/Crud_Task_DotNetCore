using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_web_app2.Models
{
    public class Person
    {
        [Key]
        [Display(Name ="S.N")]
        public int person_Id { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        //[Display(Name ="Name")]
        public string person_Name { get; set; }


        [Display(Name ="Status")]
        public Boolean is_Active { get; set; }

        //
        //[Required(ErrorMessage = "Required *")]
       
        public int dev_Id { get; set; }

        [Display(Name = "Name")]
        [NotMapped]
        public string device_Name { get; set; }
    }
}
