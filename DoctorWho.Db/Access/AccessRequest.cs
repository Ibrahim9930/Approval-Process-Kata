using System;

namespace DoctorWho.Db.Access
{
    public class AccessRequest
    {
        public int RequestId { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}