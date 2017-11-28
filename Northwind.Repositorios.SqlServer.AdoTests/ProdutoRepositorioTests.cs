using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        [TestMethod()]
        public void SelecionarPorCategoriaTest()
        {
            var repositorio = new ProdutoRepositorio();

            var produtoDataTable = repositorio.SelecionarPorCategoria(1);

            Assert.AreNotEqual(0, produtoDataTable.Rows.Count);
        }
    }
}