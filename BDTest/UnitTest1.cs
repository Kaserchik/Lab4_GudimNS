using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DBWork;
namespace BDTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetByID()
        {
            // Arrange
            Class1 class1 = new Class1();
            int id = 1;

            // Act
            class1.GetByID(id);

            // Assert
            Assert.IsNotNull(class1);
        }
        [TestMethod]
        public void TestGetByName()
        {
            // Arrange
            Class1 class1 = new Class1();
            string name = "ExampleName";

            // Act
            class1.GetByName(name);

            // Assert
            Assert.IsNotNull(class1);
        }
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Class1 class1 = new Class1();
            int id = 1;
            string name = "ExampleName";
            string message = "ExampleMessage";

            // Act
            class1.Add(id, name, message);

            // Assert
            Assert.IsNotNull(class1);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            Class1 class1 = new Class1();
            int id = 1;
            string updatedMessage = "UpdatedMessage";

            // Act
            class1.Update(id, updatedMessage);

            // Assert
            Assert.IsNotNull(class1);
        }
        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            Class1 class1 = new Class1();
            int id = 1;

            // Act
            class1.Delete(id);

            // Assert
            Assert.IsNotNull(class1);
        }
    }
}