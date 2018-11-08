using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1.Com
{
    public class toolFunc
    {
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// 向串口发送数据，读取返回数据
        /// </summary>
        /// <param name="sendData">发送的数据</param>
        /// <returns>返回的数据</returns>
        public static byte[] ReadPort(SerialPort serialPort, byte[] sendData)
        {
            //if (serialPort == null)
            //{
            //    serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            //    serialPort.ReadBufferSize = 1024;
            //    serialPort.WriteBufferSize = 1024;
            //}
            int i = 0;
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

            //发送数据
            serialPort.Write(sendData, 0, sendData.Length);

            //读取返回数据
            while (serialPort.BytesToRead == 0)
            {
                Thread.Sleep(1);
                i++;
                if (i > 10000)
                    break;
            }
            Thread.Sleep(50); //50毫秒内数据接收完毕，可根据实际情况调整
            byte[] recData = new byte[serialPort.BytesToRead];
            serialPort.Read(recData, 0, recData.Length);

            return recData;
        }

        #region 数组切片，并返回 int ，最大支持 4个 byte
        public static int slice4BytesArray(byte[] ab,int s,int t)
        {
            byte[] newA = ab.Skip(s).Take(t).ToArray();
            int a1 = 0;
            switch(t)
            {
                case 1:
                    a1 = newA[0] * 0x01;
                    break;
                case 2:
                    a1 = newA[0] * 0x100 + newA[1];
                    break;
                case 3:
                    a1 = newA[0] * 0x10000 + newA[1] * 0x100 + newA[2];
                    break;
                case 4:
                    a1 = newA[0] * 0x1000000 + newA[1] * 0x10000 + newA[2] * 0x100 + newA[3];
                    break;

            } 
            return a1;
        }
        public static int slice2BytesArray(byte[] ab, int s, int t)
        {
            byte[] newA = ab.Skip(s).Take(t).ToArray();
            int a1 = 0;
            switch (t)
            {
                case 1:
                    a1 = newA[0] * 0x01;
                    break;
                case 2:
                    a1 = newA[0] * 0x100 + newA[1];
                    break;
                case 3:
                    a1 = newA[0] * 0x10000 + newA[1] * 0x100 + newA[2];
                    break;
                case 4:
                    a1 = newA[0] * 0x1000000 + newA[1] * 0x10000 + newA[2] * 0x100 + newA[3];
                    break;

            }
            return a1;            
        }
        public static int slice1Byte(byte[] ab, int s, int t)
        {
            byte[] newA = ab.Skip(s).Take(t).ToArray();
            int a1 = 0;
            switch (t)
            {
                case 1:
                    a1 = newA[0] * 0x01;
                    break;
                case 2:
                    a1 = newA[0] * 0x100 + newA[1];
                    break;
                case 3:
                    a1 = newA[0] * 0x10000 + newA[1] * 0x100 + newA[2];
                    break;
                case 4:
                    a1 = newA[0] * 0x1000000 + newA[1] * 0x10000 + newA[2] * 0x100 + newA[3];
                    break;

            }
            return a1;
        }
        #endregion
        //返回数组 byte[]
        public static byte[] sliceBytes2Array(byte[] ab, int s, int t)
        {
            byte[] newA = ab.Skip(s).Take(t).ToArray();
            return newA;
        }        

        public static float byte4tofloat(byte[] array)
        {
            //byte[] byteTemp1 = new byte[4] { 0xDE, 0xA9, 0xE2, 0x41 };
            float fTemp1 = BitConverter.ToSingle(array, 0);
            //Console.WriteLine(fTemp1.ToString());
            return fTemp1;
        }
        public static UInt64 byte8toUINT64(byte[] array)
        {            
            UInt64 ul = BitConverter.ToUInt64(array, 0);
            return ul;
        }

        //将byte[]转换为 ASCII String
        public static string bytes2asciiS(byte[] array,int s,int t)
        {
            byte[] newA = sliceBytes2Array(array,s,t);
            string r = "";
            for (int i = 0; i < newA.Length;i++ )
            {
                r += ((char)newA[i]).ToString();
            }
            return r;
        }
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
    }

}
