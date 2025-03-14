﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class Keyboard : PurchasableProduct
{
    public KeyboardFormfactor? KeyboardFormfactor { get; set; }
    public KeyCapProfile? KeyCapProfile { get; set; }
    public KeyCapMaterial? KeyCapMaterial { get; set; }
    public KeySwitch? KeySwitch { get; set; }
    public bool HasBluetooth { get; set; }
    public bool HasRGB { get; set; }
}

public enum KeyboardFormfactor
{
    Full,
    TKL,
    Compact
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
public enum KeySwitch
{
    Linear,
    Tactile,
    Clicky
}