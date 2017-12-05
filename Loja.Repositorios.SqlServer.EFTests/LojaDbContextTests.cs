using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Dominio;
using System.Diagnostics;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _db = new LojaDbContext();

        [ClassInitialize]
        public static void InicializarTestes(TestContext contexto)
        {
            _db.Database.Log = LogarQueries;
        }

        private static void LogarQueries(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirPapelariaTest()
        {
            using (var db = new LojaDbContext())
            {
                var papelaria = new Categoria();
                papelaria.Nome = "Papelaria";

                db.Categorias.Add(papelaria);

                db.SaveChanges();
            }
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var caneta = new Produto();
            caneta.Estoque = 5;
            caneta.Nome = "Caneta";
            caneta.Preco = 22.06m;
            caneta.Categoria = _db.Categorias
                .Where(c => c.Nome == "Papelaria").Single();

            _db.Produtos.Add(caneta);
            _db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var barbeador = new Produto();
            barbeador.Nome = "Barbeador";
            barbeador.Estoque = 33;
            barbeador.Preco = 22.34m;
            barbeador.Categoria = new Categoria { Nome = "Perfumaria" };

            _db.Produtos.Add(barbeador);
            _db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {
            var caneta = _db.Produtos.First(p => p.Nome == "Caneta");
            caneta.Preco = 51;
            _db.SaveChanges();
        }

        [ClassCleanup]
        public static void FinalizarTestes()
        {
            _db.Dispose();
        }
    }
}