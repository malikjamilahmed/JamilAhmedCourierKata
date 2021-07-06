using CourierKata;
using CourierKata.Contracts;
using CourierKata.Enums;
using CourierKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourierKataTests
{
    [TestClass]
    public class QuotationDiscountTests
    {
        [TestMethod]
        public void verify_discount_calculation_on_small_parcels() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 9, 1),//$3
                    new Parcel(2, 2, 9, 2),//$5 -- This should be discounted
                    new Parcel(2, 2, 9, 3),//$7
                    new Parcel(2, 2, 9, 4),//$9
                    new Parcel(2, 2, 9, 5)//$11
                });

            Assert.AreEqual(result.Total, 30);
            Assert.AreEqual(result.Discount, 5);
        }

        [TestMethod]
        public void verify_discount_calculation_on_medium_parcels() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    new Parcel(2, 2, 20, 1),//$8
                    new Parcel(2, 2, 20, 4),//$10
                    new Parcel(2, 2, 20, 5),//$12 -- This should be discounted
                    new Parcel(2, 2, 20, 6),//$14
                    new Parcel(2, 2, 20, 7),//$16 
                });

            Assert.AreEqual(result.Total, 48);
            Assert.AreEqual(result.Discount, 12);
        }

        [TestMethod]
        public void verify_discount_calculation_on_mixed_parcels() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    //small
                    new Parcel(2, 2, 9, 1),//$3
                    new Parcel(2, 2, 9, 6),//$13 -- This should be discounted
                    new Parcel(2, 2, 9, 7),//$15
                    new Parcel(2, 2, 9, 8),//$17
                    new Parcel(2, 2, 9, 9),//$19
                    //medium
                    new Parcel(2, 2, 20, 1),//$8
                    new Parcel(2, 2, 20, 6),//$14
                    new Parcel(2, 2, 20, 7),//$16 -- This should be discounted
                    new Parcel(2, 2, 20, 8),//$18
                    new Parcel(2, 2, 20, 9),//$20 
                    //large
                    new Parcel(2, 2, 60, 1),//$15
                    new Parcel(2, 2, 60, 2),//$15 -- This should be discounted
                    new Parcel(2, 2, 60, 3),//$15 
                    new Parcel(2, 2, 60, 4),//$15
                    new Parcel(2, 2, 60, 5),//$15 
                });

            Assert.AreEqual(result.Total, 54 + 60 + 60);
            Assert.AreEqual(result.Discount, 13 + 16 + 15);
        }


        [TestMethod]
        public void verify_total_is_doubled_after_discount_for_speedy_delivery() {

            var qutationCalculator = new QuotationCalculator();
            var result = qutationCalculator.CalcualteQuotation(
                new List<IParcel> {
                    //small
                    new Parcel(2, 2, 9, 1),//$3
                    new Parcel(2, 2, 9, 6),//$13 -- This should be discounted
                    new Parcel(2, 2, 9, 7),//$15
                    new Parcel(2, 2, 9, 8),//$17
                    new Parcel(2, 2, 9, 9),//$19
                    //medium
                    new Parcel(2, 2, 20, 1),//$8
                    new Parcel(2, 2, 20, 6),//$14
                    new Parcel(2, 2, 20, 7),//$16 -- This should be discounted
                    new Parcel(2, 2, 20, 8),//$18
                    new Parcel(2, 2, 20, 9),//$20 
                    //large
                    new Parcel(2, 2, 60, 1),//$15
                    new Parcel(2, 2, 60, 2),//$15 -- This should be discounted
                    new Parcel(2, 2, 60, 3),//$15 
                    new Parcel(2, 2, 60, 4),//$15
                    new Parcel(2, 2, 60, 5),//$15 
                }, ShipmentTypeEnum.Speedy);

            Assert.AreEqual(result.Total, (54 + 60 + 60) * 2);
            Assert.AreEqual(result.Discount, 13 + 16 + 15);
        }
    }
}