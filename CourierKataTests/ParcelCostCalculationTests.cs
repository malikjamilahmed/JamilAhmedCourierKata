using CourierKata;
using CourierKata.Enums;
using CourierKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourierKataTests
{
    [TestClass]
    public class ParcelCostCalculationTests
    {
        [TestMethod]
        public void verify_small_parcel_cost_calcuation() {
            var parcel = new Parcel(2, 2, 9) { Size = ParcelSizeEnum.Small };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 3);
        }

        [TestMethod]
        public void verify_medium_parcel_cost_calcuation() {
            var parcel = new Parcel(2, 2, 49) { Size = ParcelSizeEnum.Medium };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 8);
        }

        [TestMethod]
        public void verify_large_parcel_cost_calcuation() {
            var parcel = new Parcel(2, 2, 99) { Size = ParcelSizeEnum.Large };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 15);
        }

        [TestMethod]
        public void verify_xl_parcel_cost_calcuation() {
            var parcel = new Parcel(100, 2, 9) { Size = ParcelSizeEnum.XL };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 25);
        }
        [TestMethod]
        public void verify_small_parcel_cost_calcuation_for_extra_weight() {
            var parcel = new Parcel(2, 2, 9, 5) { Size = ParcelSizeEnum.Small };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 11);
        }

        [TestMethod]
        public void verify_medium_parcel_cost_calcuation_for_extra_weight() {
            var parcel = new Parcel(2, 2, 49, 12) { Size = ParcelSizeEnum.Medium };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 26);
        }

        [TestMethod]
        public void verify_large_parcel_cost_calcuation_for_extra_weight() {
            var parcel = new Parcel(2, 2, 99, 14) { Size = ParcelSizeEnum.Large };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 31);
        }

        [TestMethod]
        public void verify_xl_parcel_cost_calcuation_for_extra_weight() {
            var parcel = new Parcel(100, 2, 9, 20) { Size = ParcelSizeEnum.XL };

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateParcelCost(parcel);

            Assert.AreEqual(parcel.Cost, 45);
        }
    }
}
