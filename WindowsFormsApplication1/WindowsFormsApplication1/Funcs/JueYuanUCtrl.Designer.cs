namespace WindowsFormsApplication1.Funcs
{
    partial class JueYuanUCtrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resuallbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.resultlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(81, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 36;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(72, 230);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(358, 43);
            this.richTextBox2.TabIndex = 34;
            this.richTextBox2.Text = "1、绝缘电阻应不小于10MΩ。";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(72, 124);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(358, 62);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "1、试验部位： \n1）交流充电桩输出L对地之间；\n2）交流充电桩输出N对地之间。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 288);
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
            this.label20.Location = new System.Drawing.Point(70, 204);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 31;
            this.label20.Text = "② 判定准则";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(70, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 12);
            this.label19.TabIndex = 32;
            this.label19.Text = "① 测试要求";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 19F);
            this.label18.Location = new System.Drawing.Point(140, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 26);
            this.label18.TabIndex = 33;
            this.label18.Text = "绝缘电阻试验";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "输出N对地绝缘电阻（MΩ）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "输出L对地绝缘电阻（MΩ）";
            // 
            // resuallbl
            // 
            this.resuallbl.AutoSize = true;
            this.resuallbl.Font = new System.Drawing.Font("宋体", 15F);
            this.resuallbl.Location = new System.Drawing.Point(189, 389);
            this.resuallbl.Name = "resuallbl";
            this.resuallbl.Size = new System.Drawing.Size(109, 20);
            this.resuallbl.TabIndex = 29;
            this.resuallbl.Text = "waiting...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "试验电压(V)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 21);
            this.textBox1.TabIndex = 40;
            this.textBox1.Text = "500";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15F);
            this.button2.Location = new System.Drawing.Point(247, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 44);
            this.button2.TabIndex = 41;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(225, 308);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(73, 21);
            this.textBox2.TabIndex = 40;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(225, 333);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(73, 21);
            this.textBox3.TabIndex = 40;
            this.textBox3.Text = "0";
            // 
            // resultlabel
            // 
            this.resultlabel.AutoSize = true;
            this.resultlabel.Location = new System.Drawing.Point(70, 396);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(71, 12);
            this.resultlabel.TabIndex = 29;
            this.resultlabel.Text = "状态:未测试";
            // 
            // JueYuanUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resuallbl);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "JueYuanUCtrl";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resuallbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label resultlabel;
    }
}
