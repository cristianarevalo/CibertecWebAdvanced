using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cibertec.Repositories.Tests
{
    public class MockedUnitOfWork
    {
        public static IUnitOfWork GetUnitOfWork()
        {
            Mock<IUnitOfWork> unit = new Mock<IUnitOfWork>();
            unit.ConfigureCustomer();
            return unit.Object;
        }
    }

    //extendiendo MockedUnitOfWork(palabra clave this)
    //todas las extensiones son del titpo estatico
    public static class MockedUnitOfWorkExtensions
    {
        public static Mock<IUnitOfWork> ConfigureCustomer(this Mock<IUnitOfWork> mock)
        {
            var customerList = new List<customer>
            {
                new customer
                    {
                        Id = 1,
                        City = "Lima",
                        Country = "Peru",
                        FirstName = "Cristian",
                        LastName = "Arevalo",
                        Phone = "955782336"
                    },
                    new customer
                    {
                        Id = 2,
                        City = "Cajamarca",
                        Country = "Peru",
                        FirstName = "Ana",
                        LastName = "Machuca",
                        Phone = "955782336"
                    }
            };

            mock.Setup(c => c.Customers.GetAll()).Returns(customerList);
            mock.Setup(c => c.Customers.Insert(It.IsAny<customer>())).Returns(1);
            mock.Setup(c => c.Customers.Update(It.IsAny<customer>())).Returns(true);
            mock.Setup(c => c.Customers.Delete(It.IsAny<customer>())).Returns(true);

            mock.Setup(c => c.Customers.SearchByNames(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string firstName, string lastName) =>
                {
                    return customerList.FirstOrDefault(x => x.FirstName == firstName
                    && x.LastName == lastName);
                });

            mock.Setup(c => c.Customers.GetEntityById(It.IsAny<int>()))
            .Returns((int id) => { return customerList.FirstOrDefault(x => x.Id == id);
             });

            mock.Setup(c => c.Customers.Insert(null)).Returns(1);

            return mock;
        }
    }

}
