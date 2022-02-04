using GerenciadorSJD.Data;
using GerenciadorSJD.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorSJD.Service
{
    public class ServiceProcesso
    {
        private readonly GerenciadorSJDContext _context;

        public ServiceProcesso(GerenciadorSJDContext context)
        {
            _context = context;
        }

        public async Task<List<Processo>> RetornarTodosAsync()
        {
            return await _context.Processo.OrderBy(x => x.Numero).ToListAsync();
        }
    }
}
