using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.BLL
{
    public class RepositoryManager
    {
        private IDvdsRepository _DvdRepository;

        public RepositoryManager(IDvdsRepository DvdRepository)
        {
            _DvdRepository = DvdRepository;
        }
    }
}
