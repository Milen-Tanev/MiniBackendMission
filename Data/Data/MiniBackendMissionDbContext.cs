namespace Data
{
    using System.Data.Entity;

    public class MiniBackendMissionDbContext : DbContext
    {
        public MiniBackendMissionDbContext() 
            : base("MiniBackendMissionDb")
        {
        }
    }
}
