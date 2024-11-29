public class Order(Customer customer)
{
    private readonly List<Product> _listProducts = [];
    private readonly Customer _customer = customer;
    private decimal _totalPrice;
    private decimal _shippingCost;

    public void AddProduct(Product product)
    {
        _listProducts.Add(product);
    }

    public static void DemonstrateOrders()
    {
        // Create products
        _ = new Product("Laptop", "TECH001", 999.99m, 1);
        _ = new Product("Wireless Mouse", "TECH002", 29.99m, 2);
        _ = new Product("Headphones", "TECH003", 149.99m, 1);
        _ = new Product("Mechanical Keyboard", "TECH004", 89.99m, 1);

        // Create addresses
        Address usaAddress = new("123 Main Street", "Seattle", "WA", "USA");
        Address canadaAddress = new("456 Maple Road", "Toronto", "Ontario", "Canada");

        // Create customers
        _ = new Customer("John Smith", usaAddress);
        _ = new Customer("Marie Johnson", canadaAddress);

        // Create orders
        Order usaOrder = new(new Customer("John Smith", usaAddress));
        usaOrder.AddProduct(new Product("Laptop", "TECH001", 999.99m, 1));
        usaOrder.AddProduct(new Product("Wireless Mouse", "TECH002", 29.99m, 2));
        usaOrder.DisplayOrderDetails();

        Order internationalOrder = new(new Customer("Marie Johnson", canadaAddress));
        internationalOrder.AddProduct(new Product("Headphones", "TECH003", 149.99m, 1));
        internationalOrder.AddProduct(new Product("Mechanical Keyboard", "TECH004", 89.99m, 1));
        internationalOrder.DisplayOrderDetails();
    }

    public decimal CalculateShippingCost()
    {
        _shippingCost = _customer.CustomerInUSA() ? 5 : 35;
        return _shippingCost;
    }

    public decimal CalculateTotalPrice()
    {
        _totalPrice = _listProducts.Sum(static p => p.GetPrice() * p.Quantity());
        return _totalPrice;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _listProducts.Select(static p =>
            $"Name: {p.GetName()}, ID: {p.GetID()}"));
    }

    public string GetShippingLabel()
    {
        return $"Customer: {_customer.GetName()}\n" +
               $"Address:\n{_customer.GetAddress().DisplayFullAddress()}";
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(GetPackingLabel());

        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(GetShippingLabel());

        Console.WriteLine($"\nShipping Cost: ${CalculateShippingCost()}");
        Console.WriteLine($"Total Price: ${CalculateTotalPrice()}");
        Console.WriteLine("----------------------------------------");
    }
}
