using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using DataBase;

namespace WindowsFormsApplication1.Dialog
{
    public partial class ComDiag : Form
    {
        int COM_MAX = 16;//COM口号最大值
        public ComDiag()
        {
            InitializeComponent();
        }
        DbOps op = new DbOps();
        private void ComDiag_Load(object sender, EventArgs e)
        {
            //agportcbx.Text = "COM1";
            //jlportcbx.Text = "COM1";
            //acportcbx.Text = "COM1";
            //bmsportcbx.Text = "COM1";
            //oscportcbx.Text = "COM1";
            for (int i = 1; i < COM_MAX; i++)
            {
                agportcbx.Items.Add("COM" + i.ToString());
                jlportcbx.Items.Add("COM" + i.ToString());
                acportcbx.Items.Add("COM" + i.ToString());
                bmsportcbx.Items.Add("COM" + i.ToString());
                oscportcbx.Items.Add("COM" + i.ToString());
            }
            //agbundratecbx.Text = "38400";
            //jlbundratecbx.Text = "38400";
            //acbundratecbx.Text = "38400";
            //bmsbundratecbx.Text = "38400";
            //oscbundratecbx.Text = "38400";
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
                            agportcbx.Text = dt.Rows[i]["port"].ToString();
                            agbundratecbx.Text = dt.Rows[i]["bundrate"].ToString();
                            agdatacbx.Text = dt.Rows[i]["databit"].ToString();
                            agstopcbx.Text = dt.Rows[i]["stopbit"].ToString();
                            agverifycbx.Text = dt.Rows[i]["parity"].ToString();
                            break;
                        case "2"://jl
                            jlportcbx.Text = dt.Rows[i]["port"].ToString();
                            jlbundratecbx.Text = dt.Rows[i]["bundrate"].ToString();
                            jldatacbx.Text = dt.Rows[i]["databit"].ToString();
                            jlstopcbx.Text = dt.Rows[i]["stopbit"].ToString();
                            jlverifycbx.Text = dt.Rows[i]["parity"].ToString();
                            break;
                        case "3"://acboard
                            acportcbx.Text = dt.Rows[i]["port"].ToString();
                            acbundratecbx.Text = dt.Rows[i]["bundrate"].ToString();
                            acdatacbx.Text = dt.Rows[i]["databit"].ToString();
                            acstopcbx.Text = dt.Rows[i]["stopbit"].ToString();
                            acverifycbx.Text = dt.Rows[i]["parity"].ToString();
                            break;
                        case "4"://bms
                            bmsportcbx.Text = dt.Rows[i]["port"].ToString();
                            bmsbundratecbx.Text = dt.Rows[i]["bundrate"].ToString();
                            bmsdatacbx.Text = dt.Rows[i]["databit"].ToString();
                            bmsstopcbx.Text = dt.Rows[i]["stopbit"].ToString();
                            bmsverifycbx.Text = dt.Rows[i]["parity"].ToString();
                            break;
                        case "5"://osc
                            oscportcbx.Text = dt.Rows[i]["port"].ToString();
                            oscbundratecbx.Text = dt.Rows[i]["bundrate"].ToString();
                            oscdatacbx.Text = dt.Rows[i]["databit"].ToString();
                            oscstopcbx.Text = dt.Rows[i]["stopbit"].ToString();
                            oscverifycbx.Text = dt.Rows[i]["parity"].ToString();
                            break;
                    }                        
                }                    
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            //angui

            Com.ainuoangui.PortName = agportcbx.Text;
            Com.ainuoangui.BaudRate = Convert.ToInt32(agbundratecbx.Text, 10);
            float f = Convert.ToSingle(agstopcbx.Text.Trim());
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
            Com.ainuoangui.DataBits = Convert.ToInt32(agdatacbx.Text.Trim());
            //设置奇偶校验位
            string s = agverifycbx.Text.Trim();
            if (s.CompareTo("无") == 0)
                Com.ainuoangui.Parity = Parity.None;
            else if (s.CompareTo("奇校验") == 0)
                Com.ainuoangui.Parity = Parity.Odd;
            else if (s.CompareTo("偶校验") == 0)
                Com.ainuoangui.Parity = Parity.Even;
            else
                Com.ainuoangui.Parity = Parity.None; 
            //保存数据到数据库
            op.updateComSettings(1, Com.ainuoangui.PortName, Com.ainuoangui.BaudRate, Com.ainuoangui.DataBits, f, s);
         
            //-----------------------jiliang-----------------------------

            Com.jlmk.PortName = jlportcbx.Text;
            Com.jlmk.BaudRate = Convert.ToInt32(jlbundratecbx.Text, 10);
            f = Convert.ToSingle(jlstopcbx.Text.Trim());
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
            Com.jlmk.DataBits = Convert.ToInt32(jldatacbx.Text.Trim());
            //设置奇偶校验位
            s = jlverifycbx.Text.Trim();
            if (s.CompareTo("无") == 0)
                Com.jlmk.Parity = Parity.None;
            else if (s.CompareTo("奇校验") == 0)
                Com.jlmk.Parity = Parity.Odd;
            else if (s.CompareTo("偶校验") == 0)
                Com.jlmk.Parity = Parity.Even;
            else
                Com.jlmk.Parity = Parity.None;
            //保存数据到数据库
            op.updateComSettings(2, Com.jlmk.PortName, Com.jlmk.BaudRate, Com.jlmk.DataBits, f, s);
            //acboard
            Com.acboard.PortName = acportcbx.Text;
            Com.acboard.BaudRate = Convert.ToInt32(acbundratecbx.Text, 10);
            f = Convert.ToSingle(acstopcbx.Text.Trim());
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
            Com.acboard.DataBits = Convert.ToInt32(acdatacbx.Text.Trim());
            //设置奇偶校验位
            s = acverifycbx.Text.Trim();
            if (s.CompareTo("无") == 0)
                Com.acboard.Parity = Parity.None;
            else if (s.CompareTo("奇校验") == 0)
                Com.acboard.Parity = Parity.Odd;
            else if (s.CompareTo("偶校验") == 0)
                Com.acboard.Parity = Parity.Even;
            else
                Com.acboard.Parity = Parity.None;
            //保存数据到数据库
            op.updateComSettings(3, Com.acboard.PortName, Com.acboard.BaudRate, Com.acboard.DataBits, f, s);
            //bms
            Com.bms.PortName = bmsportcbx.Text;
            Com.bms.BaudRate = Convert.ToInt32(bmsbundratecbx.Text, 10);
            f = Convert.ToSingle(bmsstopcbx.Text.Trim());
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
            Com.bms.DataBits = Convert.ToInt32(bmsdatacbx.Text.Trim());
            //设置奇偶校验位
            s = bmsverifycbx.Text.Trim();
            if (s.CompareTo("无") == 0)
                Com.bms.Parity = Parity.None;
            else if (s.CompareTo("奇校验") == 0)
                Com.bms.Parity = Parity.Odd;
            else if (s.CompareTo("偶校验") == 0)
                Com.bms.Parity = Parity.Even;
            else
                Com.bms.Parity = Parity.None;
            //保存数据到数据库
            op.updateComSettings(4, Com.bms.PortName, Com.bms.BaudRate, Com.bms.DataBits, f, s);
            //osc
            Com.osc.PortName = oscportcbx.Text;
            Com.osc.BaudRate = Convert.ToInt32(oscbundratecbx.Text, 10);
            f = Convert.ToSingle(oscstopcbx.Text.Trim());
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
            Com.osc.DataBits = Convert.ToInt32(oscdatacbx.Text.Trim());
            //设置奇偶校验位
            s = oscverifycbx.Text.Trim();
            if (s.CompareTo("无") == 0)
                Com.osc.Parity = Parity.None;
            else if (s.CompareTo("奇校验") == 0)
                Com.osc.Parity = Parity.Odd;
            else if (s.CompareTo("偶校验") == 0)
                Com.osc.Parity = Parity.Even;
            else
                Com.osc.Parity = Parity.None;
            //保存数据到数据库
            op.updateComSettings(5, Com.osc.PortName, Com.osc.BaudRate, Com.osc.DataBits, f, s);
            this.Close();
        }


    }
}
