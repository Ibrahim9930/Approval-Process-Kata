using System;
using System.Collections.Generic;

namespace DoctorWho.Db.DBModels
{
    public class DoctorDbModel
    {
        public int DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
        public ICollection<EpisodeDbModel> Episodes { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
        public DoctorDbModel()
        {
            Episodes = new List<EpisodeDbModel>();
        }
        
        
    }
}