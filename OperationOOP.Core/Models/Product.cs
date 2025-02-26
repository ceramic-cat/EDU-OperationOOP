using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class Product
{
    int Id { get; set; }
    string Name { get; set; }
    string Manufacturer { get; set; }
    int ManufacturerId { get; set; }
}

public class PurchasableProduct : IPurchasable
{
    public int InStock { get; private set; }
    public decimal Price { get; private set; }

    public int AmountInStockAfterPurchase(int amount) => InStock - amount;
    public bool IsValidAmountToBePurchased(int amount) => InStock > amount ? true : false;
}


public interface IPurchasable
{
    int InStock { get; }
    decimal Price { get; }
    bool IsValidAmountToBePurchased(int amount);
    int AmountInStockAfterPurchase(int amount);

}