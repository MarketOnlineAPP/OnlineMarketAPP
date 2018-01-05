using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market.LojaVirtual.Dominio.Repositorio;
using Market.LojaVirtual.Web.Models;
using Market.LojaVirtual.Web;
using Market.LojaVirtual.Dominio.Entidades;

namespace Market.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3;

        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            IEnumerable<Produto> produtos = null;

            if (categoria == null)
                produtos = _repositorio.Produtos
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina);
            else
                produtos = _repositorio.Produtos
                        .Where(p => p.Categoria == categoria)
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina);

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = produtos,
                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria
            };

            return View("~/Views/Vitrine/ListaProdutos.cshtml", model);
        }
    }
}