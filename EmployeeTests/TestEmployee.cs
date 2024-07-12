using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnitTests;

namespace EmployeeTests
{
    [TestClass]
    public class TestEmployee
    {

        private List<Employee> _testEmployees;

        [TestInitialize]
        public void Initialize()
        {
            _testEmployees = GetTestEmployees();
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = controller.GetAllEmployees();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testEmployees.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = await controller.GetAllEmployeesAsync();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testEmployees.Count, result.Count);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnCorrectEmployee()
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = controller.GetEmployeeById(4);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testEmployees[3].Id, result.Id);
            Assert.AreEqual(_testEmployees[3].Name, result.Name);
        }

        [TestMethod]
        public async Task GetEmployeeByIdAsync_ShouldReturnCorrectEmployee()
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = await controller.GetEmployeeByIdAsync(4);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testEmployees[3].Id, result.Id);
            Assert.AreEqual(_testEmployees[3].Name, result.Name);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        public void GetEmployeeById_ShouldReturnCorrectEmployeeWithData(int EmployeeId)
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = controller.GetEmployeeById(EmployeeId);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testEmployees[EmployeeId - 1].Id, result.Id);
            Assert.AreEqual(_testEmployees[EmployeeId - 1].Name, result.Name);
        }

        [TestMethod]
        public void GetEmployeeById_ShouldReturnNotFound()
        {
            // arrange
            var controller = new EmployeeService(_testEmployees);

            // act
            var result = controller.GetEmployeeById(999);

            // assert
            Assert.IsInstanceOfType(result, null);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up resources if necessary
            _testEmployees = null;
        }

        private List<Employee> GetTestEmployees()
        {
            return new List<Employee>
            {
                new Employee() { Id = 1, Name = "Bike", Salary = 50000 },
                new Employee() { Id = 2, Name = "Car", Salary = 500000 },
                new Employee() { Id = 3, Name = "Truck", Salary = 350000 },
                new Employee() { Id = 4, Name = "Cycle", Salary = 10000 }
            };
        }
    }
}
