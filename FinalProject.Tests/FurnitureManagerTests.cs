using FinalProject.Models;
using FinalProject.Services;
using FinalProject.Exceptions;

namespace FinalProject.Tests

{
    [TestClass]
    public sealed class FurnitureManagerTests
    {
        [TestMethod]
        public void CreateSet_ValidData_ReturnsFurnitureSet()
        {
            //Arrange
            var chairs = new List<Chair>
            {
                new Chair("Дерево", 450),
                new Chair("Дерево", 500)
            };

            var tables = new List<Table>
            {
                new Table("120x80", "Дерево", 1500)
            };

            var manager = new FurnitureManager();

            //Act
            FurnitureSet result = manager.CreateSet(chairs, tables, "Дерево", "120x80", 2);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Дерево Set", result.Name);
            Assert.IsNotNull(result.Table);
            Assert.AreEqual("120x80", result.Table.Size);
            Assert.AreEqual("Дерево", result.Table.Material);
            Assert.AreEqual(2, result.Chairs.Count);
            Assert.AreEqual(2450, result.TotalPrice);
        }

        [TestMethod]
        public void CreateSet_NoTable_ThrowExceptions()
        {
            //Arrange
            var chairs = new List<Chair>
            {
                new Chair("Дерево", 450),
                new Chair("Дерево", 500)
            };

            var tables = new List<Table>();

            var manager = new FurnitureManager();

            //Act 
            try
            {
                manager.CreateSet(chairs, tables, "Дерево", "120x80", 2);
                Assert.Fail("Expected FurnitureShortageException was not thrown.");
            }
            catch (FurnitureShortageException)
            {
                // Expected exception
            }

        }
        
        [TestMethod]
        public void CreateSet_NotEnoughChairs_ThrowExceptions()
        {
            //Arrange
            var chairs = new List<Chair>
            {
                new Chair("Дерево", 450)
            };

            var tables = new List<Table>();

            var manager = new FurnitureManager();

            //Act 
            try
            {
                manager.CreateSet(chairs, tables, "Дерево", "120x80", 2);
                Assert.Fail("Expected FurnitureShortageException was not thrown.");
            }
            catch (FurnitureShortageException)
            {
                // Expected exception
            }
        }

        [TestMethod]
        public void CreateRemainingSet_ValidData_ReturnsSets()
        {
            //Arrange
            var chairs = new List<Chair>
            {
                new Chair("Дерево", 450),
                new Chair("Дерево", 500),
                new Chair("Метал", 750)
            };

            var tables = new List<Table>
            {
                new Table("120x80", "Дерево", 1500),
                new Table("100x100", "Метал", 1800)
            };

            var manager = new FurnitureManager();

            //Act
            List<FurnitureSet> result = manager.CreateRemainingSets(chairs, tables);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);


        }

    }
}
