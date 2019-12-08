using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleConfiguration.WPF.Helper
{
    public enum PackageTypeList : int
    {
        Standart = 0,
        Special = 1
    }

    public enum VehicleFeaturesTypeList : int
    {
        BodyList = 1,
        EngineList = 2,
        GearboxList = 3,
        ColorList = 4,
        FloorList = 5,
        OptionList = 6
    }

    public enum OrderStatus
    {
        Draft = 1,
        Canceled = 2,
        Completed = 3
    }
}
