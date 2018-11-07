using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1.Com
{
    public class acboard
    {
        public static SerialPort com;

        public static string PortName = "COM1";
        public static int BaudRate = 9600;
        public static StopBits StopBits = StopBits.One;
        public static int DataBits = 8;
        public static Parity Parity = Parity.None;

        public static string cpvolt = "0";
        public static string cpfr = "0";
        public static string cpduty = "0";
        public static string cpcu = "0";
        public static string Axvolt = "0";
        public static string Axcu = "0";
        public static string Bxvolt = "0";
        public static string Bxcu = "0";
        public static string Cxvolt = "0";
        public static string Cxcu = "0";
        public static string inpower = "0";
        public static string chargeSingle = "0";
        public static string chargestatus = "0";

        public static byte[] header = { 0x8b, 0x00 };

        //----------------------电能数据 单相--------------
        //A1 2C 电压-2byte、电流-2byte
        public static byte[] acA12C = { 0xA1, 0x2C };
        //public static string acA12CSend = "8b 00 06 A1 2C 08 98 01 40 b8 69";
        public static string pcA1C2Send = "8b 00 03 A1 C2 01 b8 52";

        //A1 3C 功率-2byte 电量-2byte
        public static byte[] acA13C = { 0xA1, 0x3C };
        //public static string acA13CSend = "8b 00 07 A1 3C 00 23 00 64 40 b8 69";
        public static string pcA1C3Send = "8b 00 03 A1 C3 01 b8 53";

        //----------------------电能数据 单相--------------
        //B1 2C 电压-2byte、电流-2byte
        public static byte[] acB12C = { 0xB1, 0x2C };
        //public static string acA12CSend = "8b 00 06 B1 2C 08 98 01 40 b8 69";
        public static string pcB1C2Send = "8b 00 03 B1 C2 01 b8 42";

        //B1 3C 功率-2byte 电量-2byte
        public static byte[] acB13C = { 0xB1, 0x3C };
        //public static string acB13CSend = "8b 00 07 B1 3C 00 23 00 64 40 b8 69";
        public static string pcB1C3Send = "8b 00 03 B1 C3 01 b8 43";

        //----------------------电能数据 三相--------------
        //B2 2C 电压-2byte、电流-2byte
        public static byte[] acB22C = { 0xB2, 0x2C };
        //public static string acA12CSend = "8b 00 06 B2 2C 08 98 01 40 b8 69";
        public static string pcB2C2Send = "8b 00 03 B2 C2 01 b8 41";

        //B2 3C 功率-2byte 电量-2byte
        public static byte[] acB23C = { 0xB2, 0x3C };
        //public static string acA13CSend = "8b 00 07 B2 3C 00 23 00 64 40 b8 69";
        public static string pcB2C3Send = "8b 00 03 B2 C3 01 b8 40";

        //----------------------控制导引 A枪--------------
        public static byte[] acC12C = { 0xC1, 0x2C };
        //C1 2C cp电压(1byte) 频率(2byte) 占空比(1byte) 电流(2byte)
        //public static string acC12CSend = "8b 00 08 C1 2C 06 03 E8 1B 01 40 b8 69";
        public static string pcC1C2Send = "8b 00 03 C1 C2 01 b8 32";

        //----------------------控制导引 B枪--------------
        public static byte[] acC13C = { 0xC1, 0x3C };
        //C1 3C cp电压(1byte) 频率(2byte) 占空比(1byte) 电流(2byte)
        //public static string acC12CSend = "8b 00 08 C1 3C 06 03 E8 1B 01 40 b8 69";
        public static string pcC1C3Send = "8b 00 03 C1 C3 01 b8 33";

        //----------------------连接确认--------------
        public static byte[] acD12C = { 0xD1, 0x2C };
        //D1 2C 设备状态-1byte 0x00 空闲状态 0x01 充电状态 0x02 故障状态
        //public static string acD12CSend = "8b 00 03 D1 2C 00 b8 69";
        public static string pcD1C2Send = "8b 00 03 D1 C2 01 b8 22";

        //----------------------控制接地电阻接通--------------
        public static byte[] acF12C = { 0xF1, 0x2C };
        public static bool CmdOk = false;
        public static string pcF1C2Send0 = "8B 00 04 F1 C2 01 01 B8 04";
        public static string pcF12CRece00 = "8B 00 04 F1 2C 01 01 B8 EA";//操作成功
        public static string pcF12CRece01 = "8B 00 04 F1 2C 01 00 B8 EB";//操作失败

        //----------------------控制接地电阻断开--------------
        public static string pcF1C2Send1 = "8B 00 04 F1 C2 01 00 B8 05";
        public static string pcF12CRece10 = "8B 00 04 F1 2C 01 01 B8 EA";//操作成功
        public static string pcF12CRece11 = "8B 00 04 F1 2C 01 00 B8 EB";//操作失败



    }
}
