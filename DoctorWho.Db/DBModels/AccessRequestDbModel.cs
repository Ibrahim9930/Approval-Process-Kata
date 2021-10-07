using System;
using DoctorWho.Db.Access;

namespace DoctorWho.Db.DBModels
{
    public class AccessRequestDbModel
    {
        public int RequestId { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ApprovalStatus Status { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}