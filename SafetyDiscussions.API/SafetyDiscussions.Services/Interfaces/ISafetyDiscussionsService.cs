using SafetyDiscussions.Models.Models;
using SafetyDiscussions.Services.DTO;

namespace SafetyDiscussions.Services.Interfaces
{
    public interface ISafetyDiscussionsService
    {
        public Task<IEnumerable<SafetyDiscussionDTO>> GetAll();

        public Task<SafetyDiscussionDTO> GetById(int id);

        public Task CreateOrUpdate(SafetyDiscussionDTO safetyDiscussion);

        public Task DeleteById(int id);
    }
}
