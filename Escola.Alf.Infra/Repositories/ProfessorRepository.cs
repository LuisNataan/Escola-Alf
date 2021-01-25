using Escola.Alf.Application;
using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Repositories.GenericRepository;
using Escola.Alf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Escola.Alf.Infra.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(MainContext context) : base(context)
        {
        }

        public override async Task<Professor> GetById(int id)
        {
            return await _dbSet.Include(p => p.Prova)
                .FirstOrDefaultAsync(p => p.Id == id && !p.Deletado);
        }

        public async Task<bool> VerificarProfessor(int id)
        {
            return await Query().AnyAsync(p => p.Id == id && !p.Deletado);
        }
    }
}
