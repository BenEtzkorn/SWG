using Mastery.Data;
using Mastery.Models;
using Mastery.Models.Interfaces;
using MasteryTests;
using MasteryTests.Mock_Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace OrderIntegrationTests
{

    [TestFixture]

    public class FileSystemTest
    {
        [Test]

        public void CanReadTaxFile()
        {
            TaxInfoMockRepository repo = new TaxInfoMockRepository();

            List<TaxInfo> TaxData = repo.GetAll();

            Assert.IsTrue(TaxData.Count > 0);

        }

        [Test]

        [TestCase("OH", 10)]
        [TestCase("WI", 0)]

        public void CanGetTaxRate(string State, decimal Assertion)
        {

            string _state = State;

            TaxInfoMockRepository repo = new TaxInfoMockRepository();

            decimal rate = repo.GetTaxRate(_state);

            Assert.IsTrue(rate == Assertion);

        }


        [Test]

        [TestCase("08012016", 1)]

        public void CanLoadOrderRepository(string Date, int OrderNumber)
        {
            OrderMockRepository repo = new OrderMockRepository();

            Order order = repo.LoadOrder(Date, OrderNumber);

            Assert.AreEqual(Date, order.Date);
        }

        [Test]

        [TestCase("08012016", 1)]
        [TestCase("09012016", 0)]
        [TestCase("08032016", 2)]

        public void CanLoadOrdersRepository(string Date, int Count)
        {

            string _date = Date;

            int _count = Count;

            int x;

            OrderMockRepository repo = new OrderMockRepository();

            List<Order> orders = new List<Order>();
                
            orders = repo.LoadOrders(_date);

            try
            {

                var items = orders.FindAll(t => t.Date == Date);

                x = items.Count;
            }
            catch
            {
                x = 0;
            }

            Assert.AreEqual(_count, x);
        }

        [Test]

        [TestCase("OH", true)]
        [TestCase("WI", false)]

        public void CanCheckState(string State, bool Anticipated)
        {
            string _state = State;

            TaxFileRepository repo = new TaxFileRepository();

            bool result = repo.CheckState(_state);

            Assert.AreEqual(result, Anticipated);
        }

        [Test]

        [TestCase("DC, IN, MI, MN, OH, PA")]
        
        public void CanGetStateList(string List)
        {
            string _list = List;

            TaxFileRepository repo = new TaxFileRepository();
            string result = repo.GetStateList();

            Assert.AreEqual(_list, result);
        }

        [Test]

        [TestCase(ProductType.Carpet,"Cost",2.00)]
        [TestCase(ProductType.Laminate, "Labor",3.00)]

        public void CanGetCosts(ProductType Material, string Type, decimal Anticipated)
        {
            ProductType _material = Material;
            string _type = Type;
            
            ProductInfoMockRepository repo = new ProductInfoMockRepository();

            decimal result = repo.GetCostPerSquareFoot(_material, _type);

            Assert.AreEqual(Anticipated, result);
        }


    }
}
