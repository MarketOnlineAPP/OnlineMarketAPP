using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.LojaVirtual.Dominio;
using Market.LojaVirtual.Dominio.Entidades;

namespace Market.LojaVirtual.Dominio.Repositorio
{
    class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }
    }
}
