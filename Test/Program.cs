using System;
using WindowsMessagesHelper;

namespace Test {

    internal static class Program {

        private static void Main() {
            Console.WriteLine(WindowsMessagesConversion.DecToString(12)); //WM_SETTEXT
            Console.WriteLine(WindowsMessagesConversion.HexToString(0xc)); //WM_SETTEXT

            Console.WriteLine(WindowsMessagesConversion.StringToDec("WM_SETTEXT")); //12
            Console.WriteLine(WindowsMessagesConversion.StringToHex("WM_SETTEXT")); //000c

            Console.ReadKey();
        }
    }
}