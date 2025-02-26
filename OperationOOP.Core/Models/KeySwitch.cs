using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class KeySwitch : PurchasableProduct
{
    public KeySwitchType Type { get; set; }
    public decimal ActuationDistanceMillimeter { get; set; }
    public int ActuationForceGrams { get; set; }

}
public enum KeySwitchType
{
    Linear,
    Tactile,
    Clicky
}