namespace WindowsFormsApplication1.DCFuncs
{
    partial class dcSoftStartUCtrl
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.resultlabel = new System.Windows.Forms.Label();
            this.resuallbl = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15F);
            this.button2.Location = new System.Drawing.Point(244, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 44);
            this.button2.TabIndex = 36;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(81, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 37;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(72, 155);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(358, 43);
            this.richTextBox2.TabIndex = 34;
            this.richTextBox2.Text = "1、符合测试要求；";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(72, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(358, 67);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "将充电机连接测试系统并启动，用示波器测量输出电压的变化曲线，输出电压应该具有缓慢或阶梯上升的过程，输出电压从开始上升至额定稳定时的变化时间应在1～8s。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "③ 检查记录";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 361);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 30;
            this.label21.Text = "④ 测试结果";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(70, 131);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 31;
            this.label20.Text = "② 判定准则";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(70, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 12);
            this.label19.TabIndex = 32;
            this.label19.Text = "① 测试方法和要求";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 19F);
            this.label18.Location = new System.Drawing.Point(197, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 26);
            this.label18.TabIndex = 33;
            this.label18.Text = "软启动";
            // 
            // resultlabel
            // 
            this.resultlabel.AutoSize = true;
            this.resultlabel.Location = new System.Drawing.Point(99, 391);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(71, 12);
            this.resultlabel.TabIndex = 78;
            this.resultlabel.Text = "状态:未测试";
            // 
            // resuallbl
            // 
            this.resuallbl.AutoSize = true;
            this.resuallbl.Font = new System.Drawing.Font("宋体", 15F);
            this.resuallbl.Location = new System.Drawing.Point(240, 384);
            this.resuallbl.Name = "resuallbl";
            this.resuallbl.Size = new System.Drawing.Size(109, 20);
            this.resuallbl.TabIndex = 79;
            this.resuallbl.Text = "waiting...";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(205, 283);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 21);
            this.textBox2.TabIndex = 83;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 21);
            this.textBox1.TabIndex = 82;
            this.textBox1.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 81;
            this.label5.Text = "输出电流（A）:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 80;
            this.label4.Text = "输出电压（V）:";
            // 
            // dcSoftStartUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.resuallbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "dcSoftStartUCtrl";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label resultlabel;
        private System.Windows.Forms.Label resuallbl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
