using System.ComponentModel.DataAnnotations;

namespace SafetyDiscussions.Models.Models
{
    public class SafetyDiscussion
    {
        public int Id { get; set; }

        public string Observer { get; set; }

        public DateTime DateOfDiscussion { get; set; }

        public string LocationOfDiscussion { get; set; }

        public string Colleague { get; set; }

        public string SubjectOfDiscussion { get; set; }

        public string Outcomes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
