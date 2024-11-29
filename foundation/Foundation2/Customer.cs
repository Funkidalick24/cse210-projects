public class Customer
{
    private static readonly List<Customer> _customers = [];
    private readonly string _name;
    private readonly Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
        _customers.Add(this);
    }

    public static Customer GetCustomer(string name)
    {
        return _customers.FirstOrDefault(c => c._name == name)
            ?? throw new ArgumentException("Customer not found");
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool CustomerInUSA()
    {
        return _address.AddressInUSA();
    }
}
