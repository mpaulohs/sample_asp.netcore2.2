using SampleOneDDD.Domain.Interfaces;
using SampleOneDDD.Infra.Data.Context;

namespace SampleOneDDD.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleOneDDDContext _context;

        public UnitOfWork(SampleOneDDDContext context)
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
