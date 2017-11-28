namespace Data
{
    using Data.Models;
    using System.Data.Entity;

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
