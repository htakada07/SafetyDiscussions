using AutoMapper;
using SafetyDiscussions.Models.Models;
using SafetyDiscussions.Services.DTO;

namespace SafetyDiscussions.Services.AutoMapper
{
    public class SafetyDiscussionMapper : Profile
    {
        public SafetyDiscussionMapper()
        {
            // For mapping of DTO to Model and vice versa
            CreateMap<SafetyDiscussion, SafetyDiscussionDTO>().ReverseMap();
        }
    }
}
