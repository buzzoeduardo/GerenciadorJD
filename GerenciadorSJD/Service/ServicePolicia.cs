using GerenciadorSJD.Data;
using GerenciadorSJD.Models;
using GerenciadorSJD.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorSJD.Service
{
    public class ServicePolicia
    {
        private readonly GerenciadorSJDContext _context;

        public ServicePolicia(GerenciadorSJDContext context)
        {
            _context = context;
        }

        // Retornar uma lista com todos os policiais
        public async Task<List<Policia>> RetornarTodos()
        {
            return await _context.Policia.ToListAsync();
        }

        // Retornar Todos por ID
        public async Task<Policia> RetornarPolicialIdAsync(int id)
        {
            //Include(obj => obj.ProcessoId)
            return await _context.Policia.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Retornar uma lista através do Re ou Nome
        public async Task<List<Policia>> PesquisarReNomeAsync(string re)
        {
            var resultado = from obj in _context.Policia select obj;

            if (!String.IsNullOrEmpty(re))
            {
                resultado = resultado.Where(x => x.Re.Contains(re) || x.Nome.Contains(re));
            }
           
            return await resultado.ToListAsync();
        }

        // Inserir um novo PM na base de dados
        public async Task InserirAsync(Policia pm)
        {
            
            if (!_context.Policia.Any(x => x.Re == pm.Re))
            {
                try
                {
                    _context.Add(pm);
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    throw new ExcBd(ex.Message);
                }
            }
            else
            {
                throw new ExcNotFound("Esse RE já existe na base de dados.");
            }
        }

        // Remover um PM da base de dados
        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = await _context.Policia.FindAsync(id);
                _context.Policia.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new ExcIntegridade("Esse Oficial Possui Procedimento/Processo em sua posse.");
            }            
        }

        // Editar um PM da base de dados
        public async Task EditarAsync(Policia pm)
        {
            if (!_context.Policia.Any(x => x.Id == pm.Id))
            {
                throw new ExcNotFound("Esse Id não existe no banco de dados.");
            }
            try
            {
                if (!_context.Policia.Any(x => x.Re == pm.Re))
                {
                    try
                    {
                        _context.Update(pm);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException e)
                    {
                        throw new ExcBd(e.Message);
                    }
                }
                else
                {
                    throw new ExcNotFound("Esse RE já existe na base de dados.");
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ExcBd(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Policia.FindAsync(id);
                _context.Policia.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new ExcIntegridade("O Policial não podeser removido. Esse Policial está incluso em um ou vários Processos/Procedimentos.");
            }            
        }

    }
}
