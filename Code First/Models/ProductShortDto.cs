

namespace Propgram.Models.DTO;

class ProductShortDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ProductShortDto(string name, decimal price)
    {
        Name = name;
        Price = price;
    }


}
