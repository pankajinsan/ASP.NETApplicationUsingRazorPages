using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using CRUDApplicationUsingRazorPages.Entity;
namespace CRUDApplicationUsingRazorPages.Repository
{
    public class CustomerRepository : IRepository
    {
        private string connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Customer item)
        {
            //int count = 0;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
               dbConnection.Execute("INSERT INTO property (property_id,property_name, gm_name, street_address, city_address, state, country, zipcode) VALUES(@Property_ID,@Property_Name, @GM_Name, @Street_Address, @City_Address, @State, @Country, @Zipcode)", item);
            }
           
        }

        public List<Customer> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM property").ToList();
            }
        }

        public Customer FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM property WHERE id = @ID", new { ID = id }).FirstOrDefault();
            }
        }
        public List<Customer> FindByName(ProductSearchModel prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = dbConnection.Query<Customer>("SELECT * FROM property");
                if (prod.Property_ID != null)
                { result = result.Where(x => x.Property_ID == prod.Property_ID); }
                if (prod.Property_Name != null)
                { result = result.Where(x => x.Property_Name == prod.Property_Name); }
                if (prod.GM_Name != null)
                { result = result.Where(x => x.GM_Name == prod.GM_Name); }
                if (prod.Street_Address != null)
                { result = result.Where(x => x.Street_Address == prod.Street_Address); }
                if (prod.City_Address != null)
                { result = result.Where(x => x.City_Address == prod.City_Address); }
                if (prod.State != null)
                { result = result.Where(x => x.State == prod.State); }
                if (prod.Country != null)
                { result = result.Where(x => x.Country == prod.Country); }
                if (prod.Zipcode != null)
                { result = result.Where(x => x.Zipcode == prod.Zipcode); }
                return result.ToList();
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM property WHERE id=@ID", new { ID = id });
            }
        }

        public void Update(Customer item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE property SET property_id = @Property_ID,property_name=@Property_Name, gm_name=@GM_Name, street_address=@Street_Address, city_address=@City_Address, state=@State, country=@Country, zipcode=@Zipcode WHERE id = @ID", item);
            }
        }
    }
}
