
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

//put your greeting here

//implement your loop here
string greeting = "Welcome to Brass and Poem";
Console.WriteLine(greeting);

List<Product> products = new List<Product>()
{

   new Product()
{
    Name = "The Raven",
    Price = 15,
    ProductTypeId = 2
},

new Product()
{
    Name = "Ode to Joy",
    Price = 18,
    ProductTypeId = 3
},

new Product()
{
    Name = "The Odyssey",
    Price = 25,
    ProductTypeId = 4
},

new Product()
{
    Name = "Symphony of Brass",
    Price = 22,
    ProductTypeId = 1
}

};

List<ProductType> productTypes = new List<ProductType>()
{
new ProductType()
{
    Title = "Drama",
    Id = 1
},
new ProductType()
{
    Title = "Suspense",
    Id = 2
}
};


string choice = null;

while(choice != "5")
{ 
    DisplayMenu();
    

    switch (choice)
    {
        case "1":

        DisplayAllProducts(products, productTypes);

        break;

        case "2":

        DeleteProduct(products, productTypes);

        break;

        case "3":

        AddProduct(products, productTypes);

        break;

        case "4":

        UpdateProduct(products, productTypes);

        break;

        case "5":

        break;

    }
}



void DisplayMenu()
{
    Console.WriteLine(@"chose an option:
    1. Display all products 
    2. Delete a product
    3. Add a new product
    4. Update product properties
    5. Exit"
    );

    choice = Console.ReadLine();

    
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("All Products:");
    for (int i = 0; i < products.Count; i++)
    {
       string productType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId)?.Title ?? "unknown";
       Console.WriteLine($"{i + 1}. {products[i].Name}, Price: {products[i].Price}, Type: {productType}");
    }

    
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine($"Enter the number product to delete");
    if(int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= products.Count)
    {
        products.RemoveAt(productNumber - 1);
        Console.WriteLine("Product deleted !");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine($"Enter product name");
    string name = Console.ReadLine();
    
    Console.WriteLine($"Enter product price");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine($"Product Types:");
    for( int i = 0; i < productTypes.Count; i++)
    Console.WriteLine($" Id: {productTypes[i].Id}. {productTypes[i].Title}");

    Console.WriteLine($"Enter product type Id:");

    if (int.TryParse(Console.ReadLine(), out int productTypeId) && productTypes.Any(pt => pt.Id == productTypeId))
    {
        products.Add(new Product() { Name = name, Price = price, ProductTypeId = productTypeId } );
        Console.WriteLine("Product added !!");
    }


}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine($"Enter the product number to update:");

    if(int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= products.Count)
    {
        Product productToUpdate = products[productNumber - 1];

        Console.WriteLine($"Press Enter or type new name:");
        string newName = Console.ReadLine();

        if(!string.IsNullOrEmpty(newName))
        {
            productToUpdate.Name = newName;
        } 
    

    Console.WriteLine($"Press Enter or digit new  price");

    string newPrice = Console.ReadLine();
    if (decimal.TryParse(newPrice, out decimal parsedPrice))
    {
        productToUpdate.Price = parsedPrice;
    }

    Console.WriteLine($"Product types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title}");
    }

    Console.WriteLine($"PressEnter or type new product Id :");

    string newId = Console.ReadLine();
    if(int.TryParse(newId, out int parsedId) && productTypes.Any(pt => pt.Id == parsedId))
    {
        productToUpdate.ProductTypeId = parsedId;
    }



    Console.WriteLine($"Product updated!!");


    }

}

// don't move or change this!
public partial class Program { }