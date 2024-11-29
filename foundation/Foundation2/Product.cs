public class Product
{
    private string _name;
    private string _id;
    private decimal _itemPrice;
    private decimal _totalPrice;
    private int _quantity;

    public Product(string name, string id, decimal price, int quantity)
    {
        _name = name;
        _id = id;
        _itemPrice = price;
        _quantity = quantity;
        CalculateTotalPrice();
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public decimal GetPrice()
    {
        return _itemPrice;
    }

    public void SetPrice(decimal price)
    {
        _itemPrice = price;
        CalculateTotalPrice();
    }

    public int Quantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
        CalculateTotalPrice();
    }

    public string GetID()
    {
        return _id;
    }

    public void SetID(string id)
    {
        _id = id;
    }

    public void CalculateTotalPrice()
    {
        _totalPrice = _itemPrice * _quantity;
    }

    public decimal GetTotalPrice()
    {
        return _totalPrice;
    }
}
