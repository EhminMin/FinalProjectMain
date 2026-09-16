using FinalProject.GUI.Models;
using FinalProject.GUI.Services;
using FinalProject.GUI.Exceptions;

namespace FinalProject.Tests

{
    [TestClass]
    public sealed class FurnitureManagerTests
    {
        private List<Chair> GetTestChairs()
        {
            return new List<Chair>
            {
                new Chair("дерево", 450),
                new Chair("дерево", 500),
                new Chair("метал", 750)
            };
        }

        private List<Table> GetTestTables()
        {
            return new List<Table>
            {
                new Table("дерево", 1500, 120, 80),
                new Table("метал", 1800, 100, 100)
            };
        }

        [TestMethod]
        public void CreateSet_ValidData_ReturnsCorrectName()
        {
            var manager = new FurnitureManager();
            var result = manager.CreateSet(GetTestChairs(), GetTestTables(), "дерево", 120, 80, 2);

            Assert.AreEqual("дерево Set", result.Name);
        }

        [TestMethod]
        public void CreateSet_ValidData_SetsCorrectTableWidth()
        {
            var manager = new FurnitureManager();
            var result = manager.CreateSet(GetTestChairs(), GetTestTables(), "дерево", 120, 80, 2);

            var table = result.GetAllFurniture().OfType<Table>().FirstOrDefault();
            Assert.AreEqual(120, table?.Width);
        }

        [TestMethod]
        public void CreateSet_ValidData_SetsCorrectTableDepth()
        {
            var manager = new FurnitureManager();
            var result = manager.CreateSet(GetTestChairs(), GetTestTables(), "дерево", 120, 80, 2);

            var table = result.GetAllFurniture().OfType<Table>().FirstOrDefault();
            Assert.AreEqual(80, table?.Depth);
        }

        [TestMethod]
        public void CreateSet_ValidData_AddsCorrectAmountOfChairs()
        {
            var manager = new FurnitureManager();
            var result = manager.CreateSet(GetTestChairs(), GetTestTables(), "дерево", 120, 80, 2);

            int chairsCount = result.GetAllFurniture().OfType<Chair>().Count();
            Assert.AreEqual(2, chairsCount);
        }

        [TestMethod]
        public void CreateSet_ValidData_CalculatesCorrectTotalPrice()
        {
            var manager = new FurnitureManager();
            var result = manager.CreateSet(GetTestChairs(), GetTestTables(), "дерево", 120, 80, 2);

            Assert.AreEqual(2450m, result.TotalPrice);
        }

        [TestMethod]
        public void CreateSet_NoTable_ThrowsException()
        {
            var manager = new FurnitureManager();
            var emptyTables = new List<Table>();

            try
            {
                manager.CreateSet(GetTestChairs(), emptyTables, "дерево", 120, 80, 2);
                Assert.Fail("Очікувався виняток FurnitureShortageException, але він не був викинутий.");
            }
            catch (FurnitureShortageException)
            {
            }
        }

        [TestMethod]
        public void CreateSet_NotEnoughChairs_ThrowsException()
        {
            var manager = new FurnitureManager();
            var oneChair = new List<Chair> { new Chair("дерево", 450m) };

            try
            {
                manager.CreateSet(oneChair, GetTestTables(), "дерево", 120, 80, 2);
                Assert.Fail("Очікувався виняток FurnitureShortageException, але він не був викинутий.");
            }
            catch (FurnitureShortageException)
            {
            }
        }

        [TestMethod]
        public void CreateRemainingSet_ValidData_ReturnsCorrectSetsCount()
        {
            var manager = new FurnitureManager();

            List<FurnitureSet> result = manager.CreateRemainingSets(GetTestChairs(), GetTestTables());

            Assert.AreEqual(2, result.Count);
        }
    }
}
