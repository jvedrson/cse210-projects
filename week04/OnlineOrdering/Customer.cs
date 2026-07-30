public class Customer
{
    private string _name;
    private Address _address = new Address();

    public Customer() {}

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public Customer(string name, string street, string city, string state, string country)
    {
        _name = name;
        SetAddress(street, city, state, country);
    }
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetAddress()
    {
        return _address.FullAddress();
    }

    public void SetAddress(string street, string city, string state, string country)
    {
        _address.SetStreet(street);
        _address.SetCity(city);
        _address.SetState(state);
        _address.SetCountry(country);
    }

    public bool IsFromUSA()
    {
        return _address.IsLivingInUSA();
    }
}