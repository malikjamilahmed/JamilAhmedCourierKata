using CourierKata.Enums;
using System.Collections.Generic;

namespace CourierKata.Contracts
{
    public interface IQuotation
    {
        List<IParcel> LineItems { get; set; }

        int Total { get; set; }

        ShipmentTypeEnum shipmentType { get; set; }
        int ShipmentCost { get; set; }
    }
}
