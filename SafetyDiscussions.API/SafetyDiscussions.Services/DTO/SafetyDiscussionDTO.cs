using System.ComponentModel.DataAnnotations;

namespace SafetyDiscussions.Services.DTO
{
    public class SafetyDiscussionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Observer { get; set; }

        [Required]
        public DateTime DateOfDiscussion { get; set; }

        [Required]
        public string LocationOfDiscussion { get; set; }

        [Required]
        public string Colleague { get; set; }

        [Required]
        public string SubjectOfDiscussion { get; set; }

        [Required]
        public string Outcomes { get; set; }
    }
}
