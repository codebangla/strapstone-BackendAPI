
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyLogoUrl { get; set; }
        public string? Description { get; set; }
        public string? Requirement { get; set; }
        public string? Qualification { get; set; }
        public string? Offer { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }



    }
}
