using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;
public class Mouse : PurchasableProduct
{
    public MotionDetection MotionDetection { get; set; }
    public bool IsUsableWithLeftHand { get; set; } = true;
    public bool HasBluetooth { get; set; } = false;
}

public enum MotionDetection
{
    Optical,
    Laser
}