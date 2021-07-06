using CourierKata;
using CourierKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourierKataTests
{
    [TestClass]
    public class ParcelSizeCalculationTests
    {
        [TestMethod]
        public void verify_small_size_calcuation() {
            var parcel = new Parcel(2, 2, 9);

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateSize(parcel);

            Assert.AreEqual(parcel.Size, CourierKata.Enums.ParcelSizeEnum.Small);
        }

        [TestMethod]
        public void verify_medium_size_calcuation() {
            var parcel = new Parcel(2, 2, 49);

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateSize(parcel);

            Assert.AreEqual(parcel.Size, CourierKata.Enums.ParcelSizeEnum.Medium);
        }

        [TestMethod]
        public void verify_large_size_calcuation() {
            var parcel = new Parcel(2, 2, 99);

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateSize(parcel);

            Assert.AreEqual(parcel.Size, CourierKata.Enums.ParcelSizeEnum.Large);
        }

        [TestMethod]
        public void verify_xl_size_calcuation() {
            var parcel = new Parcel(100, 2, 9);

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateSize(parcel);

            Assert.AreEqual(parcel.Size, CourierKata.Enums.ParcelSizeEnum.XL);
        }

        [TestMethod]
        public void verify_heavy_size_calcuation() {
            var parcel = new Parcel(1, 1, 1, 11);

            var qutationCalculator = new QuotationCalculator();
            qutationCalculator.CalculateSize(parcel);

            Assert.AreEqual(parcel.Size, CourierKata.Enums.ParcelSizeEnum.Heavy);
        }
    }
}
