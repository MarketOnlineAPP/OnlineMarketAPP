﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Market.LojaVirtual.Dominio.Entidades;

namespace Market.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {

        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }
    }
}