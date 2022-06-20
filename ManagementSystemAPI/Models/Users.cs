using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Models
{
    public class Users
    {
        [Key]
        public int users_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string detail_type { get; set; }
        public bool is_active { get; set; }
        [NotMapped]
        public string token { get; set; }
        public Users(Users users, string token)
        {
            users_id = users.users_id;
            detail_type = users.detail_type;
            password = users.password;
            is_active = users.is_active;
            username = users.username;
            email = users.email;
            this.token = token;
        }
        public Users()
        {

        }

    }
}
