using Supliers;

namespace Products;

class Product
{
    public int Id { get; init; }
    public string ProductName { get; set; } = string.Empty;
    public int SupplierId { get; set; }
    public decimal UnitPrice { get; set; }
    public string Package { get; set; } = string.Empty;
    public bool IsDiscontinued { get; set; }

    public Suplier Suplier { get; set; } = new();

    public override string ToString()
    {
        return $"\nId = {Id} \nProduct Name = {ProductName} \nUnit Price = {UnitPrice} \nPackage = {Package}"; 
    }

}
