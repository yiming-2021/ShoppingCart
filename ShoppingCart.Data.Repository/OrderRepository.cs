using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Model;
using Dapper;
using System.Data;

namespace ShoppingCart.Data.Repository
{
    public class OrderRepository: IRepository<Orders>
    {
        CartDbContext db;
        public OrderRepository()
        {
            db = new CartDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from Orders where Id = @Id", new { ID = id });
        }

        public IEnumerable<Orders> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Orders>("Select * from Orders");
        }

        public Orders GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Orders>("Select * from Orders where Id = @Id", new { ID = id });
        }

        public int Insert(Orders item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into Orders values (@OrderDate, @Total, @CustomerID)", item);
        }

        public int Update(Orders item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute(@"Update Orders set OrderDate = @OrderDate, Total = @Total, CustomerID = @CustomerID where Id = @Id)", item);
        }


        public Orders GetOrderId()
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Orders>("Select top 1 * from Orders order by ID desc");
        }
    }
}
