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

        /// <summary>
        /// Converts a Windows message decimal id to its string representation.
        /// </summary>
        /// <param name="dec">The Windows message's decimal id.</param>
        /// <returns>The string value representing the Windows message. Returns null if not found.</returns>
        public static string DecToString(int dec) {
            InitData();
            return _data.FirstOrDefault(b => b.dec == dec.ToString())?.name;
        }

        /// <summary>
        /// Converts a Windows message hexadecimal id to its string representation.
        /// </summary>
        /// <param name="hex">The Windows message's hexadecimal id.</param>
        /// <returns>The string value representing the Windows message. Returns null if not found.</returns>
        public static string HexToString(int hex) {
            InitData();
            return _data.FirstOrDefault(b => int.Parse(b.hex, NumberStyles.HexNumber) == hex)?.name;
        }

        /// <summary>
        /// Converts a Windows message string representation to its decimal id.
        /// </summary>
        /// <param name="name">The Windows message's string representation.</param>
        /// <returns>The Windows message's decimal id. Returns null if not found.</returns>
        public static string StringToDec(string name) {
            InitData();
            return _data.FirstOrDefault(b => b.name == name)?.dec;
        }

        /// <summary>
        /// Converts a Windows message string representation to its hexadecimal id.
        /// </summary>
        /// <param name="name">The Windows message's string representation.</param>
        /// <returns>The Windows message's hexadecimal id. Returns null if not found.</returns>
        public static string StringToHex(string name) {
            InitData();
            return _data.FirstOrDefault(b => b.name == name)?.hex;
        }
    }
}