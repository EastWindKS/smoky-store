using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Strengths", Schema = "Tobacco")]
    public class Strength
    {
        [Key]
        public int StrId { get; set; }
        public string StrName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}