using Mastery.Models;
using Mastery.Models.Interfaces;
using Mastery.Models.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Mastery.BLL
{
    public class OrderManager
    {

        public ProductType Product;

        private IOrderRepository _orderRepository;
       
        public OrderManager(IOrderRepository orderRepository) //The OrderManager requires an iOrderRepository
        {
            _orderRepository = orderRepository;
        }

        private ITaxInfoRepository _taxInfoRepository;

        public OrderManager(ITaxInfoRepository taxInfoRepository) //The OrderManager requires an iTaxInforRepository
        {
            _taxInfoRepository = taxInfoRepository;
        }

        public OrdersLookupResponse LookUpOrders(string Date)
        {
            OrdersLookupResponse response = new OrdersLookupResponse();

            response.Orders = _orderRepository.LoadOrders(Date);

            if(response.Orders == null)
            {
                response.Success = false;
                response.Message = $"No orders could be found on {Date}.";
            }

            else
            {
                response.Success = true;
            }

            return response;
        }

        public OrderDeleteResponse DeleteOrder(string date, int OrderNumber)//Note that this is reverse logic, we do not want to find order after deleting.
        {
            OrderDeleteResponse response = new OrderDeleteResponse();

            response.Order = _orderRepository.DeleteOrder(date,OrderNumber);

            if (response.Order == null)
            {
                response.Success = true;
            }

            else
            {
                response.Success = false;
                response.Message = $"This order number could not be found on {date}.";
            }

            return response;
        }

        public OrderEditResponse EditOrder(Order order)
        {
            OrderEditResponse response = new OrderEditResponse();

            response.Order = _orderRepository.EditOrder(order);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"This order number could be found on {order.Date}.";
            }

            else
            {
                response.Success = true;
            }

            return response;
        }

        public OrderLookupResponse LookUpOrder(string Date, int OrderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(Date, OrderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"No orders could be found on {Date}.";
            }

            else
            {
                response.Success = true;
            }

            return response;
        }

        public OrderAddResponse AddOrder(Order order)                                 
        {
            OrderAddResponse response = new OrderAddResponse();

            response.Order = _orderRepository.AddOrder(order);
                                                         
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"The system was unable to add your order, please contact IT.";
            }

            else
            {
                response.Success = true;
            }

            return response; 
        }

        public OrderAddResponse GetTaxRate(string State)
        {
            OrderAddResponse response = new OrderAddResponse();

            try
            {
                List<TaxInfo> TaxData = _taxInfoRepository.GetAll();

                TaxInfo foundInfo = TaxData.FirstOrDefault(t => t.StateAbbreviation == State);

                decimal TaxRate = foundInfo.TaxRate;

                if (TaxRate == 0)
                {
                    response.Success = false;
                    response.Message = "Invalid Tax rate";
                    return response;
                }
                else
                {
                    response.Success = true;
                    return response;
                }

            }
            catch
            {
                response.Success = false;
                response.Message = $"The system was unable to access the tax data, please contact IT.";
            }
            
                response.Success = true;
                return response;
        }

    }
}
