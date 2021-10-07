using System;
using System.Collections.Generic;

namespace DoctorWho.Db.DBModels
{
    public class AuthorDbModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<EpisodeDbModel> Episodes { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
        public AuthorDbModel()
        {
            Episodes = new List<EpisodeDbModel>();
        }
    }
}