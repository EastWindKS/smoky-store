using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

    [Table("Logins", Schema = "Admin")]
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
