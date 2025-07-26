using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = 0;
        foreach (Product p in _products)
        {
            productTotal += p.GetTotalPrice();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;
        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder("Packing Label:\n");
        foreach (Product p in _products)
        {
            sb.AppendLine(p.GetPackingLabel());
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}

