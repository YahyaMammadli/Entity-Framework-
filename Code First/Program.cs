using Propgram.Data;
using Program.Models.Prod;
using Propgram.Models.DTO;



namespace Propgram;

class Program
{


    static void Main()
    {
        using var context = new AppDbContext();



        #region 1

        //var product1 = new Product { Name = "Laptop", Category = "Electronics", Price = 1200, StockQuantity = 10 };
        //context.Products.Add(product1);
        //context.SaveChanges();
        //Console.Write($"1. New product Id: {product1.Id}\n");
        #endregion

        #region 2

        //Console.Write("2. Added 5 products with SaveChanges inside the loop\n");
        //var productsForLoop = new List<Product>();
        //for (int i = 1; i <= 5; i++)
        //{
        //    productsForLoop.Add(new Product { Name = $"ProductInLoop{i}", Category = "Test", Price = 100 + i, StockQuantity = i });
        //}
        //
        //foreach (var p in productsForLoop)
        //{
        //    context.Products.Add(p);
        //    context.SaveChanges();
        //}
        

        #endregion






        #region 3

        //Console.Write("3. Added 5 products with a single SaveChanges outside the loop\n");
        //var productsBatch = new List<Product>();
        //for (int i = 1; i <= 5; i++)
        //{
        //    productsBatch.Add(new Product { Name = $"ProductBatch{i}", Category = "Batch", Price = 200 + i, StockQuantity = i * 2 });
        //}
        //foreach (var p in productsBatch)
        //{
        //    context.Products.Add(p);
        //}
        //context.SaveChanges();

        
        #endregion


        #region 4

        //Console.Write("4. Added 10 products using AddRange\n");
        //var productsRange = new List<Product>();
        //for (int i = 1; i <= 10; i++)
        //{
        //    productsRange.Add(new Product { Name = $"RangeProduct{i}", Category = "Range", Price = 300 + i, StockQuantity = i });
        //}
        //context.Products.AddRange(productsRange);
        //context.SaveChanges();
        #endregion



        #region 5

        //var firstProduct = new Product
        //{
        //    Name = "Original Product",
        //    Category = "Demo",
        //    Price = 100,
        //    StockQuantity = 5
        //};
        //context.Products.Add(firstProduct);
        //context.SaveChanges();
        //Console.Write($"5. First product saved with Id: {firstProduct.Id}\n\n");
        //
        //
        //var retrievedProduct = context.Products.Find(firstProduct.Id);
        //
        //var secondProduct = new Product
        //{
        //    Name = $"Copy of {retrievedProduct.Name}",
        //    Category = retrievedProduct.Category,
        //    Price = retrievedProduct.Price * 1.2m,
        //    StockQuantity = retrievedProduct.StockQuantity / 2
        //};
        //context.Products.Add(secondProduct);
        //context.SaveChanges();
        //Console.Write($"5. Second product saved with Id: {secondProduct.Id}, based on product Id {retrievedProduct.Id}\n");
        #endregion

        #region 6 

        //var categories = new[] { "Books", "Toys", "Clothing", "Electronics", "Furniture" };
        //var random = new Random();
        //var productsByCategory = new List<Product>();
        //for (int i = 1; i <= 20; i++)
        //{
        //    var cat = categories[random.Next(categories.Length)];
        //
        //    productsByCategory.Add(new Product { Name = $"Product{i}", Category = cat, Price = random.Next(10, 1000), StockQuantity = random.Next(0, 50) });
        //}
        //
        //foreach (var p in productsByCategory)
        //{
        //    context.Products.Add(p);
        //}
        //
        //context.SaveChanges();
        //
        //Console.Write("6. Added 20 products of different categories\n");



        #endregion





        #region 8

        //var allProducts = context.Products.ToList();
        //foreach (var item in allProducts)
        //{
        //    Console.Write(item + "\n");
        //}

        #endregion

        #region 9

        //var names = context.Products.Select(p => p.Name).ToList();
        //
        //foreach (var item in names)
        //{
        //    Console.Write(item + "\n");
        //}


        #endregion


        #region 10

        //var namePrice = context.Products.Select(p => new { p.Name, p.Price }).ToList();
        //
        //foreach (var item in namePrice)
        //{
        //    Console.Write($"10. Name: {item.Name}, Price: {item.Price}\n");
        //
        //}



        #endregion

        #region 11


        //var shortDtos = context.Products.Select(p => new ProductShortDto(p.Name, p.Price)).ToList();
        //
        //foreach (var dto in shortDtos)
        //{
        //    Console.Write($"11. DTO: {dto.Name} - {dto.Price}\n");
        //}

        #endregion


        #region 12


        //var uniqueCategories = context.Products.Select(p => p.Category).Distinct().ToList();
        //foreach (var item in uniqueCategories)
        //{
        //    Console.Write(item + "\n");
        //}


        #endregion



        #region 13

        //var expensiveProducts = context.Products.Where(p => p.Price > 100).ToList();
        //
        //foreach (var item in expensiveProducts)
        //{
        //    Console.Write(item + "\n");
        //}
        #endregion



        #region 14

        //var sortedDesc = context.Products.OrderByDescending(p => p.Price).ToList();
        //
        //foreach (var item in sortedDesc)
        //{
        //    Console.Write(item + "\n");
        //
        //}

        #endregion



        #region 15

        //var top3 = context.Products.OrderByDescending(p => p.Price).Take(3).ToList();
        //
        //foreach (var item in top3)
        //{
        //    Console.Write($"   {item.Name} - {item.Price}\n");
        //
        //}


        #endregion


        #region 16

        //var fiveDaysAgo = DateTime.Now.AddDays(-5);

        //var recentProducts = context.Products.Where(p => p.CreatedAt >= fiveDaysAgo).ToList();
        //foreach (var item in recentProducts)
        //{
        //    Console.Write(item + "\n");

        //}


        #endregion


        #region 17

        //var stockValues = context.Products.Select(p => new { p.Name, StockValue = p.Price * p.StockQuantity }).ToList();

        //foreach (var item in stockValues)
        //{
        //    Console.Write($"{item.Name} - total stock value: {item.StockValue}\n");

        //}



        #endregion


        #region 18

        //var avgPrice = context.Products.Average(p => p.Price);


        #endregion


        #region 19
        //var maxPrice = context.Products.Max(p => p.Price);

        #endregion


        #region 20
        //var minPrice = context.Products.Min(p => p.Price);

        #endregion

        #region 21
        //var totalCount = context.Products.Count();

        #endregion

        #region 22
        //var totalStock = context.Products.Sum(p => p.StockQuantity);

        #endregion

        #region 23
        //var category = "Electronics";
        //var avgCategoryPrice = context.Products.Where(p => p.Category == category).Average(p => (decimal?)p.Price) ?? 0;
        #endregion

        #region 24
        //var countExpensive = context.Products.Count(p => p.Price > 500);

        #endregion

        #region 25
        //var productToUpdate = context.Products.FirstOrDefault();

        //if (productToUpdate != null)
        //{
        //    productToUpdate.Price = 999;
        //    context.SaveChanges();

        //    Console.Write($"Product Id={productToUpdate.Id} price changed to {productToUpdate.Price}\n");
        //}




        #endregion

        #region 26


        //var specificProduct = context.Products.OrderBy(p => p.Id).FirstOrDefault();

        //if (specificProduct != null)
        //{
        //    specificProduct.Price *= 1.15m;
        //    context.SaveChanges();
        //    Console.Write($"Product Id={specificProduct.Id} price increased by 15%: {specificProduct.Price}\n");
        //}


        #endregion

        #region 27

        //var books = context.Products.Where(p => p.Category == "Books").ToList();
        //foreach (var book in books)
        //{
        //    book.Price *= 1.05m;
        //}

        //context.SaveChanges();
        //Console.Write($"Price of all books increased by 5%. Updated records: {books.Count}\n");


        #endregion

        #region 28
        //var productToDelete = context.Products.FirstOrDefault();

        //if (productToDelete != null)
        //{
        //    context.Products.Remove(productToDelete);

        //    context.SaveChanges();

        //    Console.Write($"Deleted product with Id={productToDelete.Id}\n");
        //}

        #endregion



        #region 29

        //var zeroStockProducts = context.Products.Where(p => p.StockQuantity == 0).ToList();

        //context.Products.RemoveRange(zeroStockProducts);
        //context.SaveChanges();





        #endregion



        #region 30

        var oneYearAgo = DateTime.Now.AddYears(-1);

        var oldProducts = context.Products.Where(p => p.CreatedAt < oneYearAgo).ToList();


        context.Products.RemoveRange(oldProducts);
        context.SaveChanges();

        var prod = context.Products;

        foreach (var product in prod)
        {
            Console.Write(product + "\n");
        }





        #endregion







    }

}


