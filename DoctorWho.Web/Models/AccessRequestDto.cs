using System;
using DoctorWho.Db.Access;

namespace DoctorWho.Web.Models
{
    public class AccessRequestDto
    {
        public string AccessLevel { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
    }
}