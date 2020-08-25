using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class CompanyUpdateDto
    {
       
        public string CompanyName { get; set; }
        
        public string ImgUrl { get; set; }
    }
}