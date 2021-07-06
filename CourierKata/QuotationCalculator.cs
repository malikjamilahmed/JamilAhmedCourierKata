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
        Dictionary<ParcelSizeEnum, int> _maxSizes = new Dictionary<ParcelSizeEnum, int>() {
            { ParcelSizeEnum.Small, 1  }, { ParcelSizeEnum.Medium, 3  }, { ParcelSizeEnum.Large, 6  },
            { ParcelSizeEnum.XL, 10  }, { ParcelSizeEnum.Heavy, 50}
        };

        Dictionary<ParcelSizeEnum, int> _excessiveWeightMultiplier = new Dictionary<ParcelSizeEnum, int>() {
            { ParcelSizeEnum.Small, 2  }, { ParcelSizeEnum.Medium, 2  }, { ParcelSizeEnum.Large, 2  },
            { ParcelSizeEnum.XL, 2 }, {ParcelSizeEnum.Heavy, 1 }
        };

        public IQuotation CalcualteQuotation(List<IParcel> parcels, ShipmentTypeEnum shipmentType = ShipmentTypeEnum.Standard) {

            parcels.ForEach(p => {
                CalculateSize(p);
                CalculateParcelCost(p);
            });

            var quotation = new Quotation() {
                LineItems = parcels,
                shipmentType = shipmentType,
                Total = parcels.Sum(p => p.Cost)
            };

            if (shipmentType == ShipmentTypeEnum.Speedy) {
                quotation.ShipmentCost = quotation.Total;
                quotation.Total = quotation.Total * 2;
            }

            return quotation;
        }

        public void CalculateSize(IParcel parcel) {

            if (parcel.Weight > 10) {
                parcel.Size = ParcelSizeEnum.Heavy;
                return;
            }

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
                case Enums.ParcelSizeEnum.Heavy:
                    parcel.Cost = 50;
                    break;
            }

            if (parcel.Weight > _maxSizes[parcel.Size])
                parcel.Cost += (parcel.Weight - _maxSizes[parcel.Size]) * _excessiveWeightMultiplier[parcel.Size];
        }
    }
}
