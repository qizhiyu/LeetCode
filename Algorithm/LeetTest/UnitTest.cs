using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod76()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinWindow("ADOBECODEBANC", "ABCF"), "", false);
            Assert.AreEqual(s.MinWindow("ADOBECODEBANC", "ABC"), "BANC", false);
        }

        [TestMethod]
        public void TestMethodEnc()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.Encrypt("abc"), "klm", false);
            Assert.AreEqual(s.Encrypt("abcwxy"), "klm\"#$", false);
        }

    }
}
