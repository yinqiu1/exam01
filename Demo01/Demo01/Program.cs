using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] a = new byte[] { 12, 32, 0x11, 0, 0, 0, 45, 56, 67, 78, 89, 96, 54, 32, 23, 45, 23 };
            byte[] newA = a.Skip(2).Take(4).ToArray();
            foreach (var b in newA)
            {
                Console.WriteLine(b);
            }
            int a1 = newA[0] * 0x1000000 + newA[1] * 0x10000 + newA[2] * 0x100 + newA[3];
            Console.WriteLine(a1);

            byte[] byteTemp = new byte[4] { 0x76, 0x83, 0x33, 0x45 };
            float fTemp = BitConverter.ToSingle(byteTemp, 0);
            Console.WriteLine(fTemp);

            byte[] byteTemp1 = new byte[4] { 0xDE, 0xA9, 0xE2, 0x41 };
            float fTemp1 = BitConverter.ToSingle(byteTemp1, 0);
            Console.WriteLine(fTemp1.ToString());

            byte[] byteTemp2 = new byte[4] { 0x40, 0xDF, 0x83, 0x42 };
            float fTemp2 = BitConverter.ToSingle(byteTemp2, 0);
            Console.WriteLine(fTemp2.ToString());

            fTemp2 = BitConverter.ToSingle(HexStringToByteArray("30 37 CB 3D"), 0);
            Console.WriteLine("float=" + fTemp2.ToString());

            //BCC校验
            Console.WriteLine("BCC校验");
            //byte[] data = { 0x8b,0x00, 0x06 ,0xA1, 0x2C, 0x08, 0x98, 0x01, 0x40, 0xb8 };
            byte[] data = { 0x8b, 0x00, 0x03, 0xA1, 0xC2, 0x01, 0xb8 };
            byte ab = Get_CheckXor(data);
            Console.WriteLine(ab.ToString("x2"));

            string ab1 = GetBCCXorCode(data);
            Console.WriteLine(ab1);

            //BCC exam
            string cmd = "81 01 C1 11 42 01 00 00 00 80 10 01 41 00 00 00";
            byte ab2 = Get_CheckXor(HexStringToByteArray(cmd));
            Console.WriteLine("------BCC exam: 0x" + ab2.ToString("x2"));

            string data0 = "8b 00 06 A1 2C 08 98 01 40 b8 69 ";

            byte[] cmd7 = sliceBytes2Array(HexStringToByteArray(data0), 3, 2);
            if (cmd7.SequenceEqual(acA12C))
            {
                Console.WriteLine("equel");
            }

            Console.WriteLine("byte[8] to UINT64");
            byte[] timer = new byte[] { 0, 0, 0, 0, 0, 0, 15, 168 };
            Array.Reverse(timer);//这句
            long l = BitConverter.ToInt64(timer, 0);
            Console.WriteLine(l);

            string data1 = "23 C8 1A 00 00 00 00 00";
            byte[] data11 = HexStringToByteArray(data1);
            l = BitConverter.ToInt64(data11, 0);
            Console.WriteLine(l);

            data1 = "F8 3D 80 00 00 00 00 00";
            data11 = HexStringToByteArray(data1);
            l = BitConverter.ToInt64(data11, 0);
            Console.WriteLine(l);

            data1 = "01 7B 00 00 00 00 00 00";
            data11 = HexStringToByteArray(data1);
            l = BitConverter.ToInt64(data11, 0);
            Console.WriteLine(l);

            data1 = "01 7B 00 00 00 00 00 00";
            data11 = HexStringToByteArray(data1);
            UInt64 ul = BitConverter.ToUInt64(data11, 0);
            Console.WriteLine("ul=" + ul);

            data1 = "01 85 01 00 00 00 00 00";
            data11 = HexStringToByteArray(data1);
            l = BitConverter.ToInt64(data11, 0);
            Console.WriteLine(l);

            data1 = "01 85 01 00 00 00 00 00";
            data11 = HexStringToByteArray(data1);
            ul = BitConverter.ToUInt64(data11, 0);
            Console.WriteLine("ul=" + ul);

            //求余数
            for (int count = 0; count < 10; count++)
            {
                int aa = count % 4;
                Console.WriteLine("aa=" + aa);
            }
            //ASCII
            int asciicode = (int)(0x32);
            string ASCIIstr1 = Convert.ToString(asciicode);
            Console.WriteLine("ASCIIstr1="+ASCIIstr1);

            string alpha = ((char)0x41).ToString();
            Console.WriteLine("alpha=" + alpha);

            alpha = ((char)0x56).ToString();
            Console.WriteLine("alpha=" + alpha);

            alpha = ((char)0x4e).ToString();
            Console.WriteLine("alpha=" + alpha);

            Console.ReadLine();
        }
        public static byte[] acA12C = { 0xA1, 0x2C };
        /// <summary>
        /// BCC和校验代码
        /// </summary>
        /// <param name="data">需要校验的数据包</param>
        /// <returns></returns>
        public static byte Get_CheckXor(byte[] data)
        {
            byte CheckCode = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                CheckCode ^= data[i];
            }
            return CheckCode;
        }
        /// <summary>
        /// BCC和校验代码返回16进制
        /// </summary>
        /// <param name="data">需要校验的数据包</param>
        /// <returns></returns>
        public static string GetBCCXorCode(byte[] data)
        {
            byte CheckCode = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                CheckCode ^= data[i];
            }
            return Convert.ToString(CheckCode, 16).ToUpper();
        }
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        public static byte[] sliceBytes2Array(byte[] ab, int s, int t)
        {
            byte[] newA = ab.Skip(s).Take(t).ToArray();
            return newA;
        }
    }
}
