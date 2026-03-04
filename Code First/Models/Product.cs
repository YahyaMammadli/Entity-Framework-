using System.ComponentModel.DataAnnotations;

namespace Program.Models.Prod;
public class Product
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; } = true;

    public override string ToString()
    {
        return $"\n\nName => {Name} \nCategory => {Category} \nPrice => {Price} \nStockQuantity => {StockQuantity} \nCreat Date => {CreatedAt}\n\n\n\n";
    }



}