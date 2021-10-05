using System;
using System.Collections.Generic;

namespace DoctorWho.Db.DBModels
{
    public class EpisodeDbModel
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime? EpisodeDate { get; set; }
        public string Notes { get; set; }

        public ICollection<EnemyDbModel> Enemies { get; set; }
        public ICollection<CompanionDbModel> Companions { get; set; }

        public int AuthorId { get; set; }
        public AuthorDbModel Author { get; set; }

        public int DoctorId { get; set; }
        public DoctorDbModel Doctor { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
        public EpisodeDbModel()
        {
            Enemies = new List<EnemyDbModel>();
            Companions = new List<CompanionDbModel>();
        }
    }
}