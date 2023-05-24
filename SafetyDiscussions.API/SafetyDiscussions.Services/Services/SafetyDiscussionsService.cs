using AutoMapper;
using SafetyDiscussions.Models.Interfaces;
using SafetyDiscussions.Models.Models;
using SafetyDiscussions.Services.DTO;
using SafetyDiscussions.Services.Interfaces;

namespace SafetyDiscussions.Services.Services
{
    public class SafetyDiscussionsService : ISafetyDiscussionsService
    {
        private readonly ISafetyDiscussionsRepository safetyDiscussionsRepository;
        private readonly IMapper mapper;

        public SafetyDiscussionsService(
            ISafetyDiscussionsRepository safetyDiscussionsRepository,
            IMapper mapper)
        {
            this.safetyDiscussionsRepository = safetyDiscussionsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SafetyDiscussionDTO>> GetAll()
        {
            var listOfSDs = await safetyDiscussionsRepository.GetAll();
            return mapper.Map<IEnumerable<SafetyDiscussionDTO>>(listOfSDs);
        }

        public async Task<SafetyDiscussionDTO> GetById(int id)
        {
            var sd = await safetyDiscussionsRepository.GetById(id);
            return mapper.Map<SafetyDiscussionDTO>(sd);
        }

        public async Task CreateOrUpdate(SafetyDiscussionDTO safetyDiscussion)
        {
            var sd = mapper.Map<SafetyDiscussion>(safetyDiscussion);
            await safetyDiscussionsRepository.CreateOrUpdate(sd);
        }

        public async Task DeleteById(int id)
        {
            await safetyDiscussionsRepository.DeleteById(id);
        }
    }
}
