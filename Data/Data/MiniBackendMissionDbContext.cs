namespace Data
{
    using System.Data.Entity;

    using Data.Models;

    public class MiniBackendMissionDbContext : DbContext
    {
        public MiniBackendMissionDbContext() 
            : base("MiniBackendMissionDb")
        {
        }

        public IDbSet<NobelPrizeWinner> NobelPrizeWinners { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
