// Импортировать статические члены классов Console и DateTime.
using static System.Console;
using static System.DateTime;

namespace TestNetFramework
{
    public static class TimeUtilClass
    {
        public static void PrintTime()
        { WriteLine(Now.ToShortTimeString()); }
        public static void PrintDate()
        { WriteLine(Today.ToShortDateString()); }
    }
}
