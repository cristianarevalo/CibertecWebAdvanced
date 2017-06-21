using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Fact(DisplayName = "[CustomerRepositoryTests] Get All Customer")]
        public void test()
        {
            var result = _unit.Customers.GetAll();
            result.Should().NotBeNull(); //el resultado deberia no ser nulo
            result.Count().Should().BeGreaterThan(0); //el resultado debe de ser mayor a cero            
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Get Entity By ID Customer")]
        public void test1()
        {
            var result = _unit.Customers.GetEntityById(1);
            result.Should().NotBeNull();            
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Insert Customer")]
        public void Insert_Customer()
        {
            var result = _unit.Customers.Insert(null);
            result.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CustomerRepositoryTests] Fail Insert Customer")]
        public void Insert_Customer_Wrong()
        {
            var result = _unit.Customers.Insert(new customer());
            result.Should().Be(0);
        }
    }
}
