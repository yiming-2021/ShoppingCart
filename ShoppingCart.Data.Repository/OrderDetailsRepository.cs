using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Model;
using Dapper;
using System.Data;

namespace ShoppingCart.Data.Repository
{
    public class OrderDetailsRepository: IRepository<OrderDetails>
    {
        CartDbContext db;
        public OrderDetailsRepository()
        {
            db = new CartDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from OrderDetails where Id = @Id", new { ID = id });
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<OrderDetails>("Select * from OrderDetails");
        }

        public OrderDetails GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<OrderDetails>("Select * from OrderDetails where Id = @Id", new { ID = id });
        }

        public int Insert(OrderDetails item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into OrderDetails values (@OrderID, @ProductID, @Quantity)", item);
        }

        public int Update(OrderDetails item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute(@"Update OrderDetails set OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity where Id = @Id)", item);
        }
    }
}
