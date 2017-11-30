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
    public class TransportadoraRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var repositorio = new TransportadoraRepositorio();

            var transportadoras = repositorio.Selecionar();

            Assert.AreNotEqual(0, transportadoras.Count);

            foreach (var transportadora in transportadoras)
            {
                Console.WriteLine($"{transportadora.Nome} - {transportadora.Telefone}");
            }
        }
    }
}