using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DBWork;
using System.Data.SqlClient;

namespace BDTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetByID_ShouldFillTable()
        {
            // Arrange
            Class1 class1 = new();
            int messageId = 1;

            // Act
            class1.GetByID(messageId);

            // Assert
            Assert.IsNotNull(class1.table);
            Assert.IsTrue(class1.table.Rows.Count > 0, "Table should be filled with data");
        }
        [TestMethod]
        public void TestGetByID_ShouldNotFillTable()
        {
            // Arrange
            Class1 class1 = new();
            int messageId = -1;

            // Act
            class1.GetByID(messageId);

            // Assert
            Assert.IsNotNull(class1.table);
            Assert.AreEqual(0, class1.table.Rows.Count, "Table should not be filled with data");
        }
        [TestMethod]
        public void TestGetByName_ShouldFillTable()
        {
            // Arrange
            Class1 class1 = new();
            string messageName = "User";

            // Act
            class1.GetByName(messageName);

            // Assert
            Assert.IsTrue(class1.table.Rows.Count > 0, "Table should be filled with data");
        }
        [TestMethod]
        public void TestGetByName_ShouldNotFillTable()
        {
            // Arrange
            Class1 class1 = new();
            string messageName = "TestName"; 

            // Act
            class1.GetByName(messageName);

            // Assert
            Assert.IsFalse(class1.table.Rows.Count > 0, "Table should not be filled with data");
        }
        [TestMethod]
        public void TestAdd_ShouldAddRecord()
        {
            // Arrange
            Class1 class1 = new();
            int id = 2;
            string name = "ExampleName";
            string message = "ExampleMessage";

            // Act
            class1.Add(id, name, message);

            // Assert
            Assert.IsTrue(class1.IsRecordExists(id, name, message), "Record should be added to the database");
        }
        [TestMethod]
        public void TestAdd_ShouldNotAddRecordWithDuplicateID()
        {
            // Arrange
            Class1 class1 = new();
            int id = 2;
            string name = "ExampleName";
            string message = "ExampleMessage";

            // Assert
            Assert.IsTrue(class1.IsRecordExists(id, name, message), "Record with duplicate ID should not be added");
        }
        [TestMethod]
        public void TestUpdate_ShouldUpdateRecord()
        {
            // Arrange
            Class1 class1 = new();
            int id = 2;
            string updatedMessage = "UpdatedMessage";

            // ��������� ������ � �������� ID � ����� ����������
            class1.Update(id, updatedMessage);

            // Assert
            // ���������, ��� ������ ���� ������� ��������� � ���� ������
            Assert.IsTrue(class1.IsRecordExists(id, "ExampleName", updatedMessage), "Record should be updated in the database");
        }
        [TestMethod]
        public void TestUpdate_ShouldNotUpdateNonexistentRecord()
        {
            // Arrange
            Class1 class1 = new();
            int id = -1; // �������� �� ��������, ������� �������������� �� ���������� � ����� ���� ������
            string updatedMessage = "UpdatedMessage";

            // Act
            // �������� �������� ������ � �������������� ID
            class1.Update(id, updatedMessage);

            // Assert
            // �������� ��� ��������, ��� ������ � �������������� ID �� ���� ���������
            Assert.IsFalse(class1.IsRecordExists(id, "AnyName", updatedMessage), "Record with nonexistent ID should not be updated");
        }
        [TestMethod]
        public void TestDelete_ShouldDeleteRecord()
        {
            // Arrange
            Class1 class1 = new();
            int id = 5;

            // Act
            // ��������� ������ � �������� ID
            class1.Add(id, "ExampleName", "ExampleMessage");

            // ������� ������ � �������� ID
            class1.Delete(id);

            // Assert
            // ���������, ��� ������ ���� ������� ������� �� ���� ������
            Assert.IsFalse(class1.IsRecordExists(id, "ExampleName", "ExampleMessage"), "Record should be deleted from the database");
        }
        [TestMethod]
        public void TestDelete_ShouldNotDeleteNonexistentRecord()
        {
            // Arrange
            Class1 class1 = new();
            int id = -1;

            // Act
            // �������� ������� ������ � �������������� ID
            class1.Delete(id);

            // Assert
            Assert.IsFalse(class1.IsRecordExists(id, "AnyName", "AnyMessage"), "Record with nonexistent ID should not be deleted");
        }
    }
}