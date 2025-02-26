using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class Keyboard : PurchasableProduct
{
    public bool HasRGB { get; set; } = false;
    public bool HasBluetooth { get; set; } = false;
    public (string Designation, int AmountOfKeys) FormFactor {  get; set; }
    public KeyCap KeyCapType { get; set; }
    public KeySwitch KeySwitch {  get; set; }

}
