using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class KeyCap : PurchasableProduct
{
    public KeyCapProfile Profile { get; set; }
    public KeyCapMaterial Material { get; set; }
    public bool AllowsShineThrough { get; set; } = false;
}

public enum KeyCapProfile
{
    Cherry,
    OEM,
    XDA,
    DSA
}
public enum KeyCapMaterial
{
    ABS,
    PBT
}