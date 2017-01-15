using Mastery.Data;
using System;
using System.Configuration;

namespace Mastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
     
                switch(mode)
                {
                //case "OrderTest":
                 //   return new OrderManager(new OrderTestRepository());
                case "OrderLive":
                    string datapath = ConfigurationManager.AppSettings["DataPath"].ToString();
                    return new OrderManager(new OrderRepository(datapath));
                default:
                    throw new Exception("Mode value in App.Config is not valid");
                }
        }
    }
}
