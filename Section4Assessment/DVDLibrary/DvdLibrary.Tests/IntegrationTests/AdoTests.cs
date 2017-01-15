using DvdLibrary.Data.ADO;
using DvdLibrary.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Tests.IntegrationTest
{
    [TestFixture]
    public class AdoTests
    {
        //DANGER, SETUP WIPES OUT ENTIRE DATABASE

        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void canloadDvd()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvd = repo.GetDvdId(1);

            Assert.AreEqual("A Great Tale", Dvd.title);

        }

        [Test]
        public void canloadDvds()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvds();

            Assert.AreEqual(7, Dvds.Count);

        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo = new DvdLibraryRepositoryADO();
            var Dvds = repo.GetDvdId(100000);

            Assert.IsNull(Dvds);
        }

        [Test]
        public void CanGetDvdsDirectors()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsDirector("Joe Smith");

            Assert.AreEqual(2, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsDirector()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsDirector("Lyle Smith");

            Assert.AreEqual(1, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsRatings()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsRating("PG-13");

            Assert.AreEqual(2, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsRating()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsRating("X");

            Assert.AreEqual(1, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsTitles()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsTitle("A Title Test");

            Assert.AreEqual(2, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsTitle()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsTitle("A Good Tale");

            Assert.AreEqual(1, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsYears()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsYear("2012");

            Assert.AreEqual(2, Dvds.Count);

        }

        [Test]
        public void CanGetDvdsYear()
        {
            var repo = new DvdLibraryRepositoryADO();

            var Dvds = repo.GetDvdsYear("2010");

            Assert.AreEqual(1, Dvds.Count);

        }

        [Test]
        public void CanPostDvd()
        {
            Dvds dvd = new Dvds();
            var repo = new DvdLibraryRepositoryADO();

            dvd.title = "A new movie added";
            dvd.releaseYear = "1999";
            dvd.director = "Prince";
            dvd.rating = "R";
            dvd.notes = "This is an attempt to post a dvd";

            repo.PostDvd(dvd);

            Assert.AreEqual(8, dvd.dvdId);

        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvds dvd = new Dvds();
            var repo = new DvdLibraryRepositoryADO();

            dvd.title = "A new movie added";
            dvd.releaseYear = "1999";
            dvd.director = "Prince";
            dvd.rating = "R";
            dvd.notes = "This is an attempt to post a dvd";

            repo.PostDvd(dvd);

            dvd.title = "An updated movie";
            dvd.releaseYear = "2000";
            dvd.director = "Prince";
            dvd.rating = "X";
            dvd.notes = "This is an attempt to update a dvd";

            repo.UpdateDvdId(dvd);

            var updatedDvd = repo.GetDvdId(8);

            Assert.AreEqual(dvd.title, updatedDvd.title);
            Assert.AreEqual(dvd.releaseYear, updatedDvd.releaseYear);
            Assert.AreEqual(dvd.director, updatedDvd.director);
            Assert.AreEqual(dvd.rating, updatedDvd.rating);
            Assert.AreEqual(dvd.notes, updatedDvd.notes);

        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvds dvd = new Dvds();
            var repo = new DvdLibraryRepositoryADO();

            dvd.title = "A new movie added";
            dvd.releaseYear = "1999";
            dvd.director = "Prince";
            dvd.rating = "R";
            dvd.notes = "This is an attempt to post a dvd";

            repo.PostDvd(dvd);

            var loaded = repo.GetDvdId(8);
            Assert.IsNotNull(loaded);

            repo.DeleteDvdId(8);

            loaded = repo.GetDvdId(8);
            Assert.IsNull(loaded);

        }

    }
}
