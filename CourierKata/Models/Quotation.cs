using CourierKata.Contracts;
using CourierKata.Enums;
using System.Collections.Generic;

namespace CourierKata.Models
{
    public class Quotation : IQuotation
    {
        public List<IParcel> LineItems { get; set; }

        public int Total { get; set; }

        public ShipmentTypeEnum shipmentType { get; set; }
        public int ShipmentCost { get; set; }
    }
}
