public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer = new Customer();

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var item in _products)
        {
            label += $"\t- {item.GetQuantity()} x {item.GetPrice()}\t| {item.GetName()} - {item.GetID()}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} - {_customer.GetAddress()}";
    }

    public int GetShippingCost()
    {
        return _customer.IsFromUSA() ? 5 : 35;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (var item in _products)
        {
            totalPrice += item.GetTotalCost();
        }

        totalPrice += GetShippingCost();

        return totalPrice;
    }
}