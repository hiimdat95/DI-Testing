using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITest.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DITestDbContext Init();
    }
}
