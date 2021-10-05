using System;
using System.Collections.Generic;

namespace DoctorWho.Db.DBModels
{
    public class EnemyDbModel
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public ICollection<EpisodeDbModel> Episodes { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
        public EnemyDbModel()
        {
            Episodes = new List<EpisodeDbModel>();
        }
    }
}