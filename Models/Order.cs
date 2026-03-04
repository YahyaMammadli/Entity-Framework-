using Customers;

namespace Orders;

class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int TotalAmount { get; set; }
    
    public int OrderNumber { get; set; } 

    public Customer Customer { get; set; } = new();


    public Order(int totalAmount, int orderNumber)
    {
        TotalAmount = totalAmount;
        OrderNumber = orderNumber;
    }

    public Order()
    {
        
    }


    public override string ToString()
    {
        return $"Order {OrderNumber} : Customer {Customer.ToString()}, his Total amount {TotalAmount} ";
    }

}

