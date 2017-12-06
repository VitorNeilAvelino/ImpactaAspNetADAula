﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;
using System.Linq;

namespace Loja.Repositorios.SqlServer.EF
{
    //pg 191
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Categorias.AddRange(ObterCategorias());
            context.SaveChanges();

            context.Produtos.AddRange(ObterProdutos(context));
            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos(LojaDbContext context)
        {
            var grampeador = new Produto();
            grampeador.Ativo = false;
            grampeador.Estoque = 44;
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 21.44m;
            grampeador.Categoria = context
                                                    .Categorias.Single(c => c.Nome == "Papelaria");

            var penDrive = new Produto();
            penDrive.Ativo = false;
            penDrive.Estoque = 49;
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 21.49m;
            penDrive.Categoria = context
                                                    .Categorias.Single(c => c.Nome == "Informática");

            return new List<Produto> { grampeador, penDrive };
        }

        private IEnumerable<Categoria> ObterCategorias()
        {
            return new List<Categoria>
            {
                new Categoria { Nome = "Papelaria" },
                new Categoria { Nome = "Informática" }
            };
        }
    }
}