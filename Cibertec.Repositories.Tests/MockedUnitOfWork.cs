using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
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
            mock.Setup(c => c.Customers.GetAll()).Returns(
                new List<customer>
                {
                    new customer
                    {
                        Id = 1,
                        City = "Lima",
                        Country = "Peru",
                        FirstName = "Cristian",
                        LastName = "Arevalo Solis",
                        Phone = "955782336"
                    },
                    new customer
                    {
                        Id = 2,
                        City = "Cajamarca",
                        Country = "Peru",
                        FirstName = "Ana",
                        LastName = "Machuca Arevalo",
                        Phone = "955782336"
                    }
                });


            mock.Setup(c => c.Customers.GetEntityById(1)).Returns(
                new customer
                {
                    Id = 1,
                    City = "Lima",
                    Country = "Peru",
                    FirstName = "Cristian",
                    LastName = "Arevalo Solis",
                    Phone = "955782336"
                });

            mock.Setup(c => c.Customers.Insert(null)).Returns(1);

            return mock;
        }
    }

}
