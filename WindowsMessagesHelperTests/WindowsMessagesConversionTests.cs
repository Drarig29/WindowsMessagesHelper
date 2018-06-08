using WindowsMessagesHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsMessagesHelperTests {

    [TestClass]
    public class WindowsMessagesConversionTests {

        [TestMethod]
        public void DecToStringTest() {
            Assert.AreEqual(WindowsMessagesConversion.DecToString(12), "WM_SETTEXT");
            Assert.AreEqual(WindowsMessagesConversion.DecToString(-1), null);
            Assert.AreEqual(WindowsMessagesConversion.DecToString(799), null); //doesn't exist
        }

        [TestMethod]
        public void HexToStringTest() {
            Assert.AreEqual(WindowsMessagesConversion.HexToString(0xC), "WM_SETTEXT");
            Assert.AreEqual(WindowsMessagesConversion.HexToString(-0x1), null);
            Assert.AreEqual(WindowsMessagesConversion.HexToString(0x31f), null); //799
        }

        [TestMethod]
        public void StringToDecTest() {
            Assert.AreEqual(WindowsMessagesConversion.StringToDec("WM_SETTEXT"), "12");
            Assert.AreEqual(WindowsMessagesConversion.StringToDec(""), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToDec(null), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToDec("random string"), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToDec("WM_HELLO"), null);
        }

        [TestMethod]
        public void StringToHexTest() {
            Assert.AreEqual(WindowsMessagesConversion.StringToHex("WM_SETTEXT"), "000c");
            Assert.AreEqual(WindowsMessagesConversion.StringToHex(""), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToHex(null), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToHex("random string"), null);
            Assert.AreEqual(WindowsMessagesConversion.StringToHex("WM_HELLO"), null);
        }
    }
}