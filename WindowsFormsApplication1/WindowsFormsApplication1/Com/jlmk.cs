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

        /*******************************示值误差、付费误差测试****************************/
        //一、进入该测试项后，先设置计量模块参数
        //1、写电压档位Ary25 = 0x00 自动档
        public static string szSet01 = "81 C1 01 10 83 01 00 00 00 02 00 00 00 00 00 D1";
        //2、写电流档位Ary26 = 0x00 自动档
        public static string szSet02 = "81 C1 01 10 83 01 00 00 00 04 00 00 00 00 00 D7 ";
        //3、写电能输出模式Ary27
        public static string szSet03 = "81 C1 01 10 83 01 00 00 00 08 00 00 00 00 00 DB ";
        //4、写电流量程Ary28
        public static string szSet04 = "81 C1 01 10 83 01 00 00 00 10 00 00 00 00 00 C3";

        public static string szReply = "81 01 C1 08 C0 00 01 88";

        //二、点“启动”按钮，上位机发“写计量模块第2页，交流走字控制Ary12=0x01 启动”命令
        public static string szStart = "81 C1 01 10 83 02 00 10 01 00 00 00 00 00 00 C1";

        //三、正常启动后，循环发（间隔500ms）读测量数据
        //1、上位机发“计量模块读第1页，环境温度Ary33（4Byte ,float）和湿度Ary34（4Byte ,float）命令”
        public static string szRwsd = "81 C1 01 0F 82 01 00 00 00 00 06 00 00 00 CB";
        public static string szRwsdRP = "81 01 C1 17 42 01 00 00 00 00 06 DE A9 E2 41 40 DF 83 42 00 00 00 99";
        //2、上位机发＂读第1页，交流电压Ary00（4Byte）、交流电流Ary01(4Byte)，交流频率Ary04(4Byte)，交流功率Ary06(4Byte)＂
        public static string szRvahp = "81 C1 01 0F 82 01 53 00 00 00 00 00 00 00 9E";
        public static string szRvahpRP = "81 01 C1 1F 42 01 53 20 FE 63 43 CD B8 95 40 92 02 48 42 10 57 85 44 00 00 00 00 00 00 00 0C";
        //3、上位机发＂读交流走字状态Ary13（1Byte）、交流走字标准电能值Ary14(4Byte)，交流走字电能脉冲数Ary15(8Byte)，交流走字时间Ary16(8Byte)＂
        public static string szRvahp1 = "81 C1 01 0F 82 02 00 E0 01 00 00 00 00 00 2F";
        public static string szRvahp1RP = "81 01 C1 24 42 02 00 E0 02 9F C1 A9 3C 23 C8 1A 00 00 00 00 00 01 7B 00 00 00 00 00 00 00 00 00 00 00 00 87";
        public static string szRvahp2RP = "81 01 C1 24 42 02 00 E0 02 30 37 CB 3D F8 3D 80 00 00 00 00 00 01 85 01 00 00 00 00 00 00 00 00 00 00 00 F6";

        //四、手动停止桩，并将交流桩显示的电能示值和金额示值人工输入到参数设置中的输入框中，然后点“完成”按钮，
        //1、上位机发“写计量模块第2页，交流走字控制Ary12=0x02 停止”命令
        public static string szStop = "81 C1 01 10 83 02 00 10 02 00 00 00 00 00 00 C2";
        //2、计算测量结果：标准电能值*率单价=标准付费金额，|标准付费金额-付费金额示值|=付费误差，[(电能示值－标准电能)／标准电能]*100% =示值误差。
        /*********************************************************************************/
        
        /*******************************时钟示值误差测定**********************************/
        //1、进入该测试界面后，上位机发“读GPS信号强度Ary31、读GPS数据有效性Ary32”
        public static string clockRgps = "81 C1 01 0F 82 01 00 00 00 80 01 00 00 00 4C";
        public static string clockRgpsRP = "81 01 C1 11 42 01 00 00 00 80 10 01 41 00 00 00 C3";
        public static string clockRgpsRPCMD = "81 01 C1 11 42 01 00 00 00 80";
        //2、上位机间隔300ms循环发送“计量模块读GPS时间”命令，然后将读到的日期时间进行显示
        public static string clockRgpst = "81 C1 01 0A 84 01 1E 00 0D DD";
        public static string clockRgpstRP = "81 01 C1 18 44 01 1E 00 0D 32 30 31 38 31 31 30 38 32 30 33 31 30 36 0A";
        public static string clockRgpstRPCMD = "81 01 C1 18 44 01 1E 00 0D";
        /*********************************************************************************/

    }
}
