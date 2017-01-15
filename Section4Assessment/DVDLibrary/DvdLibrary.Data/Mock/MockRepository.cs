using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Tables;

namespace DvdLibrary.Data.Mock
{
    public class MockRepository : IDvdsRepository
    {
        
        public void DeleteDvdId(int dvdId)
        {
            throw new NotImplementedException();
        }

        public Dvds GetDvdId(int dvdId)
        {

            Dvds dvd = new Dvds();

            if (dvdId == 1)
            {
                dvd.dvdId = 1;
                dvd.title = "A Great Tale";
                dvd.releaseYear = "2015";
                dvd.director = "Sam Jones";
                dvd.rating = "PG";
                dvd.notes = "X";
            }

            return dvd;
        }

        public List<Dvds> GetDvds()
        {
            throw new NotImplementedException();
        }

        public List<Dvds> GetDvdsDirector(string director)
        {
            throw new NotImplementedException();
        }

        public List<Dvds> GetDvdsRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvds> GetDvdsTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Dvds> GetDvdsYear(string releaseYear)
        {
            throw new NotImplementedException();
        }

        public void PostDvd(Dvds dvd)
        {
            throw new NotImplementedException();
        }

        public void UpdateDvdId(Dvds dvd)
        {
            throw new NotImplementedException();
        }
    }
}
