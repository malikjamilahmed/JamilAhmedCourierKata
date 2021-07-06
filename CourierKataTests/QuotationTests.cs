using CourierKata;
using CourierKata.Contracts;
using CourierKata.Enums;
using CourierKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourierKataTests
{
    [TestClass]
    public class QuotationTests
    {
        [TestMethod]
        public void verify_quotation_total() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9), new Parcel(2, 49, 9)
                });

            Assert.AreEqual(result.Total, 11);
        }

        [TestMethod]
        public void verify_shipment_type_in_output() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9), new Parcel(2, 49, 9)
                }, ShipmentTypeEnum.Speedy);

            Assert.AreEqual(result.shipmentType, ShipmentTypeEnum.Speedy);
        }

        [TestMethod]
        public void verify_total_for_speedy_shipment_should_be_double() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9), new Parcel(2, 49, 9)
                }, ShipmentTypeEnum.Speedy);

            Assert.AreEqual(result.Total, 22);
        }

        [TestMethod]
        public void verify_calculation_of_shipment_cost_for_speedy_shipment() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9), new Parcel(2, 49, 9)
                }, ShipmentTypeEnum.Speedy);

            Assert.AreEqual(result.ShipmentCost, 11);
        }

        [TestMethod]
        public void verify_shipment_cost_for_standandard_shipment_should_be_zero() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9), new Parcel(2, 49, 9)
                });

            Assert.AreEqual(result.ShipmentCost, 0);
        }
    }
}
