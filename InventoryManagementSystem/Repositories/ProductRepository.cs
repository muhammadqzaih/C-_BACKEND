using InventoryManagementSystem.Entities;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem
    .Repositories;

public class ProductRepository : IProdcutRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }


    public Product? GetProduct(string productName)
    {
        var query = $"SELECT * FROM products WHERE Name = @name";

        var result = Excuter<Product>(query, command => { command.Parameters.AddWithValue("@name", productName); });

        return result.FirstOrDefault();
    }

    public bool AddProduct(Product? product)
    {
        var query = "INSERT INTO products (name, price, quantity) VALUES (@name, @price, @quantity)";

        bool result = Excuter(query, command =>
        {
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@quantity", product.QuantityInStock);
        });

        return result;
    }

    public ICollection<Product> GetAllProducts()
    {
        var query = "SELECT * FROM Product";

        var result = Excuter<Product>(query);

        return result;
    }

    public bool RemoveProduct(string productName)
    {
        var query = "DELETE FROM Product WHERE Name = @name";

        bool result = Excuter(query, command => { command.Parameters.AddWithValue("@name", productName); });

        return result;
    }

    public bool IsProductInTheInventory(string productName)
    {
        var query = "SELECT * FROM Product WHERE Name = @name";

        var results = Excuter<Product>(query, command => { command.Parameters.AddWithValue("@name", productName); });

        return results.Any();
    }

    public bool IsTheInventoryEmpty()
    {
        var query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Product) THEN 0 ELSE 1 END";
    
        var result = ExcuterScalar(query);
    
        Console.WriteLine("Result: " + result);
    
        return result == 1;
    }

// New method to execute a scalar query (returns a single value)
    private int ExcuterScalar(string query)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(query, connection);

        connection.Open();
        var result = command.ExecuteScalar();
        connection.Close();

        // Return the result as an integer (CAST it as an integer)
        return Convert.ToInt32(result);
    }
   
    private static T ReadFromReader<T>(SqlDataReader reader)
    {
        var properties = typeof(T).GetProperties();
        var instance = Activator.CreateInstance<T>();
        foreach (var property in properties)
        {
            var value = reader[property.Name];
            if (value == DBNull.Value)
            {
                property.SetValue(instance, null);
            }
            else
            {
                property.SetValue(instance, value);
            }
        }

        return instance;
    }


    private bool Excuter(
        string query,
        Action<SqlCommand>? addParameters = null)
    {
        using var connection = new SqlConnection(_connectionString);

        using var command = new SqlCommand(query, connection);
        addParameters?.Invoke(command);

        connection.Open();
        var result = command.ExecuteNonQuery();
        connection.Close();

        return result == 1;
    }

    private ICollection<T> Excuter<T>(
        string query,
        Action<SqlCommand>? addParameters = null)
    {
        using var connection = new SqlConnection(_connectionString);

        using var command = new SqlCommand(query, connection);
        addParameters?.Invoke(command);

        connection.Open();
        var reader = command.ExecuteReader();
        var list = new List<T>();
        while (reader.Read())
        {
            list.Add(ReadFromReader<T>(reader));
        }

        connection.Close();

        return list;
    }
}