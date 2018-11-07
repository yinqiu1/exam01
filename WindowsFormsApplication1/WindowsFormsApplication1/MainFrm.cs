using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DataBase;
using System.IO.Ports;
using System.Threading;
using WindowsFormsApplication1.Com;
using WindowsFormsApplication1.FileOp;
using System.Collections.Concurrent;

namespace WindowsFormsApplication1
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            initComSettings();            
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {             
            //交流测试ToolStripMenuItem.PerformClick();
            //*************默认 交流测试*************
            直流测试ToolStripMenuItem.Checked = false;
            交流测试ToolStripMenuItem.Checked = true;

            直流安全巡检项目单项ToolStripMenuItem.Enabled = false;
            交流安全巡检项目ToolStripMenuItem.Enabled = true;

            测试顺序设置ToolStripMenuItem.Enabled = true;
            直流测试顺序设置ToolStripMenuItem.Enabled = false;

            直流充电桩测试报表ToolStripMenuItem.Enabled = false;//生成报告
            直流充电桩测试报表ToolStripMenuItem1.Enabled = false;//查看报告


            Funcs.MainTopUCtrl uc = new Funcs.MainTopUCtrl();
            panel3.Controls.Clear();
            panel3.Controls.Add(uc);

            acflag = true;

            UpdateDataGrid();
            UpdateMainViewRight();
            //***************************************
            Timer2_Load();
        }
        #region 局部变量定义

        private DbOps op = new DbOps();
        //直流交流选择,交流 true,直流 false
        private bool acflag = true;

        private List<byte> buffer = new List<byte>(4096);

        #region 多线程方法--已废弃
        ///// <summary>
        ///// 保持读取开关
        ///// </summary>
        //bool _keepReading;

        ///// <summary>
        ///// 检测频率【检测等待时间，毫秒】【按行读取，可以不用】
        ///// </summary>
        //int _jcpl = 100;

        ///// <summary>
        ///// 字符串队列【.NET Framework 4.0以上】
        ///// </summary>
        //ConcurrentQueue<string> _cq = new ConcurrentQueue<string>();

        ///// <summary>
        ///// 字节数据队列
        ///// </summary>
        //ConcurrentQueue<byte[]> _cqBZ = new ConcurrentQueue<byte[]>();
        #endregion

        #endregion

        #region 文件菜单 直流交流测试选择
        private void 直流测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //直流测试ToolStripMenuItem.BackgroundImage = Properties.Resources._checked;
            直流测试ToolStripMenuItem.Checked = true;
            交流测试ToolStripMenuItem.Checked = false;

            直流安全巡检项目单项ToolStripMenuItem.Enabled = true;
            交流安全巡检项目ToolStripMenuItem.Enabled = false;

            测试顺序设置ToolStripMenuItem.Enabled = false;
            直流测试顺序设置ToolStripMenuItem.Enabled = true;

            //设置顶部的直流、交流菜单
            DCFuncs.dcMainTopUCtrl uc = new DCFuncs.dcMainTopUCtrl();
            panel3.Controls.Clear();
            panel3.Controls.Add(uc);

            acflag = false;

            //加载datagridview
            dcUpdateDataGrid();

            dcUpdateMainViewRight();
        }

        private void 交流测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //交流测试ToolStripMenuItem.BackgroundImage = Properties.Resources._checked;
            直流测试ToolStripMenuItem.Checked = false;
            交流测试ToolStripMenuItem.Checked = true;            

            直流安全巡检项目单项ToolStripMenuItem.Enabled = false;
            交流安全巡检项目ToolStripMenuItem.Enabled = true;

            测试顺序设置ToolStripMenuItem.Enabled = true;
            直流测试顺序设置ToolStripMenuItem.Enabled = false;

            Funcs.MainTopUCtrl uc = new Funcs.MainTopUCtrl();
            panel3.Controls.Clear();
            panel3.Controls.Add(uc);

            acflag = true;

            UpdateDataGrid();

            UpdateMainViewRight();
        }

        //生成交流报表
        private void 交流充电桩测试报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opWord ow = new opWord();
            ow.ACDocs();
        }
        //查看交流报表
        private void 交流充电桩测试报表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            opWord ow = new opWord();
            string filePath = Environment.CurrentDirectory + "\\交流充电桩测试报表模块V102.doc";
            ow.OpenDocument(filePath);
        }

        #endregion

        #region 单项测试 交流17个测试小项选择
        private void 一般检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.UsualCheckUCtrl uc = new Funcs.UsualCheckUCtrl();
            uc.DataChange += new Funcs.UsualCheckUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电模式连接方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.ChargeModelUCtrl cm = new Funcs.ChargeModelUCtrl();
            cm.DataChange += new Funcs.ChargeModelUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 绝缘电阻ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.JueYuanUCtrl cm = new Funcs.JueYuanUCtrl(agserialPort);
            cm.DataChange += new Funcs.JueYuanUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 介电强度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            //通过类名获取类的类型
            Type type = Type.GetType("WindowsFormsApplication1.Funcs.JieDianUCtrl");  //需要带上名字空间
            //不带参数的情况--------------------
            //获取类的初始化参数信息
            //ConstructorInfo ct1 = tp.GetConstructor(System.Type.EmptyTypes);
            //object obj = type.Assembly.CreateInstance(type, true);
            object obj = Activator.CreateInstance(type);
            Funcs.JieDianUCtrl func = (Funcs.JieDianUCtrl)obj;
            func.DataChange += new Funcs.JieDianUCtrl.DataChangeHandler(Back2MainView);  
            panel2.Controls.Clear();
            panel2.Controls.Add(func);
            */
            Funcs.JieDianUCtrl cm = new Funcs.JieDianUCtrl(agserialPort);
            cm.DataChange += new Funcs.JieDianUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }
        private void 过流保护ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Funcs.GuoLiuUCtrl cm = new Funcs.GuoLiuUCtrl(jlserialPort);
            cm.DataChange += new Funcs.GuoLiuUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 剩余电流保护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.ShengYuUCtrl cm = new Funcs.ShengYuUCtrl(jlserialPort,acserialPort);
            cm.DataChange += new Funcs.ShengYuUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 连接异常ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Funcs.LianJieYiChangUCtrl cm = new Funcs.LianJieYiChangUCtrl(jlserialPort);
            cm.DataChange += new Funcs.LianJieYiChangUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 接地测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.JieDiUCtrl cm = new Funcs.JieDiUCtrl(agserialPort);
            cm.DataChange += new Funcs.JieDiUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 显示功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("WindowsFormsApplication1.Funcs.XianShiUCtrl");
            object obj = Activator.CreateInstance(type);
            Funcs.XianShiUCtrl func = (Funcs.XianShiUCtrl)obj;
            func.DataChange += new Funcs.XianShiUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(func);
        }

        private void 输入功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("WindowsFormsApplication1.Funcs.ShuRuUCtrl");
            object obj = Activator.CreateInstance(type);
            Funcs.ShuRuUCtrl func = (Funcs.ShuRuUCtrl)obj;
            func.DataChange += new Funcs.ShuRuUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(func);
        }

        private void 充电功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.ChargeUCtrl cm = new Funcs.ChargeUCtrl(jlserialPort);
            cm.DataChange += new Funcs.ChargeUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 监控管理系统通信ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type type = Type.GetType("WindowsFormsApplication1.Funcs.JianKongComUCtrl");
            object obj = Activator.CreateInstance(type);
            Funcs.JianKongComUCtrl func = (Funcs.JianKongComUCtrl)obj;
            func.DataChange += new Funcs.JianKongComUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(func);
        }

        private void 急停功能试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.JiTingUCtrl cm = new Funcs.JiTingUCtrl(jlserialPort);
            cm.DataChange += new Funcs.JiTingUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }
        
        private void 开门保护试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.KaiMenUCtrl cm = new Funcs.KaiMenUCtrl(jlserialPort);
            cm.DataChange += new Funcs.KaiMenUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }
        private void 计量数据一致性试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Funcs.JiLiangUCtrl cm = new Funcs.JiLiangUCtrl(jlserialPort);
            cm.DataChange += new Funcs.JiLiangUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);

        }
        private void 示值误差付费误差测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.ShiZhiWCUCtrl cm = new Funcs.ShiZhiWCUCtrl(jlserialPort);
            cm.DataChange += new Funcs.ShiZhiWCUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }

        private void 时钟示值误差测定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcs.ShiZhongWCUCtrl cm = new Funcs.ShiZhongWCUCtrl(jlserialPort);
            cm.DataChange += new Funcs.ShiZhongWCUCtrl.DataChangeHandler(Back2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(cm);
        }
        #endregion

        #region 单项测试 直流32个测试小项选择

        private void 一般检查ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcUsualCheckUCtrl uc = new DCFuncs.dcUsualCheckUCtrl();
            uc.DataChange += new DCFuncs.dcUsualCheckUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电模式和连接方式检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeModelUCtrl uc = new DCFuncs.dcChargeModelUCtrl();
            uc.DataChange += new DCFuncs.dcChargeModelUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 绝缘电阻试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcJueYuanUCtrl uc = new DCFuncs.dcJueYuanUCtrl();
            uc.DataChange += new DCFuncs.dcJueYuanUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 介电强度试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcJieDianUCtrl uc = new DCFuncs.dcJieDianUCtrl();
            uc.DataChange += new DCFuncs.dcJieDianUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 接地测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcJieDiUCtrl uc = new DCFuncs.dcJieDiUCtrl();
            uc.DataChange += new DCFuncs.dcJieDiUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 剩余电流保护试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcShengYuUCtrl uc = new DCFuncs.dcShengYuUCtrl();
            uc.DataChange += new DCFuncs.dcShengYuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 显示功能ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcXianShiUCtrl uc = new DCFuncs.dcXianShiUCtrl();
            uc.DataChange += new DCFuncs.dcXianShiUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 输入功能ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcShuRuUCtrl uc = new DCFuncs.dcShuRuUCtrl();
            uc.DataChange += new DCFuncs.dcShuRuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电功能ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeUCtrl uc = new DCFuncs.dcChargeUCtrl();
            uc.DataChange += new DCFuncs.dcChargeUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 与监控管理系统通信功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcJianKongComUCtrl uc = new DCFuncs.dcJianKongComUCtrl();
            uc.DataChange += new DCFuncs.dcJianKongComUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 低压辅助电源试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcDiYaUCtrl uc = new DCFuncs.dcDiYaUCtrl();
            uc.DataChange += new DCFuncs.dcDiYaUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 输出电压误差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcShuChuVUCtrl uc = new DCFuncs.dcShuChuVUCtrl();
            uc.DataChange += new DCFuncs.dcShuChuVUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }
        private void 稳压精度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcWenYaUCtrl uc = new DCFuncs.dcWenYaUCtrl();
            uc.DataChange += new DCFuncs.dcWenYaUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 输出电流误差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcShuChuAUCtrl uc = new DCFuncs.dcShuChuAUCtrl();
            uc.DataChange += new DCFuncs.dcShuChuAUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 稳流精度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcWenLiuUCtrl uc = new DCFuncs.dcWenLiuUCtrl();
            uc.DataChange += new DCFuncs.dcWenLiuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 限压特性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcXianYaUCtrl uc = new DCFuncs.dcXianYaUCtrl();
            uc.DataChange += new DCFuncs.dcXianYaUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 限流特性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcXianLiuUCtrl uc = new DCFuncs.dcXianLiuUCtrl();
            uc.DataChange += new DCFuncs.dcXianLiuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 急停功能试验ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcJiTingUCtrl uc = new DCFuncs.dcJiTingUCtrl();
            uc.DataChange += new DCFuncs.dcJiTingUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 锁止功能试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcSuoZhiUCtrl uc = new DCFuncs.dcSuoZhiUCtrl();
            uc.DataChange += new DCFuncs.dcSuoZhiUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 开门保护试验ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcKaiMenUCtrl uc = new DCFuncs.dcKaiMenUCtrl();
            uc.DataChange += new DCFuncs.dcKaiMenUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }
        private void 输出短路保护试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcDuanLuUCtrl uc = new DCFuncs.dcDuanLuUCtrl();
            uc.DataChange += new DCFuncs.dcDuanLuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 协议一致性试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcXieYiUCtrl uc = new DCFuncs.dcXieYiUCtrl();
            uc.DataChange += new DCFuncs.dcXieYiUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电异常状态试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeErrorUCtrl uc = new DCFuncs.dcChargeErrorUCtrl();
            uc.DataChange += new DCFuncs.dcChargeErrorUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 低压辅助上电及充电握手阶段检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcDiYaFuZhuUCtrl uc = new DCFuncs.dcDiYaFuZhuUCtrl();
            uc.DataChange += new DCFuncs.dcDiYaFuZhuUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电参数配置阶段检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeSettingUCtrl uc = new DCFuncs.dcChargeSettingUCtrl();
            uc.DataChange += new DCFuncs.dcChargeSettingUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电阶段检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeStageUCtrl uc = new DCFuncs.dcChargeStageUCtrl();
            uc.DataChange += new DCFuncs.dcChargeStageUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电结束阶段检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChargeEndUCtrl uc = new DCFuncs.dcChargeEndUCtrl();
            uc.DataChange += new DCFuncs.dcChargeEndUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 软启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcSoftStartUCtrl uc = new DCFuncs.dcSoftStartUCtrl();
            uc.DataChange += new DCFuncs.dcSoftStartUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 连接异常试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcConnectErrorUCtrl uc = new DCFuncs.dcConnectErrorUCtrl();
            uc.DataChange += new DCFuncs.dcConnectErrorUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 工作误差测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcWorkDiffUCtrl uc = new DCFuncs.dcWorkDiffUCtrl();
            uc.DataChange += new DCFuncs.dcWorkDiffUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 示值误差付费误差测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcViewDiffUCtrl uc = new DCFuncs.dcViewDiffUCtrl();
            uc.DataChange += new DCFuncs.dcViewDiffUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 时钟示值误差测定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DCFuncs.dcShiZhongUCtrl uc = new DCFuncs.dcShiZhongUCtrl();
            uc.DataChange += new DCFuncs.dcShiZhongUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 电池反接试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcDianChiFanUCtrl uc = new DCFuncs.dcDianChiFanUCtrl();
            uc.DataChange += new DCFuncs.dcDianChiFanUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电控制信号检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChDKZXHUCtrl uc = new DCFuncs.dcChDKZXHUCtrl();
            uc.DataChange += new DCFuncs.dcChDKZXHUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }

        private void 充电控制时序检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DCFuncs.dcChDKZSXUCtrl uc = new DCFuncs.dcChDKZSXUCtrl();
            uc.DataChange += new DCFuncs.dcChDKZSXUCtrl.DataChangeHandler(DCBack2MainView);
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
        }
        #endregion


        #region 多项测试 菜单选择---已废弃
        private void 项目选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.SelectDiag sd = new Dialog.SelectDiag();
            sd.StartPosition = FormStartPosition.CenterScreen;
            sd.ShowDialog();
        }

        private void 结果查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.ResultDiag sd = new Dialog.ResultDiag();
            sd.StartPosition = FormStartPosition.CenterScreen;
            sd.ShowDialog();
        }
        private void 启动测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtable = op.getItemViewChecked();

            /*取出数据并一个个进行测试*/
            if (dtable != null)
            {
                //this.dataGridView1.DataSource = dt; 
                Mytimer.Start();
                TimeCount = 0;

            }            

        }
        private void 停止测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mytimer.Stop();
        }
        #endregion


        #region  测试项目
        //定义Timer类变量
        System.Timers.Timer Mytimer;
        int TimeCount;
        DataTable dtable;
        //定义委托
        public delegate void SetControlValue(int value,DataTable dt);
        
        private void Timer2_Load()
        {
            //设置时间间隔ms
            int interval = 1000;  
            Mytimer = new System.Timers.Timer(interval);
            //设置重复计时
            Mytimer.AutoReset = true;
            //设置执行System.Timers.Timer.Elapsed事件
            
            Mytimer.Elapsed += new System.Timers.ElapsedEventHandler(Mytimer_tick);
        }
        private void Mytimer_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new SetControlValue(ShowTime), TimeCount,dtable);
            TimeCount++;
        }

        private void ShowTime(int t,DataTable dt)
        {
            //TimeSpan temp = new TimeSpan(0, 0, (int)t);
            //txtTimeShow.Text = string.Format("{0:00}:{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds);
            if (t < dt.Rows.Count)
            {
                if (acflag)
                {
                    Type type = Type.GetType("WindowsFormsApplication1.Funcs." + dt.Rows[t]["classname"]);
                    object obj = Activator.CreateInstance(type);
                    panel2.Controls.Clear();
                    panel2.Controls.Add((UserControl)obj);
                }
                else
                {
                    Type type = Type.GetType("WindowsFormsApplication1.DCFuncs." + dt.Rows[t]["classname"]);
                    object obj = Activator.CreateInstance(type);
                    panel2.Controls.Clear();
                    panel2.Controls.Add((UserControl)obj);
                }
                
            }
            else
            {
                Mytimer.Stop(); 
                MessageBox.Show("已检测完成！");                
            }
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            textBox_receive.Text = "";
        }
        #endregion

        #region 设置菜单
        private void 测试顺序设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.SortDiag sd = new Dialog.SortDiag();
            sd.DataChange += new Dialog.SortDiag.DataChangeHandler(DataChanged);
            sd.StartPosition = FormStartPosition.CenterScreen;
            sd.ShowDialog();
        }
        private void 直流测试顺序设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.dcSortDiag dsd = new Dialog.dcSortDiag();
            dsd.DataChange += new Dialog.dcSortDiag.DataChangeHandler(dcDataChanged);
            dsd.StartPosition = FormStartPosition.CenterScreen;
            dsd.ShowDialog();
        }
        //设置各个测试设备的串口
        private void 串口选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.ComDiag dsd = new Dialog.ComDiag();
            //dsd.DataChange += new Dialog.dcSortDiag.DataChangeHandler(dcDataChanged);
            dsd.StartPosition = FormStartPosition.CenterScreen;
            dsd.ShowDialog();
        }
        //开启、关闭串口，测试设备
        private void 打开串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //查看变量是否已经更改
            //MessageBox.Show(Com.ainuoangui.PortName + Com.ainuoangui.BaudRate.ToString());
            //MessageBox.Show(Com.jlmk.PortName + Com.jlmk.BaudRate.ToString());
            //初始化安规设备
            if (!agserialPort.IsOpen)//如果串口是开
            {
                agserialPort.PortName = Com.ainuoangui.PortName;
                agserialPort.BaudRate = Com.ainuoangui.BaudRate;
                agserialPort.StopBits = Com.ainuoangui.StopBits;
                agserialPort.DataBits = Com.ainuoangui.DataBits;
                agserialPort.Parity = Com.ainuoangui.Parity;
                try
                {
                    agserialPort.Open();     //打开串口
                    agtoolStripStatusLabel.Text = "安规设备状态:已连接";
                    //开始进行初始化命令的发送

                    agtoolStripStatusLabel.ForeColor = Color.Green;
                }
                catch
                {
                    //MessageBox.Show("安规设备连接失败！");
                    agtoolStripStatusLabel.Text = "安规设备状态:连接失败";
                    agtoolStripStatusLabel.ForeColor = Color.Red;
                }
            }
            //初始化计量模块
            if (!jlserialPort.IsOpen)//如果串口是开
            {
                jlserialPort.PortName = Com.jlmk.PortName;
                jlserialPort.BaudRate = Com.jlmk.BaudRate;
                jlserialPort.StopBits = Com.jlmk.StopBits;
                jlserialPort.DataBits = Com.jlmk.DataBits;
                jlserialPort.Parity = Com.jlmk.Parity;
                try
                {
                    jlserialPort.Open();     //打开串口
                    jltoolStripStatusLabel.Text = "计量模块状态:已连接";
                    //开始进行初始化命令的发送

                    jltoolStripStatusLabel.ForeColor = Color.Green;
                }
                catch
                {
                    //MessageBox.Show("安规设备连接失败！");
                    jltoolStripStatusLabel.Text = "计量模块状态:连接失败";
                    jltoolStripStatusLabel.ForeColor = Color.Red;
                }
            }
            //初始化交流板
            if (!acserialPort.IsOpen)//如果串口是开
            {
                acserialPort.PortName = Com.acboard.PortName;
                acserialPort.BaudRate = Com.acboard.BaudRate;
                acserialPort.StopBits = Com.acboard.StopBits;
                acserialPort.DataBits = Com.acboard.DataBits;
                acserialPort.Parity = Com.acboard.Parity;
                try
                {
                    acserialPort.Open();     //打开串口
                    actoolStripStatusLabel.Text = "交流板状态:已连接";
                    //开始进行初始化命令的发送
                    actoolStripStatusLabel.ForeColor = Color.Green;
                    
                }
                catch
                {                    
                    actoolStripStatusLabel.Text = "交流板状态:连接失败";
                    actoolStripStatusLabel.ForeColor = Color.Red;
                }
            }
        }
        private void 关闭设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!agserialPort.IsOpen)//如果串口是开
            { }
            else//如果串口是打开的则将其关闭
            {
                agserialPort.Close();                
                agtoolStripStatusLabel.Text = "安规设备状态:未连接";
                agtoolStripStatusLabel.ForeColor = Color.Gray;
            }
            if (!jlserialPort.IsOpen)//如果串口是开
            { }
            else//如果串口是打开的则将其关闭
            {
                jlserialPort.Close();
                jltoolStripStatusLabel.Text = "计量模块状态:未连接";
                jltoolStripStatusLabel.ForeColor = Color.Gray;
            }
            if (!acserialPort.IsOpen)//如果串口是开
            { }
            else//如果串口是打开的则将其关闭
            {
                acserialPort.Close();
                actoolStripStatusLabel.Text = "交流板状态:未连接";
                actoolStripStatusLabel.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region 帮助菜单
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.AboutBoxSaiter ab = new Dialog.AboutBoxSaiter();
            ab.StartPosition = FormStartPosition.CenterScreen;
            ab.ShowDialog();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 功能函数
        #region 串口设置，被动串口相关
        //获取串口设置参数
        private void initComSettings()
        {
            //AC交流板串口设置，绑定函数
            acserialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            //从数据库中获取初始化数据
            DataTable dt = op.getComSettings();
            /*binding 数据源*/
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["id"].ToString())
                    {
                        case "1"://ag
                            Com.ainuoangui.PortName = dt.Rows[i]["port"].ToString();
                            Com.ainuoangui.BaudRate = Convert.ToInt32(dt.Rows[i]["bundrate"].ToString(), 10);
                            float f = Convert.ToSingle(dt.Rows[i]["stopbit"].ToString().Trim());
                            if (f == 0)//设置停止位
                                Com.ainuoangui.StopBits = StopBits.None;
                            else if (f == 1.5)
                                Com.ainuoangui.StopBits = StopBits.OnePointFive;
                            else if (f == 1)
                                Com.ainuoangui.StopBits = StopBits.One;
                            else if (f == 2)
                                Com.ainuoangui.StopBits = StopBits.Two;
                            else
                                Com.ainuoangui.StopBits = StopBits.One;
                            //设置数据位
                            Com.ainuoangui.DataBits = Convert.ToInt32(dt.Rows[i]["databit"].ToString().Trim());
                            //设置奇偶校验位
                            string s = dt.Rows[i]["parity"].ToString().Trim();
                            if (s.CompareTo("无") == 0)
                                Com.ainuoangui.Parity = Parity.None;
                            else if (s.CompareTo("奇校验") == 0)
                                Com.ainuoangui.Parity = Parity.Odd;
                            else if (s.CompareTo("偶校验") == 0)
                                Com.ainuoangui.Parity = Parity.Even;
                            else
                                Com.ainuoangui.Parity = Parity.None;
                            break;
                        case "2"://jl
                            Com.jlmk.PortName = dt.Rows[i]["port"].ToString();
                            Com.jlmk.BaudRate = Convert.ToInt32(dt.Rows[i]["bundrate"].ToString(), 10);
                            f = Convert.ToSingle(dt.Rows[i]["stopbit"].ToString().Trim());
                            if (f == 0)//设置停止位
                                Com.jlmk.StopBits = StopBits.None;
                            else if (f == 1.5)
                                Com.jlmk.StopBits = StopBits.OnePointFive;
                            else if (f == 1)
                                Com.jlmk.StopBits = StopBits.One;
                            else if (f == 2)
                                Com.jlmk.StopBits = StopBits.Two;
                            else
                                Com.jlmk.StopBits = StopBits.One;
                            //设置数据位
                            Com.jlmk.DataBits = Convert.ToInt32(dt.Rows[i]["databit"].ToString().Trim());
                            //设置奇偶校验位
                            s = dt.Rows[i]["parity"].ToString().Trim();
                            if (s.CompareTo("无") == 0)
                                Com.jlmk.Parity = Parity.None;
                            else if (s.CompareTo("奇校验") == 0)
                                Com.jlmk.Parity = Parity.Odd;
                            else if (s.CompareTo("偶校验") == 0)
                                Com.jlmk.Parity = Parity.Even;
                            else
                                Com.jlmk.Parity = Parity.None;
                            break;
                        case "3"://acboard
                            Com.acboard.PortName = dt.Rows[i]["port"].ToString();
                            Com.acboard.BaudRate = Convert.ToInt32(dt.Rows[i]["bundrate"].ToString(), 10);
                            f = Convert.ToSingle(dt.Rows[i]["stopbit"].ToString().Trim());
                            if (f == 0)//设置停止位
                                Com.acboard.StopBits = StopBits.None;
                            else if (f == 1.5)
                                Com.acboard.StopBits = StopBits.OnePointFive;
                            else if (f == 1)
                                Com.acboard.StopBits = StopBits.One;
                            else if (f == 2)
                                Com.acboard.StopBits = StopBits.Two;
                            else
                                Com.acboard.StopBits = StopBits.One;
                            //设置数据位
                            Com.acboard.DataBits = Convert.ToInt32(dt.Rows[i]["databit"].ToString().Trim());
                            //设置奇偶校验位
                            s = dt.Rows[i]["parity"].ToString().Trim();
                            if (s.CompareTo("无") == 0)
                                Com.acboard.Parity = Parity.None;
                            else if (s.CompareTo("奇校验") == 0)
                                Com.acboard.Parity = Parity.Odd;
                            else if (s.CompareTo("偶校验") == 0)
                                Com.acboard.Parity = Parity.Even;
                            else
                                Com.acboard.Parity = Parity.None;
                            break;
                        case "4"://bms
                            Com.bms.PortName = dt.Rows[i]["port"].ToString();
                            Com.bms.BaudRate = Convert.ToInt32(dt.Rows[i]["bundrate"].ToString(), 10);
                            f = Convert.ToSingle(dt.Rows[i]["stopbit"].ToString().Trim());
                            if (f == 0)//设置停止位
                                Com.bms.StopBits = StopBits.None;
                            else if (f == 1.5)
                                Com.bms.StopBits = StopBits.OnePointFive;
                            else if (f == 1)
                                Com.bms.StopBits = StopBits.One;
                            else if (f == 2)
                                Com.bms.StopBits = StopBits.Two;
                            else
                                Com.bms.StopBits = StopBits.One;
                            //设置数据位
                            Com.bms.DataBits = Convert.ToInt32(dt.Rows[i]["databit"].ToString().Trim());
                            //设置奇偶校验位
                            s = dt.Rows[i]["parity"].ToString().Trim();
                            if (s.CompareTo("无") == 0)
                                Com.bms.Parity = Parity.None;
                            else if (s.CompareTo("奇校验") == 0)
                                Com.bms.Parity = Parity.Odd;
                            else if (s.CompareTo("偶校验") == 0)
                                Com.bms.Parity = Parity.Even;
                            else
                                Com.bms.Parity = Parity.None;
                            break;
                        case "5"://osc
                            Com.osc.PortName = dt.Rows[i]["port"].ToString();
                            Com.osc.BaudRate = Convert.ToInt32(dt.Rows[i]["bundrate"].ToString(), 10);
                            f = Convert.ToSingle(dt.Rows[i]["stopbit"].ToString().Trim());
                            if (f == 0)//设置停止位
                                Com.osc.StopBits = StopBits.None;
                            else if (f == 1.5)
                                Com.osc.StopBits = StopBits.OnePointFive;
                            else if (f == 1)
                                Com.osc.StopBits = StopBits.One;
                            else if (f == 2)
                                Com.osc.StopBits = StopBits.Two;
                            else
                                Com.osc.StopBits = StopBits.One;
                            //设置数据位
                            Com.osc.DataBits = Convert.ToInt32(dt.Rows[i]["databit"].ToString().Trim());
                            //设置奇偶校验位
                            s = dt.Rows[i]["parity"].ToString().Trim();
                            if (s.CompareTo("无") == 0)
                                Com.osc.Parity = Parity.None;
                            else if (s.CompareTo("奇校验") == 0)
                                Com.osc.Parity = Parity.Odd;
                            else if (s.CompareTo("偶校验") == 0)
                                Com.osc.Parity = Parity.Even;
                            else
                                Com.osc.Parity = Parity.None;
                            break;
                    }
                }
                //MessageBox.Show("end here!");
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e) //sp是串口控件
        {
            int n = acserialPort.BytesToRead;
            byte[] buf = new byte[n];            
            acserialPort.Read(buf, 0, n);

            //1.缓存数据
            buffer.AddRange(buf);
            //2.完整性判断
            while (buffer.Count >= 4) //至少包含帧头（2字节）、长度（1字节）、校验位（1字节）；根据设计不同而不同
            {
                //2.1 查找数据头
                if (buffer[0] == 0x8B) //传输数据有帧头，用于判断
                {
                    int len = buffer[2];
                    if (buffer.Count < len + 5) //数据区尚未接收完整
                    {
                        break;
                    }
                    //得到完整的数据，复制到ReceiveBytes中进行校验
                    byte[] ReceiveBytes = new byte[len + 5];
                    byte[] RecJY = new byte[len + 4];
                    buffer.CopyTo(0, ReceiveBytes, 0, len + 5);
                    buffer.CopyTo(0, RecJY, 0, len + 4);
                    byte jiaoyan; //开始校验
                    jiaoyan = Com.toolFunc.Get_CheckXor(RecJY);
                    if (jiaoyan != ReceiveBytes[len + 4]) //校验失败，最后一个字节是校验位
                    {
                        buffer.RemoveRange(0, len + 5);
                        //MessageBox.Show("数据包不正确！");
                        continue;
                    }
                    buffer.RemoveRange(0, len + 5);
                    /////执行其他代码，对数据进行处理。
                    GetData4Ac(ReceiveBytes);
                }
                else //帧头不正确时，记得清除
                {
                    buffer.RemoveAt(0);
                }
            }
        }
        private void GetData4Ac(byte[] data)
        {
            //将cmd指令取出
            byte[] cmd = toolFunc.sliceBytes2Array(data, 3, 2);
            //********************************电能数据*********************************
            //A1 2C 电压-2byte、电流-2byte
            if (cmd.SequenceEqual(Com.acboard.acA12C))
            {
                //MessageBox.Show("acA12C");
                Com.acboard.Axvolt = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 5, 2)) / 10).ToString("0.0");
                Com.acboard.Axcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 7, 2)) / 10).ToString("0.0");
                Com.acboard.Bxvolt = "0";
                Com.acboard.Bxcu = "0";
                Com.acboard.Cxvolt = "0";
                Com.acboard.Cxcu = "0";
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcA1C2Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //A1 3C 功率-2byte 电量-2byte
            if (cmd.SequenceEqual(Com.acboard.acA13C))
            {
                //MessageBox.Show("acA13C");
                Com.acboard.Bxvolt = "0";
                Com.acboard.Bxcu = "0";
                Com.acboard.Cxvolt = "0";
                Com.acboard.Cxcu = "0";
                Com.acboard.inpower = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 5, 2)) / 10).ToString("0.0");
                Com.acboard.chargeSingle = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 7, 2)) / 100).ToString("0.0");
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcA1C3Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //B2 2C A B C 电压-2byte、A B C 电流-2byte
            if (cmd.SequenceEqual(Com.acboard.acB22C))
            {
                //MessageBox.Show("acB22C");
                Com.acboard.Axvolt = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 5, 2)) / 10).ToString("0.0");
                Com.acboard.Bxvolt = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 7, 2)) / 10).ToString("0.0");
                Com.acboard.Cxvolt = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 9, 2)) / 10).ToString("0.0");

                Com.acboard.Axcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 11, 2)) / 10).ToString("0.0");
                Com.acboard.Bxcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 13, 2)) / 10).ToString("0.0");
                Com.acboard.Cxcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 15, 2)) / 10).ToString("0.0");
                
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcB2C2Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //B2 3C A B C 功率-4byte A B C 电量-2byte
            if (cmd.SequenceEqual(Com.acboard.acB23C))
            {
                //MessageBox.Show("acB23C");
                Com.acboard.inpower = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 5, 2)) / 100).ToString("0.00");
                Com.acboard.chargeSingle = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 7, 4)) / 100).ToString("0.0");                
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcB2C3Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //*******************************CP控制导引*********************************
            //C1 2C A枪 cp电压(1byte) 频率(2byte) 占空比(1byte) 电流(2byte)
            if (cmd.SequenceEqual(Com.acboard.acC12C))
            {
                //MessageBox.Show("acC12C");
                Com.acboard.cpvolt = (toolFunc.slice1Byte(data, 5, 1)).ToString();
                Com.acboard.cpfr = (toolFunc.slice2BytesArray(data, 6, 2)).ToString();
                Com.acboard.cpduty = (toolFunc.slice2BytesArray(data, 8, 1)).ToString();
                Com.acboard.cpcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 9, 2)) / 10).ToString("0.0");
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcC1C2Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //C1 3C B枪 cp电压(1byte) 频率(2byte) 占空比(1byte) 电流(2byte)
            if (cmd.SequenceEqual(Com.acboard.acC13C))
            {
                //MessageBox.Show("acC13C");
                Com.acboard.cpvolt = (toolFunc.slice2BytesArray(data, 5, 1)).ToString();
                Com.acboard.cpfr = (toolFunc.slice2BytesArray(data, 6, 2)).ToString();
                Com.acboard.cpduty = (toolFunc.slice2BytesArray(data, 8, 1)).ToString();
                Com.acboard.cpcu = (Convert.ToSingle(toolFunc.slice2BytesArray(data, 9, 2)) / 10).ToString("0.0");
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcC1C3Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //********************************连接状态*********************************
            //D1 2C 设备状态-1byte 设备状态= 00：显示“空闲” ；01～03 界面都显示“充电中”；EA～EC界面都显示“故障”；
            if (cmd.SequenceEqual(Com.acboard.acD12C))
            {
                //MessageBox.Show("acD12C");
                int sw = toolFunc.slice1Byte(data, 5, 1);
                switch (sw)
                {
                    case 0:
                        Com.acboard.chargestatus = "空闲";
                        //其他的状态也需要初始化一次，全部是0
                        Com.acboard.cpvolt = "0";
                        Com.acboard.cpfr = "0";
                        Com.acboard.cpduty = "0";
                        Com.acboard.cpcu = "0";
                        Com.acboard.Axvolt = "0";
                        Com.acboard.Axcu = "0";
                        Com.acboard.Bxvolt = "0";
                        Com.acboard.Bxcu = "0";
                        Com.acboard.Cxvolt = "0";
                        Com.acboard.Cxcu = "0";
                        Com.acboard.inpower = "0";
                        Com.acboard.chargeSingle = "0";
                        break;
                    case 1:
                        Com.acboard.chargestatus = "充电中";
                        break;
                    case 2:
                        Com.acboard.chargestatus = "充电中";
                        break;
                    case 3:
                        Com.acboard.chargestatus = "充电中";
                        break;
                    case 234:
                        Com.acboard.chargestatus = "故障";
                        break;
                    case 235:
                        Com.acboard.chargestatus = "故障";
                        break;
                    case 236:
                        Com.acboard.chargestatus = "故障";
                        break;
                }
                //发送返回指令
                Thread.Sleep(5);
                byte[] array = toolFunc.HexStringToByteArray(Com.acboard.pcD1C2Send.Trim());
                acserialPort.Write(array, 0, array.Length);
            }
            //********************************控制接地电阻接通、断开*********************************
            //F1 2C 
            if (cmd.SequenceEqual(Com.acboard.acF12C))
            {
                int sw = toolFunc.slice1Byte(data, 6, 1);
                switch (sw)
                {
                    case 0:
                        acboard.CmdOk = false;
                        break;
                    case 1:
                        acboard.CmdOk = true;
                        break;
                }
            }
        }
        #endregion
        public void ShowMessage(string msg)
        {
            this.Invoke(new MessageBoxShow(MessageBoxShow_F), new object[] { msg });
        }

        delegate void MessageBoxShow(string msg);
        void MessageBoxShow_F(string msg)
        {
            MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void UpdateDataGrid()
        {
            //if (this.dataGridView1.Rows.Count>0)
            //{
            //    this.dataGridView1.Rows.Clear();
            //}            
            /*禁止自动创建Column*/
            this.dataGridView1.AutoGenerateColumns = false;
            /*设置binding 属性值*/
            this.dataGridView1.Columns[0].DataPropertyName = "ischecked";
            this.dataGridView1.Columns[1].DataPropertyName = "sortid";
            this.dataGridView1.Columns[2].DataPropertyName = "testname";
            this.dataGridView1.Columns[3].DataPropertyName = "result";

            /*checkbox属性*/
            DataGridViewCheckBoxColumn checkbox = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkbox.TrueValue = "1";
            checkbox.FalseValue = "0";

            /*获取数据源*/
            DataTable dt = op.getItemView();

            /*binding 数据源*/
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }

        public void dcUpdateDataGrid()
        {
            //if (this.dataGridView1.Rows.Count > 0)
            //{
            //    this.dataGridView1.Rows.Clear();
            //}       
            /*禁止自动创建Column*/
            this.dataGridView1.AutoGenerateColumns = false;
            /*设置binding 属性值*/
            this.dataGridView1.Columns[0].DataPropertyName = "ischecked";
            this.dataGridView1.Columns[1].DataPropertyName = "sortid";
            this.dataGridView1.Columns[2].DataPropertyName = "testname";
            this.dataGridView1.Columns[3].DataPropertyName = "result";

            /*checkbox属性*/
            DataGridViewCheckBoxColumn checkbox = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkbox.TrueValue = "1";
            checkbox.FalseValue = "0";

            /*获取数据源*/
            DataTable dt = op.dcgetItemView();

            /*binding 数据源*/
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }

        public void UpdateMainViewRight()
        {
            Type type = Type.GetType("WindowsFormsApplication1.Funcs.MainView");
            object obj = Activator.CreateInstance(type);
            panel2.Controls.Clear();
            panel2.Controls.Add((UserControl)obj);
        }
        public void dcUpdateMainViewRight()
        {
            Type type = Type.GetType("WindowsFormsApplication1.DCFuncs.dcZhiLiuXTUCtrl");
            object obj = Activator.CreateInstance(type);
            panel2.Controls.Clear();
            panel2.Controls.Add((UserControl)obj);
        }
        public void DataChanged(object sender, EventArgs args)
        {
            // 更新窗体控件            
            UpdateDataGrid();
        }
        public void dcDataChanged(object sender, EventArgs args)
        {
            // 更新窗体控件            
            dcUpdateDataGrid();
        }
        public void Back2MainView(object sender, EventArgs args)
        {
            UpdateMainViewRight();

            UpdateDataGrid();
        }
        public void DCBack2MainView(object sender, EventArgs args)
        {
            dcUpdateMainViewRight();

            dcUpdateDataGrid();
        }
        //全选，取消全选按钮
        private void fullemptycbx_CheckedChanged(object sender, EventArgs e)
        {
            if (fullemptycbx.Checked)
            {
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == false)
                    {
                        checkCell.Value = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        checkCell.Value = false;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }
        
        #endregion

        private void startbtn_Click(object sender, EventArgs e)
        {
            if (acflag)
            {
                //交流测试
                //先保存选中的数据
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["checkbox"];
                        Boolean flag = Convert.ToBoolean(checkCell.Value);
                        int chk = flag ? 1 : 0;
                        DataGridViewTextBoxCell idCell = (DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells["sortid"];
                        int id = Convert.ToInt32(idCell.Value);
                        op.updatecheckedbyid(chk, id);
                    }
                }
                //然后开始测试流程
                //MessageBox.Show("选中交流项目已保存，开始测试流程");

                dtable = op.getItemViewChecked();

                /*取出数据并一个个进行测试*/
                if (dtable != null)
                {
                    //this.dataGridView1.DataSource = dt; 
                    Mytimer.Start();
                    TimeCount = 0;

                }
            }
            else
            {
                //直流测试
                //先保存选中的数据
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["checkbox"];
                        Boolean flag = Convert.ToBoolean(checkCell.Value);
                        int chk = flag ? 1 : 0;
                        DataGridViewTextBoxCell idCell = (DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells["sortid"];
                        int id = Convert.ToInt32(idCell.Value);
                        op.dcupdatecheckedbyid(chk, id);
                    }
                }
                //然后开始测试流程
                //MessageBox.Show("选中直流项目已保存，开始测试流程");

                dtable = op.dcgetItemViewChecked();

                /*取出数据并一个个进行测试*/
                if (dtable != null)
                {
                    //this.dataGridView1.DataSource = dt; 
                    Mytimer.Start();
                    TimeCount = 0;

                }
            }

        }

        



        


    }
}
