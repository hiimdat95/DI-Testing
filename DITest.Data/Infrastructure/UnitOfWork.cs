namespace DITest.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DITestDbContext dbContext;

        private UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory; ;
        }

        public DITestDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}