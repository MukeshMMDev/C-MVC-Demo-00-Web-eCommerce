using eCommerce.DAL.Data;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class ProductRepositories
    {

        internal DataContext contect;

        public ProductRepositories(DataContext contect) {
            this.contect = contect;
        }

        public virtual Product GetById(object id) {
            return contect.Products.Find(id);
        }
        public virtual IQueryable<Product> GetAll(object id)
        {
            return contect.Products;
        }

        public virtual void Insert(Product entity)
        {
            contect.Products.Add(entity);
        }

        public virtual void Update(Product entity)
        {
            contect.Products.Attach(entity);
            contect.Entry(entity).State=EntityState.Modified;
        }

        public virtual void Delete(Product entity)
        {
            if(contect.Entry(entity).State==EntityState.Detached)
            contect.Products.Attach(entity);

            contect.Products.Remove(entity);
        }
    }
}
