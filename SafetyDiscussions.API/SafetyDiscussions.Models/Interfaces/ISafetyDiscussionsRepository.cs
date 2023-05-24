using SafetyDiscussions.Models.Models;

namespace SafetyDiscussions.Models.Interfaces
{
    public interface ISafetyDiscussionsRepository
    {
        public Task<IEnumerable<SafetyDiscussion>> GetAll();

        public Task<SafetyDiscussion> GetById(int id);

        public Task CreateOrUpdate(SafetyDiscussion safetyDiscussion);

        public Task DeleteById(int id);
    }
}
