using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLiteSugar;
using Demos;
using DataBase;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();            
        }         
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            //从cookie中获取自动登陆的状态、记录账号密码的状态
            if (op.getIsLogPwd() == 1)
            {
                //填充账号密码
                DataTable cookies = op.getCookies();
                usrnameTbx.Text = cookies.Rows[0]["username"].ToString();
                pwdTbx.Text = cookies.Rows[0]["passwd"].ToString();
                rempwdckb.Checked = true;
            }
            if (op.getIsAuto() == 1)
            {
                autologincbx.Checked = true;
                //Thread.Sleep(500);
                //执行登陆按钮
                this.BeginInvoke(new Action(() =>
                {
                    this.Hide();
                    this.Opacity = 1;
                }));
                #if true
                //从cookie数据库中获取账号和密码
                String pwd = op.getPwdbyUname(usrnameTbx.Text);

                if (pwd != pwdTbx.Text)
                {
                    MessageBox.Show("账号密码错误，请重新输入！");
                    return;
                }
                #else

                #endif
                Form MainFrm = new MainFrm();
                MainFrm.Show();
                
                MainFrm.Closed += new EventHandler(this.f2_Closed);  
            }
        }
        DbOps op = new DbOps();
        private void login_btn_Click(object sender, EventArgs e)
        {
            #if true
            
            //从cookie数据库中获取账号和密码
            String pwd = op.getPwdbyUname(usrnameTbx.Text);

            if(pwd != pwdTbx.Text)
            {
                MessageBox.Show("账号密码错误，请重新输入！");
                return;
            }
            //保存登陆信息
            int isAuto = 0;
            int isLogPwd = 0;
            if (autologincbx.Checked)
            {
                isAuto = 1;
            }
            if(rempwdckb.Checked){
                isLogPwd = 1;
            }

            op.updateCookies(usrnameTbx.Text, pwdTbx.Text, isAuto, isLogPwd);

            #else

            #endif
            Form MainFrm = new MainFrm();            
            MainFrm.Show();
            this.Hide();
            MainFrm.Closed += new EventHandler(this.f2_Closed);  
        }
        private void f2_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
    }
}
