using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1.Com
{
    public class jlmk
    {
        public static SerialPort com;

        public static string PortName = "COM1";
        public static int BaudRate = 9600;
        public static StopBits StopBits = StopBits.One;
        public static int DataBits = 8;
        public static Parity Parity = Parity.None;

        //计量模块读交流电压电流
        public static string readjldy = "81 C1 01 0F 82 01 03 00 00 00 00 00 00 00 CE";


    }
}
