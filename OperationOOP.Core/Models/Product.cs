using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public int ManufacturersId { get; set; }
}

public class PurchasableProduct : Product, IPurchasable
{
    public int InStock { get; set; }
    public decimal Price { get; set; }

    public int AmountInStockAfterPurchase(int amount) => InStock - amount;
    public bool IsValidAmountToBePurchased(int amount) => InStock > amount ? true : false;
}


public interface IPurchasable
{
    int InStock { get; set; }
    decimal Price { get; set;}
    bool IsValidAmountToBePurchased(int amount);
    int AmountInStockAfterPurchase(int amount);

}