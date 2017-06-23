using Cibertec.UnitOfWork;
using System.Linq;
using Xunit;
using FluentAssertions;
using Cibertec.Models;

namespace Cibertec.Repositories.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly IUnitOfWork _unit;
        public CustomerRepositoryTests()
        {
            //_unit = new CibertecUnitOfWork(ConfigSettings.ConnectionString);
            _unit = MockedUnitOfWork.GetUnitOfWork();
        }


        [Fact(DisplayName = "[CustomerRepositoryTests] Get All Test")]
        public void Customer_Get_All()
        {
            var customerList = _unit.Customers.GetAll().ToList();            
            customerList.Count().Should().BeGreaterThan(0); //el resultado debe de ser mayor a cero            
            customerList.Count().Should().Be(2);
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] First Unit test")]
        public void First_Unit_Test()
        {
            var result = _unit.Customers.GetEntityById(1);
            result.Should().NotBeNull();            
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Customer Insert Test")]
        public void Customer_Insert()
        {
            var result = _unit.Customers.Insert(new customer());
            result.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Customer Update Test")]
        public void Customer_Update()
        {
            var result = _unit.Customers.Update(new customer());
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Customer Delete Test")]
        public void Customer_Delete()
        {
            var result = _unit.Customers.Delete(new customer());
            result.Should().BeTrue();
        }

        //Theory: Para muchos test
        [Theory(DisplayName = "[CustomerRepositoryTests] Customer Search By Names Test")]
        [InlineData("Cristian", "Arevalo")]
        [InlineData("Ana", "Machuca")]
        public void Customer_SearchByName(string firstName, string lastName)
        {
            var result = _unit.Customers.SearchByNames(firstName, lastName);
            result.Should().NotBeNull();
        }
    }
}
