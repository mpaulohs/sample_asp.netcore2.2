using demo.Domain.Interfaces;
using demo.Infra.Data.Context;

namespace demo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoContext _context;

        public UnitOfWork(DemoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
