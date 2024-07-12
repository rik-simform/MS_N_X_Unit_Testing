using NUnitTests;
using Xunit;

namespace XUnitTests
{
        public class XUnitEmployeeTests
        {
            private readonly List<Employee> _testEmployees;

            public XUnitEmployeeTests()
            {
                _testEmployees = GetTestEmployees();
            }

            [Fact]
            public void GetAllEmployees_ShouldReturnAllEmployees()
            {
                // Arrange
                var controller = new EmployeeService(_testEmployees);

                // Act
                var result = controller.GetAllEmployees();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<Employee>>(result);
                // Assert
                var okResult = Assert.IsType<List<Employee>>(result);
                Assert.NotNull(okResult);
                Assert.Equal(_testEmployees.Count, okResult.Count);

            }

            [Fact]
            public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
            {
                // Arrange
                var controller = new EmployeeService(_testEmployees);

                // Act
                var result = await controller.GetAllEmployeesAsync();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<Employee>>(result);
                var okResult = Assert.IsType<List<Employee>>(result);
                Assert.NotNull(okResult);
                Assert.Equal(_testEmployees.Count, okResult.Count);
            }

            [Theory]
            [InlineData(1)]
            [InlineData(3)]
            public void GetEmployeeById_ShouldReturnCorrectEmployee(int EmployeeId)
            {
                // Arrange
                var controller = new EmployeeService(_testEmployees);

                // Act
                var result = controller.GetEmployeeById(EmployeeId);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<Employee>(result);
                // Assert
                var okResult = Assert.IsType<Employee>(result);
                Assert.Equal(_testEmployees[EmployeeId - 1].Name, result.Name);

            }

            [Fact]
            public void GetEmployeeById_ShouldReturnNotFound()
            {
                // Arrange
                var controller = new EmployeeService(_testEmployees);

                // Act
                var result = controller.GetEmployeeById(999);

                // Assert
                Assert.IsType<object>(result);
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
