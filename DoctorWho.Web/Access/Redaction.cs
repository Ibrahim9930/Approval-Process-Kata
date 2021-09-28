using DoctorWho.Db.Domain;

namespace DoctorWho.Web.Access
{
    public static class Redaction
    {
        public static void Redact(this Doctor doc)
        {
            doc.DoctorName = "Redacted";
        }

        public static void Redact(this Episode ep)
        {
            ep.Title = "Redacted";
        }
    }
}