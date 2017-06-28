using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class TaxAndProductsRepositoriesTests
    {
        [Test]
        public void TestProductRepositoryLoad()
        {
            IProductRepository prodRepository = ProductRepositoryFactory.Create();
            LoadProductsResponse response = new LoadProductsResponse();
            response = prodRepository.LoadProducts();

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(1, response.ProductList.Count());
        }

        [Test]
        public void TestTaxRepositoryLoad()
        {
            ITaxRepository taxRepository = TaxRepositoryFactory.Create();
            LoadTaxFileResponse response = new LoadTaxFileResponse();
            response = taxRepository.LoadTaxes();

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(1, response.TaxList.Count());
        }
        [Test]
        public void ProdProductRepositoryLoad()
        {
            IProductRepository prodRepository = ProductRepositoryFactory.Create();
            LoadProductsResponse response = new LoadProductsResponse();
            response = prodRepository.LoadProducts();

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(4, response.ProductList.Count());
        }

        [Test]
        public void ProdTaxRepositoryLoad()
        {
            ITaxRepository taxRepository = TaxRepositoryFactory.Create();
            LoadTaxFileResponse response = new LoadTaxFileResponse();
            response = taxRepository.LoadTaxes();

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(4, response.TaxList.Count());
        }


    }
}
