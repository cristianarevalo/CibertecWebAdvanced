using System;
using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        //ctor -> tab tab
        public EFUnitOfWork(DbContext context)
        {
            Customers = new RepositoryEF<customer>(context);
            Orders = new RepositoryEF<order>(context);
            OrderItems = new RepositoryEF<orderItem>(context);
            Products = new RepositoryEF<product>(context);
            Suppliers = new RepositoryEF<supplier>(context);
        }

        //public IRepository<customer> Customers => throw new NotImplementedException();
        //private set: solo puede ser modificado en esta clase
        public IRepository<customer> Customers { get; private set; }
        public IRepository<order> Orders { get; private set; }
        public IRepository<orderItem> OrderItems { get; private set; }
        public IRepository<product> Products { get; private set; }
        public IRepository<supplier> Suppliers { get; private set; }


    }
}
