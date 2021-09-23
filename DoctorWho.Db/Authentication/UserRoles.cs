using Microsoft.AspNetCore.Identity;

namespace DoctorWho.Db.Authentication
{


    public enum UserRoles
    {
        User,
        Approver,
        Auditor,
        Admin
    }
}