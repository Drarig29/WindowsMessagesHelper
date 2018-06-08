using System.Globalization;
using Jil;
using System.IO;
using System.Linq;
// ReSharper disable UnusedAutoPropertyAccessor.Local

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable ClassNeverInstantiated.Local

namespace WindowsMessagesHelper {

    public class WindowsMessagesConversion {

        private static WindowsMessage[] _data;

        private class WindowsMessage {
            public string hex { get; set; }
            public string dec { get; set; }
            public string name { get; set; }
        }

        private static void InitData() {
            if (_data == null) {
                _data = JSON.Deserialize<WindowsMessage[]>(
                    new StreamReader(new MemoryStream(Properties.Resources.data)));
            }
        }

        public static string DecToString(int dec) {
            InitData();
            var test = _data.FirstOrDefault(b => b.dec == dec.ToString())?.name;

            return test;
        }

        public static string HexToString(int hex) {
            InitData();
            return _data.First(b => int.Parse(b.hex, NumberStyles.HexNumber) == hex).name;
        }

        public static string StringToDec(string name) {
            InitData();
            return _data.First(b => b.name == name).dec;
        }

        public static string StringToHex(string name) {
            InitData();
            return _data.First(b => b.name == name).hex;
        }
    }
}