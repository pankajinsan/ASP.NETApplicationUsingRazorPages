using CRUDApplicationUsingRazorPages.Entity;
using System.Collections.Generic;

namespace CRUDApplicationUsingRazorPages.Repository
{
    public interface IRepository
    {
        void Add(Customer customer);
        void Remove(int id);
        void Update(Customer customer);
        Customer FindByID(int id);
        List<Customer> FindAll();
        List<Customer> FindByName(ProductSearchModel model);
    }
}
