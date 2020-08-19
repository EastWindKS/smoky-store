using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Products", Schema = "Tobacco")]
    public class TobaccoProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string Flavor { get; set; }
        public int LineId { get; set; }
        public int CompanyId { get; set; }
        public string ProductDescription { get; set; }
        public string ImgUrl { get; set; }
    }
}