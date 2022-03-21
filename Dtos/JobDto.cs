using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class JobDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Title is mandatory field")] 
        public string title { get; set; }

        [Required]
        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "company_address")]
        public string CompanyAddress { get; set; }

        [Required]
        [JsonProperty(PropertyName = "company_logo_url")]
        public string CompanyLogoUrl { get; set; }

        public string? description { get; set; }
        public string? requirement { get; set; }
        public string? qualification { get; set; }
        public string? offer { get; set; }

        public int cityId { get; set; }

        public int userId { get; set; }

    }
}
