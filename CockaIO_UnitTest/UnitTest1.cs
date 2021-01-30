using Microsoft.VisualStudio.TestTools.UnitTesting;
using CockaIO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace CockaIO_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod("Can connect to Database")]
        public void ConnectToDatabase()
        {
            using (CockaioContext dbContext = new CockaioContext())
            {
                Assert.IsTrue(dbContext.Database.CanConnect());
            }
        }

        [TestMethod("Connected to correct Database CockaIO")]
        public void ConnectedToCorrectDatabase()
        {
            using (CockaioContext dbContext = new CockaioContext())
            {
                Assert.IsTrue(dbContext.Database.GetDbConnection().Database=="cockaio");
            }
        }
    }
}
