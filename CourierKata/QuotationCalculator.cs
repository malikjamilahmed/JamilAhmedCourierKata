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

        /// <summary>
        /// To get the quote for parcels by passing parcel collection and shipment type
        /// </summary>
        /// <param name="parcels"></param>
        /// <param name="shipmentType"></param>
        /// <returns></returns>
        public IQuotation CalcualteQuotation(List<IParcel> parcels, ShipmentTypeEnum shipmentType = ShipmentTypeEnum.Standard) {

            parcels.ForEach(p => {
                CalculateSize(p);
                CalculateParcelCost(p);
            });

            int discount = CalculateDiscount(parcels);

            var quotation = new Quotation() {
                LineItems = parcels,
                ShipmentType = shipmentType,
                Discount = discount,
                Total = parcels.Sum(p => p.Cost) - discount
            };

            if (shipmentType == ShipmentTypeEnum.Speedy) {
                quotation.ShipmentCost = quotation.Total;
                quotation.Total = quotation.Total * 2;
            }

            return quotation;
        }

        /// <summary>
        /// For evaluating parcel size. 
        /// Note: This method must be called for each parcel before calling CalculateParcelCost
        /// </summary>
        /// <param name="parcel"></param>
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

        /// <summary>
        /// For evaluating parcel cost and setting back Cost property of parcel object
        /// </summary>
        /// <param name="parcel"></param>
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
                
        /// <summary>
        /// I have divided this into 3 categories small, medium and mixed mania
        /// Calculating max discout for small parcels, then medium and then remaining once.
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns></returns>
        public int CalculateDiscount(List<IParcel> parcels) {
            int discount = 0;
            var clonedParcels = new List<IParcel>(parcels);

            var smallParcels = clonedParcels.Where(p => p.Size == ParcelSizeEnum.Small).OrderBy(p => p.Cost).ToList();
            discount += CalculateCombinationDiscount(clonedParcels, smallParcels, 4);

            var mediumParcels = clonedParcels.Where(p => p.Size == ParcelSizeEnum.Medium).OrderBy(p => p.Cost).ToList();
            discount += CalculateCombinationDiscount(clonedParcels, mediumParcels, 3);

            discount += CalculateCombinationDiscount(clonedParcels, clonedParcels, 5);

            return discount;
        }

        /// <summary>
        /// Helper Discout method for calculating max dicount in each combination
        /// </summary>
        /// <param name="allParcels"></param>
        /// <param name="combinationParcels"></param>
        /// <param name="combinationSize"></param>
        /// <returns></returns>
        private static int CalculateCombinationDiscount(List<IParcel> allParcels, List<IParcel> combinationParcels, int combinationSize) {

            int discount = 0;

            while (combinationParcels.Count >= combinationSize) {
                var discountableGroup = combinationParcels.TakeLast(combinationSize);
                discount += discountableGroup.First().Cost;
                allParcels.RemoveAll(p => discountableGroup.Contains(p));
                combinationParcels.RemoveAll(p => discountableGroup.Contains(p));
            }

            return discount;
        }
    }
}
