using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace WindowsFormsApplication1.Com
{
    public class jlmk
    {
        public static string PortName = "COM1";
        public static int BaudRate = 9600;
        public static StopBits StopBits = StopBits.One;
        public static int DataBits = 8;
        public static Parity Parity = Parity.None;

        //读交流电压
        public static string readjldy = "81 C1 01 0A 84 01 00 00 00 CE";

    }
}
