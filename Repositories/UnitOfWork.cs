using Evaluation.Interfaces;
using Evaluation.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _Context { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task CompleteAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
