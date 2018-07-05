using System;

namespace DITest.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DITestDbContext Init();
    }
}