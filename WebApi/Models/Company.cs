using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("Companies", Schema = "Tobacco")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(250)]
        public string ImgUrl { get; set; }
       
    }
}
