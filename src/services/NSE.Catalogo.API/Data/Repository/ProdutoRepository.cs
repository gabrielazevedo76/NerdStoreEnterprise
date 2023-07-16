using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;

namespace NSE.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.produtos.AsNoTracking().ToListAsync();
        }
        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
