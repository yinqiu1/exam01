namespace WindowsFormsApplication1
{
    partial class LoginFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.login_btn = new System.Windows.Forms.Button();
            this.pwdTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usrnameTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rempwdckb = new System.Windows.Forms.CheckBox();
            this.autologincbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(102, 108);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "登 录";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // pwdTbx
            // 
            this.pwdTbx.Location = new System.Drawing.Point(102, 60);
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.PasswordChar = '*';
            this.pwdTbx.Size = new System.Drawing.Size(100, 21);
            this.pwdTbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // usrnameTbx
            // 
            this.usrnameTbx.Location = new System.Drawing.Point(102, 18);
            this.usrnameTbx.Name = "usrnameTbx";
            this.usrnameTbx.Size = new System.Drawing.Size(100, 21);
            this.usrnameTbx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // rempwdckb
            // 
            this.rempwdckb.AutoSize = true;
            this.rempwdckb.Location = new System.Drawing.Point(34, 87);
            this.rempwdckb.Name = "rempwdckb";
            this.rempwdckb.Size = new System.Drawing.Size(72, 16);
            this.rempwdckb.TabIndex = 3;
            this.rempwdckb.Text = "记住密码";
            this.rempwdckb.UseVisualStyleBackColor = true;
            // 
            // autologincbx
            // 
            this.autologincbx.AutoSize = true;
            this.autologincbx.Location = new System.Drawing.Point(124, 87);
            this.autologincbx.Name = "autologincbx";
            this.autologincbx.Size = new System.Drawing.Size(72, 16);
            this.autologincbx.TabIndex = 4;
            this.autologincbx.Text = "自动登录";
            this.autologincbx.UseVisualStyleBackColor = true;
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 147);
            this.Controls.Add(this.autologincbx);
            this.Controls.Add(this.rempwdckb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usrnameTbx);
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.login_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "赛特新能测试平台";
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox pwdTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usrnameTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox rempwdckb;
        private System.Windows.Forms.CheckBox autologincbx;
    }
}

