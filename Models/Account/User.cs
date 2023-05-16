using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace todo_web_app2.Models.Account
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int user_Id { get; set; }
       
        public string user_Name { get; set; }

        
        public string password { get; set; }
        public string branch_Name { get; set; }
        public bool is_Active { get; set; }
        public bool is_Remember { get; set; }
    }
}
