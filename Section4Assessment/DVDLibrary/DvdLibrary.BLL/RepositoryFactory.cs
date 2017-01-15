using DvdLibrary.Data.ADO;
using DvdLibrary.Data.Mock;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.BLL
{
    public static class RepositoryFactory
    {
        public static RepositoryManager Create()
        {
            //

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Mock":
                    return new RepositoryManager(new MockRepository());
                case "ADO":
                    return new RepositoryManager(new ADORepository());
                //case "EF":
                    //return new RepositoryManager(new EFRepository());
                default:
                    return new RepositoryManager(new ADORepository());
            }
        }
    }
}
