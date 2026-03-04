namespace Categories;

class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Category(string CategoryName, string Description)
    {
        this.CategoryName = CategoryName;
        this.Description = Description;
    }

    public Category()
    {
        
    }

    public override string ToString()
    {
        return $"Category {Id} => {CategoryName}, {Description}";
    }
}
