namespace DoctorWho.Db.Interfaces
{
    public interface IMetadataLogger
    {
        public int SaveChangesWithMetadata(string userId);
    }
}