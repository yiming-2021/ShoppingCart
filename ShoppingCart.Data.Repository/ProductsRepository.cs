using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Model;
using Dapper;
using System.Data;

namespace ShoppingCart.Data.Repository
{
    public class ProductsRepository
    {
        CartDbContext db;
        public ProductsRepository()
        {
            db = new CartDbContext();
        }

        public IEnumerable<Products> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Products>("Select * from Products");
        }

        public Products GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Products>("Select * from Products where Id = @Id", new { ID = id });
        }


    }
}
