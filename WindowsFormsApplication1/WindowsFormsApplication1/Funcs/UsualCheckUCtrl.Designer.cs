namespace WindowsFormsApplication1.Funcs
{
    partial class UsualCheckUCtrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Pass = new System.Windows.Forms.RadioButton();
            this.Fail = new System.Windows.Forms.RadioButton();
            this.usrRtbx = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(83, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 17;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(74, 211);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(358, 43);
            this.richTextBox2.TabIndex = 15;
            this.richTextBox2.Text = "1、符合测试要求；";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(74, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(358, 106);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "1、检查充电机外壳应平整，无明显凹凸痕、划伤、变形等缺陷；\n2、表面涂镀层应均匀、不应脱落；零部件紧固可靠，无锈蚀、毛刺、裂纹等缺陷和损伤；\n3、所有铭牌、标志均" +
    "安装端正牢固，字迹清晰。";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(72, 347);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 11;
            this.label21.Text = "④ 测试结果";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(72, 185);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "② 判定准则";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "① 测试要求";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 19F);
            this.label18.Location = new System.Drawing.Point(182, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 26);
            this.label18.TabIndex = 14;
            this.label18.Text = "一般检查";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "③ 检查记录";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15F);
            this.button2.Location = new System.Drawing.Point(244, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 44);
            this.button2.TabIndex = 31;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.Location = new System.Drawing.Point(74, 372);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(47, 16);
            this.Pass.TabIndex = 32;
            this.Pass.TabStop = true;
            this.Pass.Text = "Pass";
            this.Pass.UseVisualStyleBackColor = true;
            // 
            // Fail
            // 
            this.Fail.AutoSize = true;
            this.Fail.Location = new System.Drawing.Point(127, 372);
            this.Fail.Name = "Fail";
            this.Fail.Size = new System.Drawing.Size(47, 16);
            this.Fail.TabIndex = 32;
            this.Fail.TabStop = true;
            this.Fail.Text = "Fail";
            this.Fail.UseVisualStyleBackColor = true;
            // 
            // usrRtbx
            // 
            this.usrRtbx.Location = new System.Drawing.Point(74, 272);
            this.usrRtbx.Name = "usrRtbx";
            this.usrRtbx.Size = new System.Drawing.Size(358, 72);
            this.usrRtbx.TabIndex = 15;
            this.usrRtbx.Text = "";
            // 
            // UsualCheckUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Fail);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usrRtbx);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "UsualCheckUCtrl";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton Pass;
        private System.Windows.Forms.RadioButton Fail;
        private System.Windows.Forms.RichTextBox usrRtbx;
    }
}
