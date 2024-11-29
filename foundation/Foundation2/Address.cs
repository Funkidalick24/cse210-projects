public class Address
{
    private static readonly List<Address> _addresses = [];
    private readonly string _street;
    private readonly string _city;
    private readonly string _stateProvince;
    private readonly string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
        _addresses.Add(this);
    }

    public static Address GetAddress(string street, string city)
    {
        return _addresses.FirstOrDefault(a => a._street == street && a._city == city)
            ?? throw new ArgumentException("Address not found");
    }

    public bool AddressInUSA()
    {
        return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase);
    }

    public string DisplayFullAddress()
    {
        return $"{_street}\n{_city}\n{_stateProvince}\n{_country}";
    }
}
