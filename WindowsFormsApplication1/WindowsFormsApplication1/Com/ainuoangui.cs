using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace WindowsFormsApplication1.Com
{
    public class ainuoangui
    {
        public static string PortName = "COM1";
        public static int BaudRate = 9600;
        public static StopBits StopBits = StopBits.One;
        public static int DataBits = 8;
        public static Parity Parity = Parity.None;

        //--------------介电强度试验--------------
        //--------------设置--------------
        //设置系统当前选中组别序号
        public static string acset01 =    "7B 00 09 01 5A 07 00 6B 7D";
        public static string acsetrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //返回主界面
        public static string acset02 =    "7B 00 08 01 0F 09 21 7D";
        public static string acsetrev02 = "7B 00 09 01 0F 09 00 22 7D";
        //进入编辑界面
        public static string acset03 =    "7B 00 08 01 0F 07 1F 7D";
        public static string acsetrev03 = "7B 00 09 01 0F 07 00 20 7D";
        //设置系统当前测试类型
        public static string acset04 =    "7B 00 09 01 5A 0A 00 6E 7D";
        public static string acsetrev04 = "7B 00 09 01 5A 0A 00 6E 7D";
        //设置系统当前设置输出值
        public static string acset05 =    "7B 00 0A 01 5A 0B 07 D0 47 7D";
        public static string acsetrev05 = "7B 00 09 01 5A 0B 00 6F 7D";
        //上限
        public static string acset06 =    "7B 00 0A 01 5A 0D 03 E8 5D 7D";
        public static string acsetrev06 = "7B 00 09 01 5A 0D 00 71 7D";
        //下限
        //public static string acset07 = "";
        //public static string acsetrev07 = "";
        //测试时间
        public static string acset08 =    "7B 00 0A 01 5A 0E 02 58 CD 7D";
        public static string acsetrev08 = "7B 00 09 01 5A 0E 00 72 7D";
        //缓升时间
        public static string acset09 =    "7B 00 0A 01 5A 0F 00 01 75 7D ";
        public static string acsetrev09 = "7B 00 09 01 5A 0F 00 73 7D";
        //保存当前设置
        public static string acset10 =    "7B 00 08 01 0F 0A 22 7D";
        public static string acsetrev10 = "7B 00 09 01 0F 0A 00 23 7D";
        //返回主界面
        public static string acset11 =    "7B 00 08 01 0F 09 21 7D";
        public static string acsetrev11 = "7B 00 09 01 0F 09 00 22 7D";
        //--------------测试--------------
        //设置系统当前选中组别序号
        public static string actest01 =    "7B 00 09 01 5A 07 00 6B 7D";
        public static string actestrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //开始测试
        public static string actest02 =    "7B 00 08 01 0F FF 17 7D";
        public static string actestrev02 = "7B 00 09 01 0F FF 00 18 7D";
        //查询第0步测试结果值
        public static string actest03 =    "7B 00 09 01 F1 01 00 FC 7D";
        public static string actestrev03 = "7B 00 10 01 F1 01 00 00 00 00 00 00 00 00 03 7D";
        //"查询测试结果状态（是否合格）" 加下划线参数表示查询步测试结果状态，0 表示合格，1 表示不合格
        public static string actest04 =    "7B 00 09 01 F1 02 00 FD 7D";
        public static string actestrev04 = "7B 00 09 01 F1 02 00 FD 7D";
        //返回上一层
        public static string actest05 =    "7B 00 08 01 0F 00 18 7D";
        public static string actestrev05 = "7B 00 09 01 0F 00 00 19 7D";
        //返回主界面
        public static string actest06 =    "7B 00 08 01 0F 09 21 7D";
        public static string actestrev06 = "7B 00 09 01 0F 09 00 22 7D";

        //绝缘电阻试验
        //--------------设置--------------
        //设置系统当前选中组别序号
        public static string jydzset01 =    "7B 00 09 01 5A 07 02 6D 7D ";
        public static string jydzsetrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //返回主界面
        public static string jydzset02 =    "7B 00 08 01 0F 09 21 7D";
        public static string jydzsetrev02 = "7B 00 09 01 0F 09 00 22 7D";
        //进入编辑界面
        public static string jydzset03 =    "7B 00 08 01 0F 07 1F 7D";
        public static string jydzsetrev03 = "7B 00 09 01 0F 07 00 20 7D";
        //设置系统当前测试类型
        public static string jydzset04 =    "7B 00 09 01 5A 0A 02 70 7D";
        public static string jydzsetrev04 = "7B 00 09 01 5A 0A 00 6E 7D";
        //设置系统当前设置输出值
        public static string jydzset05 =    "7B 00 0A 01 5A 0B 01 F4 65 7D";
        public static string jydzsetrev05 = "7B 00 09 01 5A 0B 00 6F 7D";
        //上限
        //public static string jydzset06 = "";
        //public static string jydzsetrev06 = "";
        //下限
        public static string jydzset07 =    "7B 00 0A 01 5A 0C 00 0A 7B 7D";
        public static string jydzsetrev07 = "7B 00 09 01 5A 0C 00 70 7D";
        //测试时间
        public static string jydzset08 =    "7B 00 0A 01 5A 0E 00 0A 7D 7D";
        public static string jydzsetrev08 = "7B 00 09 01 5A 0E 00 72 7D";
        //缓升时间
        public static string jydzset09 =    "7B 00 0A 01 5A 0F 00 04 78 7D";
        public static string jydzsetrev09 = "7B 00 09 01 5A 0F 00 73 7D";
        //保存当前设置
        public static string jydzset10 =    "7B 00 08 01 0F 0A 22 7D";
        public static string jydzsetrev10 = "7B 00 09 01 0F 0A 00 23 7D";
        //返回主界面
        public static string jydzset11 =    "7B 00 08 01 0F 09 21 7D";
        public static string jydzsetrev11 = "7B 00 09 01 0F 09 00 22 7D";
        //--------------测试--------------
        //设置系统当前选中组别序号
        public static string jydztest01 =    "7B 00 09 01 5A 07 02 6D 7D";
        public static string jydztestrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //开始测试
        public static string jydztest02 =    "7B 00 08 01 0F FF 17 7D";
        public static string jydztestrev02 = "7B 00 09 01 0F FF 00 18 7D";
        //查询第0步测试结果值
        public static string jydztest03 =    "7B 00 09 01 F1 01 00 FC 7D";
        public static string jydztestrev03 = "7B 00 10 01 F1 01 00 00 00 00 00 00 00 00 03 7D";
        //"查询测试结果状态（是否合格）" 加下划线参数表示查询步测试结果状态，0 表示合格，1 表示不合格
        public static string jydztest04 =    "7B 00 09 01 F1 02 00 FD 7D";
        public static string jydztestrev04 = "7B 00 09 01 F1 02 00 FD 7D";
        //返回上一层
        public static string jydztest05 =    "7B 00 08 01 0F 00 18 7D";
        public static string jydztestrev05 = "7B 00 09 01 0F 00 00 19 7D";
        //返回主界面
        public static string jydztest06 =    "7B 00 08 01 0F 09 21 7D";
        public static string jydztestrev06 = "7B 00 09 01 0F 09 00 22 7D";

        //接地电阻试验
        //--------------设置--------------
        //设置系统当前选中组别序号
        public static string jdset01 =    "7B 00 09 01 5A 07 03 6E 7D";
        public static string jdsetrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //返回主界面
        public static string jdset02 =    "7B 00 08 01 0F 09 21 7D";
        public static string jdsetrev02 = "7B 00 09 01 0F 09 00 22 7D";
        //进入编辑界面
        public static string jdset03 =    "7B 00 08 01 0F 07 1F 7D";
        public static string jdsetrev03 = "7B 00 09 01 0F 07 00 20 7D";
        //设置系统当前测试类型
        public static string jdset04 =    "7B 00 09 01 5A 0A 03 71 7D";
        public static string jdsetrev04 = "7B 00 09 01 5A 0A 00 6E 7D";
        //设置系统当前设置输出值
        public static string jdset05 =    "7B 00 0A 01 5A 0B 00 FA 6A 7D";
        public static string jdsetrev05 = "7B 00 09 01 5A 0B 00 6F 7D";
        //上限
        public static string jdset06 =    "7B 00 0A 01 5A 0D 03 E8 5D 7D";
        public static string jdsetrev06 = "7B 00 09 01 5A 0D 00 71 7D";
        //下限
        //public static string jdset07 =    "7B 00 0A 01 5A 0C 00 0A 7B 7D";
        //public static string jdsetrev07 = "7B 00 09 01 5A 0C 00 70 7D";
        //测试时间
        public static string jdset08 =    "7B 00 0A 01 5A 0E 00 0A 7D 7D";
        public static string jdsetrev08 = "7B 00 09 01 5A 0E 00 72 7D";
        //缓升时间
        public static string jdset09 =    "7B 00 0A 01 5A 0F 00 04 78 7D";
        public static string jdsetrev09 = "7B 00 09 01 5A 0F 00 73 7D";
        //保存当前设置
        public static string jdset10 =    "7B 00 08 01 0F 0A 22 7D";
        public static string jdsetrev10 = "7B 00 09 01 0F 0A 00 23 7D";
        //返回主界面
        public static string jdset11 =    "7B 00 08 01 0F 09 21 7D";
        public static string jdsetrev11 = "7B 00 09 01 0F 09 00 22 7D";
        //--------------测试--------------
        //设置系统当前选中组别序号
        public static string jdtest01 =    "7B 00 09 01 5A 07 03 6E 7D";
        public static string jdtestrev01 = "7B 00 09 01 5A 07 00 6B 7D";
        //开始测试
        public static string jdtest02 =    "7B 00 08 01 0F FF 17 7D";
        public static string jdtestrev02 = "7B 00 09 01 0F FF 00 18 7D";
        //查询第0步测试结果值
        public static string jdtest03 =    "7B 00 09 01 F1 01 00 FC 7D";
        public static string jdtestrev03 = "7B 00 10 01 F1 01 00 00 00 00 00 00 00 00 03 7D";
        //"查询测试结果状态（是否合格）" 加下划线参数表示查询步测试结果状态，0 表示合格，1 表示不合格
        public static string jdtest04 =    "7B 00 09 01 F1 02 00 FD 7D";
        public static string jdtestrev04 = "7B 00 09 01 F1 02 01 FE 7D";
        //返回上一层
        public static string jdtest05 =    "7B 00 08 01 0F 00 18 7D";
        public static string jdtestrev05 = "7B 00 09 01 0F 00 00 19 7D";
        //返回主界面
        public static string jdtest06 =    "7B 00 08 01 0F 09 21 7D";
        public static string jdtestrev06 = "7B 00 09 01 0F 09 00 22 7D";
    }
}
