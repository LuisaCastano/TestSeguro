using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance.Core.Services;

namespace Insurance.Tests
{
    [TestClass]
    public class BusinessRulesTest
    {
        [TestMethod()]
        public void CheckRiskKindTest()
        {
            var risk = 1;
            var percent = 50;
            var expect = true;
            var sevice = new Service();
            bool actual = sevice.CheckRiskKind(risk, percent);
            Assert.AreEqual(expect, actual);
        }
    }
}
