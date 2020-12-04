using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
    }
}
