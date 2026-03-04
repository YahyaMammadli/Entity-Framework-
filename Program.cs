using Microsoft.EntityFrameworkCore;
using Data.AppDBContext;
using Categories;
using Supliers;
using Orders;
using Products;



namespace Program;

class Program
{

    static void  GetProducts() // Я хотел сделать это методм типа DbSet<Product> но проблема в том что у него нету дефолтного коструктора поэтому в catch я не могу пустой DbSet<Product>
    {

        //IQueryable<Product> productsFromDb;

        try
        {
            using (var context = new AppDBContext())
            {
                var productsFromDb = context.Products.Where(x => x.IsDiscontinued == false).AsNoTracking();

                foreach (var item in productsFromDb)
                {
                    Console.Write(item + "\n");
                }

            }

            //return productsFromDb;

        }
        catch (Exception ex)
        {
            Console.Write($"{ex.Message}\n\n");

            //return new DbSet<Product>;
        }



    }







    static int CountingProduct()
    {

        int products;

        try
        {

            using (var context = new AppDBContext())
            {
                products = context.Products.Count(x => x.IsDiscontinued == false);
            }

            return products;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message + "\n");

            return 0;
            
        }

        
    }





    static void AddSuppliers(Suplier suplier)
    {

        try
        {
            using(var context = new AppDBContext())
            {

            context.Supliers.Add(suplier);

            context.SaveChanges();

            

            }

        }
        catch ( Exception ex)
        {
            Console.Write(ex.Message + "\n");

            
        }



    }



    static void UpdatePrice(int id, decimal amount)
    {


        try
        {
            using (var context = new AppDBContext())
        {
            var productsFromDb = context.Products.Where(x => x.SupplierId == id);

            foreach (var suplier in productsFromDb)
            {
                suplier.UnitPrice *= amount;


            }

            context.SaveChanges();


        }

        }
        catch (Exception ex )
        {
            Console.Write(ex.Message + "\n");

        }




    }


    static void AddCategories(Category category)
    {

        try
        {
            using (var context = new AppDBContext())
        {

            context.Categories.Add(category);

            context.SaveChanges();


        }

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message + "\n");
        }



    }



    static void GetCategories()
    {

        try
        {

            using (var context = new AppDBContext())
            {
                var categoriesFromDB = context.Categories.AsNoTracking();

                foreach (var category in categoriesFromDB)
                {
                    Console.Write(category + "\n");
                }

                //return categoriesFromDB;
            }
        }
        catch (Exception ex)
        {

            Console.Write(ex.Message + "\n");
            //return new DbSet();

        }




    }

    
    

    static void GetCustomersWithOrders()
    {

        try
        {

            using (var context = new AppDBContext())
            {
                var customer = context.Customers.AsNoTracking().Include(c => c.Orders);

                foreach (var item in customer)
                {
                    foreach (var order in item.Orders)
                    {
                        Console.Write(order + "\n");
                    }


                }

            }


        }
        catch (Exception ex)
        {

            Console.Write(ex.Message + "\n");


        }


    }
    

    static decimal GetMaxProductPrice()
    {
        decimal maxUnitPrice;

        

        try
        {

            using (var context = new AppDBContext())
            {


                maxUnitPrice = context.Products.AsNoTracking().Max(p => p.UnitPrice);
            }


            return maxUnitPrice;

        }
        catch (Exception ex)
        {

            Console.Write(ex.Message + "\n");

            return 0;
        }


    }





    static void Main()
    {

        //GetProducts();


        //Console.WriteLine("Count => " + CountingProduct() + "\n");


        //Suplier suplier = new Suplier("Meta","San Jose","USA");
        //AddSuppliers(suplier);


        //UpdatePrice(1, 100);


        //Category category = new Category("Grocery", "Сereal and pasta");
        //AddCategories(category);


        //GetCategories();



        //GetCustomersWithOrders();


        //Console.WriteLine($"Highest Product price => {GetMaxProductPrice()}\n");




    }
}
