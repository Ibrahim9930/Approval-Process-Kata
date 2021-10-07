using System;
using System.Collections.Generic;

namespace DoctorWho.Db.DBModels
{
    public class CompanionDbModel
    {
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public int WhoPlayed { get; set; }
        public ICollection<EpisodeDbModel> Episodes { get; set; }

        
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
        
        public CompanionDbModel()
        {
            Episodes = new List<EpisodeDbModel>();
        }
    }
}