using CourierKata.Enums;
using System.Collections.Generic;

namespace CourierKata.Contracts
{
    public interface IQuotation
    {
        List<IParcel> LineItems { get; set; }

        int Total { get; set; }

        ShipmentTypeEnum ShipmentType { get; set; }

        int ShipmentCost { get; set; }

        int Discount { get; set; }
    }
}
