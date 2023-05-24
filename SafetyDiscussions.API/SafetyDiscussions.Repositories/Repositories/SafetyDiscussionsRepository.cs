using SafetyDiscussions.Models.Interfaces;
using SafetyDiscussions.Models.Models;

namespace SafetyDiscussions.Repositories.Repositories
{
    public class SafetyDiscussionsRepository : ISafetyDiscussionsRepository
    {
        private readonly List<SafetyDiscussion> safetyDiscussions;

        // Since we are not using an actual database to test this, we will be implementing a variable for storing the current Id
        private int id = 2;

        public SafetyDiscussionsRepository()
        {
            // Initializing sample data
            this.safetyDiscussions = new List<SafetyDiscussion>()
            {
                new SafetyDiscussion()
                {
                    Id = 1,
                    Observer = "Juan Dela Cruz",
                    DateOfDiscussion = DateTime.Now.AddDays(-5),
                    LocationOfDiscussion = "B4 Board Room",
                    Colleague = "Pedro Pascal",
                    SubjectOfDiscussion = "Fire Evacuation Drill",
                    Outcomes = $@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis 
                                    nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                                    Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
                                    fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in 
                                    culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedDate = DateTime.Now
                },
                new SafetyDiscussion()
                {
                    Id = 2,
                    Observer = "Takeru Sato",
                    DateOfDiscussion = DateTime.Now.AddDays(-7),
                    LocationOfDiscussion = "Pantry Room",
                    Colleague = "Son Chaeyoung",
                    SubjectOfDiscussion = "Earthquake Drill",
                    Outcomes = $@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                                    incididunt ut labore et dolore magna aliqua. Magna fermentum iaculis eu non diam 
                                    phasellus vestibulum. Vitae turpis massa sed elementum tempus egestas. Et ligula 
                                    ullamcorper malesuada proin libero nunc consequat interdum. Auctor elit sed vulputate 
                                    mi sit amet mauris commodo quis. Est ullamcorper eget nulla facilisi. Tellus id 
                                    interdum velit laoreet id donec ultrices tincidunt. Libero enim sed faucibus turpis. 
                                    Sapien et ligula ullamcorper malesuada proin libero nunc consequat interdum. Nibh 
                                    ipsum consequat nisl vel pretium. Fusce ut placerat orci nulla. Eu sem integer vitae 
                                    justo eget magna fermentum iaculis eu. Ut faucibus pulvinar elementum integer enim.",
                    CreatedDate = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<SafetyDiscussion>> GetAll()
        {
            return safetyDiscussions.Where(sd => sd.IsDeleted == false).ToList();
        }

        public async Task<SafetyDiscussion> GetById(int id)
        {
            return safetyDiscussions.FirstOrDefault(sd => sd.Id == id && sd.IsDeleted == false);
        }

        public async Task CreateOrUpdate(SafetyDiscussion safetyDiscussion)
        {
            if(safetyDiscussion.Id != 0)
            {
                await Update(safetyDiscussion);
                return;
            }

            await Create(safetyDiscussion);
        }

        private async Task Create(SafetyDiscussion safetyDiscussion)
        {
            // Creates a new data to be added on the safetyDiscussions list
            safetyDiscussions.Add(new SafetyDiscussion()
            {
                // Since we are not actually using a database and just using placeholders
                // we will get the last element of the List and add 1 to have an ID for new data
                Id = id = id + 1, 
                Observer = safetyDiscussion.Observer,
                DateOfDiscussion = safetyDiscussion.DateOfDiscussion,
                LocationOfDiscussion = safetyDiscussion.LocationOfDiscussion,
                Colleague = safetyDiscussion.Colleague,
                SubjectOfDiscussion = safetyDiscussion.SubjectOfDiscussion,
                Outcomes = safetyDiscussion.Outcomes,
                CreatedDate = DateTime.Now,
            });
        }

        private async Task Update(SafetyDiscussion safetyDiscussion)
        {
            // Updates the existing data or object in the list
            var sd = safetyDiscussions.Where(sd => sd.Id == safetyDiscussion.Id).FirstOrDefault();
            sd.Observer = safetyDiscussion.Observer;
            sd.DateOfDiscussion = safetyDiscussion.DateOfDiscussion;
            sd.LocationOfDiscussion = safetyDiscussion.LocationOfDiscussion;
            sd.Colleague = safetyDiscussion.Colleague;
            sd.SubjectOfDiscussion = safetyDiscussion.SubjectOfDiscussion;
            sd.Outcomes = safetyDiscussion.Outcomes;
            sd.ModifiedDate = DateTime.Now; // Updates the ModifiedDate column
        }

        public async Task DeleteById(int id)
        {
            // Only does SoftDelete
            var safetyDiscussion = safetyDiscussions.FirstOrDefault(sd => sd.Id == id && sd.IsDeleted == false);
            safetyDiscussion.IsDeleted = true;
        }
    }
}
