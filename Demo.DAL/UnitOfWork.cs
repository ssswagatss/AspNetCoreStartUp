using Demo.DAL.Interfaces;
using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DemoContext _context;

        public UnitOfWork(DemoContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
