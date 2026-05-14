using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns.Flyweight
{    public static class MemorySizeConverter
    {
        public enum SizeUnit { Byte = 1, KB = 2, MB = 3, GB = 4, TB = 5 }
        private static int _factor = 1024;
        private static string _displayFormat = "0.00";
        private static SizeUnit _maxSizeUnit = Enum.GetValues(typeof(SizeUnit)).Cast<SizeUnit>().Max();

        public static string ToSmallestFullSize(this long value)
        {
            double nextValue = value;
            SizeUnit currentSizeUnit = SizeUnit.Byte;
            while (nextValue > _factor && currentSizeUnit != _maxSizeUnit)
            {
                currentSizeUnit++;
                nextValue = nextValue / _factor;
            }
            return $"{nextValue.ToString(_displayFormat)} {currentSizeUnit}";
        }
    }

    static class MemoryMonitor
    {
        public static void CheckCurrentProcess()
        {
            Process proc = Process.GetCurrentProcess();
            proc.Refresh(); 
            Console.WriteLine($"   Private Memory: {proc.PrivateMemorySize64.ToSmallestFullSize()}");
            Console.WriteLine($"   Physical Memory (Working Set): {proc.WorkingSet64.ToSmallestFullSize()}");
        }
    }
}