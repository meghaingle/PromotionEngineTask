using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineTaskTest;
using static PromotionEngineTask.Program;

namespace PromotionEngineTaskTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ExpectedResult = "Passed";
            var originalResult = string.Empty;
            TestPromotion obj = new TestPromotion();
            obj.TestPromotionEngine();
            Assert.Equals(ExpectedResult, originalResult);
        }
    }
}
