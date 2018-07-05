namespace DITest.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DITestDbContext dbContext;

        public DITestDbContext Init()
        {
            return dbContext ?? (dbContext = new DITestDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}