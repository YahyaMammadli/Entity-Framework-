using Products;

namespace Supliers;

class Suplier
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new();


    public Suplier(string CompanyName, string City, string Country)
    {
        this.CompanyName = CompanyName;
        this.City = City;  
        this.Country = Country;
        
    }

    public Suplier()
    {
        
    }




}
