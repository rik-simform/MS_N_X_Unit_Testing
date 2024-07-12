using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace NUnitTests
{
        [TestFixture]
        public class EmployeeControllerTests
        {
            private List<Employee> _testEmployees;

            [SetUp]
            public void Setup()
            {
                _testEmployees = GetTestEmployees();
            }

            [Test]
            public void GetAllEmployees_ShouldReturnAllEmployees()
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = controller.GetAllEmployees();
                
                // ClassicClassicAssert
                ClassicAssert.IsNotNull(result);
            }

            [Test]
            public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = await controller.GetAllEmployeesAsync();

                // ClassicAssert
                ClassicAssert.IsNotNull(result);
            }

            [Test]
            public void GetEmployeeById_ShouldReturnCorrectEmployee()
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = controller.GetEmployeeById(4);

                // ClassicAssert
                ClassicAssert.IsNotNull(result);
                ClassicAssert.AreEqual(_testEmployees[3].Id, result.Id);
                ClassicAssert.AreEqual(_testEmployees[3].Name, result.Name);
            }

            [Test]
            public async Task GetEmployeeByIdAsync_ShouldReturnCorrectEmployee()
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = await controller.GetEmployeeByIdAsync(4);

                // ClassicAssert
                ClassicAssert.IsNotNull(result);
                ClassicAssert.AreEqual(_testEmployees[3].Id, result.Id);
                ClassicAssert.AreEqual(_testEmployees[3].Name, result.Name);
            }

            [TestCase(1)]
            [TestCase(3)]
            public void GetEmployeeById_ShouldReturnCorrectEmployeeWithData(int EmployeeId)
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = controller.GetEmployeeById(EmployeeId);

                // ClassicAssert
                ClassicAssert.IsNotNull(result);
                ClassicAssert.AreEqual(_testEmployees[EmployeeId - 1].Id, result.Id);
                ClassicAssert.AreEqual(_testEmployees[EmployeeId - 1].Name, result.Name);
            }

            [Test]
            public void GetEmployeeById_ShouldReturnNotFound()
            {
                // arrange
                var controller = new EmployeeService(_testEmployees);

                // act
                var result = controller.GetEmployeeById(999);

            // ClassicAssert
            ClassicAssert.That(result, null);
            }

            [TearDown]
            public void TearDown()
            {
                // Clean up resources if necessary
                _testEmployees = null;
            }

            private static List<Employee> GetTestEmployees()
            {
                return new List<Employee>
            {
                new() { Id = 1, Name = "Madhuri Dixit", Salary = 50000 },
                new() { Id = 2, Name = "Disha Patani", Salary = 500000 },
                new() { Id = 3, Name = "Aishwarya Rai", Salary = 350000 },
                new() { Id = 4, Name = "Nasurudin shah", Salary = 10000 }
            };
            }
        }
}
