using System;
using DoctorWho.Db.Access;

namespace DoctorWho.Db.SeededModels
{
    public class SeededAccessRequest : AccessRequest
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}