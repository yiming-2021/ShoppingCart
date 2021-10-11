using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ShoppingCart.Data.Repository
{
    public class CartDbContext
    {
        public IDbConnection GetConnection()
        {
            string con = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("ShoppingCart");
            return new SqlConnection(con);
        }
    }
}