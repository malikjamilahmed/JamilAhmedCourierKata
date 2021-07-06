using CourierKata.Contracts;
using CourierKata.Enums;
using CourierKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierKata
{
    public class QuotationCalculator
    {

        public IQuotation CalcualteQuotation(List<IParcel> parcels) {

            parcels.ForEach(p => {
                CalculateSize(p);
                CalculateParcelCost(p);
            });

            var quotation = new Quotation() {
                LineItems = parcels,
                Total = parcels.Sum(p => p.Cost)
            };

            return quotation;
        }

        public void CalculateSize(IParcel parcel) {
            var longestDimension = parcel.Length;
            if (parcel.Width > longestDimension)
                longestDimension = parcel.Width;
            if (parcel.Height > longestDimension)
                longestDimension = parcel.Height;

            if (longestDimension < 10)
                parcel.Size = ParcelSizeEnum.Small;
            else if (longestDimension < 50)
                parcel.Size = ParcelSizeEnum.Medium;
            else if (longestDimension < 100)
                parcel.Size = ParcelSizeEnum.Large;
            else
                parcel.Size = ParcelSizeEnum.XL;
        }

        public void CalculateParcelCost(IParcel parcel) {

            switch (parcel.Size) {
                case Enums.ParcelSizeEnum.Small:
                    parcel.Cost = 3;
                    break;
                case Enums.ParcelSizeEnum.Medium:
                    parcel.Cost = 8;
                    break;
                case Enums.ParcelSizeEnum.Large:
                    parcel.Cost = 15;
                    break;
                case Enums.ParcelSizeEnum.XL:
                    parcel.Cost = 25;
                    break;
            }
        }
    }
}
