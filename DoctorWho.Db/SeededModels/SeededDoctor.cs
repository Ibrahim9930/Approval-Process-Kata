using System;
using DoctorWho.Db.Domain;

namespace DoctorWho.Db.SeededModels
{
    public class SeededDoctor : Doctor     
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}