using Mastery.BLL;
using Mastery.Models;
using Mastery.Models.Responses;
using MasteryTests;
using NUnit.Framework;

namespace OrderUnitTests
{
    [TestFixture]
    public class OrderUnitTests
    {
        [Test]

        [TestCase("08012016", 1, true)]
        [TestCase("09012016", 3, false)]

        public void CanLoadOrderTestData(string Date, int OrderNumber, bool expectedResult)
        {
            OrderManager om = new OrderManager(new OrderMockRepository());  //Arrange

            OrderLookupResponse response = om.LookUpOrder(Date, OrderNumber);  //Act
            bool actualResult = response.Success;

            Assert.AreEqual(expectedResult, actualResult);//Assert

        }

        [Test]

        [TestCase("08012016", true)]
        [TestCase("09012016", false)]

        public void CanLoadOrdersTestData(string Date, bool expectedResult)
        {
            OrderManager om = new OrderManager(new OrderMockRepository());  //Arrange

            OrdersLookupResponse response = om.LookUpOrders(Date);  //Act
            bool actualResult = response.Success;

            Assert.AreEqual(expectedResult, actualResult);//Assert

        }

        [Test]

        [TestCase("08012016", true)]
       
        public void OrderAddTest(string Date, bool expectedResult)
        {

            Order _order = new Order()
                {
                
                    Date = "08012016",
                    OrderNumber = 1,
                    CustomerName = "Wise",
                    State = "OH",
                    TaxRate = 5.75M,
                    Product = ProductType.Wood,
                    Area = 100.00M,
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,

                };

            OrderManager om = new OrderManager(new OrderMockRepository());  //Arrange

            OrderAddResponse response = om.AddOrder(_order);  //Act
            bool actualResult = response.Success;

            Assert.AreEqual(expectedResult, actualResult);//Assert

        }

        [Test]

        [TestCase("08012016", 1, false)]
        [TestCase("09012016", 3, true)]

        public void OrderDeleteTest(string Date, int OrderNumber, bool expectedResult)
        {
            OrderManager om = new OrderManager(new OrderMockRepository());  //Arrange

            OrderDeleteResponse response = om.DeleteOrder(Date,OrderNumber);  //Act
            bool actualResult = response.Success;

            Assert.AreEqual(expectedResult, actualResult);//Assert

        }

        [Test]

        public void OrderCalcualtionTest()
        {
            Order order = new Order();  //Arrange

            order.Area = 100;
            order.CostPerSquareFoot = 1;
            order.LaborCostPerSquareFoot = 1;
            order.TaxRate = 10;
          
            Assert.AreEqual(100, order.MaterialCost);//Assert
            Assert.AreEqual(100, order.LaborCost);//Assert
            Assert.AreEqual(20, order.Tax);//Assert
            Assert.AreEqual(220, order.Total);//Assert

        }

        [Test]
        public void OrderManagerRejectsInvalidTax()
        {
            OrderManager om = new OrderManager(new TaxInfoMockRepository());//Arrange

            Response result = om.GetTaxRate("OH");//Act

            Assert.AreNotEqual(5M,result);//Assert
        }

        [Test]

        [TestCase("08012016", 1, true)]
        [TestCase("09012016", 3, false)]

        public void OrderEditTest(string Date, int OrderNumber, bool expectedResult)
        {
            string _date = Date;

            Order _order = new Order()
            {

                Date = _date,
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 5.75M,
                Product = ProductType.Wood,
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,

            };

            OrderManager om = new OrderManager(new OrderMockRepository());  //Arrange

            OrderEditResponse response = om.EditOrder(_order);  //Act
            bool actualResult = response.Success;

            Assert.AreEqual(expectedResult, actualResult);//Assert

        }
    }
}
