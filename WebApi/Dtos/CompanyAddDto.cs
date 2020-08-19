using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class CompanyAddDto
    {
        public string CompanyName { get; set; }

        public string ImgUrl { get; set; }
        public string[] Strengths { get; set; }
        public string Valera { get; set; }
    }
}