using CourierKata.Contracts;
using System.Collections.Generic;

namespace CourierKata.Models
{
    public class Quotation : IQuotation
    {
        public List<IParcel> LineItems { get; set; }

        public int Total { get; set; }
    }
}
