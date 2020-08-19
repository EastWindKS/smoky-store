using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class CompanyUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [MaxLength(250)]
        public string ImgUrl { get; set; }
    }
}