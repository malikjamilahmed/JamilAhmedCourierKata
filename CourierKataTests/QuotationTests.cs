using CourierKata;
using CourierKata.Contracts;
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
    }
}
