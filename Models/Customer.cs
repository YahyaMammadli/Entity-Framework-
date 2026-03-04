using Orders;

namespace Customers;

class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Order> Orders { get; set; } = new();

    public Customer()
    {
        

    }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

}
