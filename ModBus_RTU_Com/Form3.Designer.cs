
namespace ModBus_RTU_Com
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tabConnect = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textWriteTimeO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textReadTimeO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.comboBaud = new System.Windows.Forms.ComboBox();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabModbus = new System.Windows.Forms.TabPage();
            this.textScanRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textRegAdd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioHex = new System.Windows.Forms.RadioButton();
            this.radioDec = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.comboFunc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textSlave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabConnect.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabModbus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConnect
            // 
            this.tabConnect.Controls.Add(this.tabPage1);
            this.tabConnect.Controls.Add(this.tabModbus);
            resources.ApplyResources(this.tabConnect, "tabConnect");
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textWriteTimeO);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textReadTimeO);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboStopBits);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboDataBits);
            this.tabPage1.Controls.Add(this.comboParity);
            this.tabPage1.Controls.Add(this.comboBaud);
            this.tabPage1.Controls.Add(this.comboPorts);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textWriteTimeO
            // 
            resources.ApplyResources(this.textWriteTimeO, "textWriteTimeO");
            this.textWriteTimeO.Name = "textWriteTimeO";
            this.textWriteTimeO.TextChanged += new System.EventHandler(this.textWriteTimeO_TextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // textReadTimeO
            // 
            resources.ApplyResources(this.textReadTimeO, "textReadTimeO");
            this.textReadTimeO.Name = "textReadTimeO";
            this.textReadTimeO.TextChanged += new System.EventHandler(this.textReadTimeO_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboStopBits
            // 
            this.comboStopBits.FormattingEnabled = true;
            resources.ApplyResources(this.comboStopBits, "comboStopBits");
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.SelectedIndexChanged += new System.EventHandler(this.comboStopBits_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // comboDataBits
            // 
            this.comboDataBits.FormattingEnabled = true;
            resources.ApplyResources(this.comboDataBits, "comboDataBits");
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.SelectedIndexChanged += new System.EventHandler(this.comboDataBits_SelectedIndexChanged);
            // 
            // comboParity
            // 
            this.comboParity.FormattingEnabled = true;
            resources.ApplyResources(this.comboParity, "comboParity");
            this.comboParity.Name = "comboParity";
            this.comboParity.SelectedIndexChanged += new System.EventHandler(this.comboParity_SelectedIndexChanged);
            // 
            // comboBaud
            // 
            this.comboBaud.FormattingEnabled = true;
            resources.ApplyResources(this.comboBaud, "comboBaud");
            this.comboBaud.Name = "comboBaud";
            this.comboBaud.SelectedIndexChanged += new System.EventHandler(this.comboBaud_SelectedIndexChanged);
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            resources.ApplyResources(this.comboPorts, "comboPorts");
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabModbus
            // 
            this.tabModbus.Controls.Add(this.textScanRate);
            this.tabModbus.Controls.Add(this.label12);
            this.tabModbus.Controls.Add(this.textQuantity);
            this.tabModbus.Controls.Add(this.label11);
            this.tabModbus.Controls.Add(this.textRegAdd);
            this.tabModbus.Controls.Add(this.groupBox1);
            this.tabModbus.Controls.Add(this.label10);
            this.tabModbus.Controls.Add(this.comboFunc);
            this.tabModbus.Controls.Add(this.label9);
            this.tabModbus.Controls.Add(this.textSlave);
            this.tabModbus.Controls.Add(this.label1);
            resources.ApplyResources(this.tabModbus, "tabModbus");
            this.tabModbus.Name = "tabModbus";
            this.tabModbus.UseVisualStyleBackColor = true;
            // 
            // textScanRate
            // 
            resources.ApplyResources(this.textScanRate, "textScanRate");
            this.textScanRate.Name = "textScanRate";
            this.textScanRate.TextChanged += new System.EventHandler(this.textScanRate_TextChanged);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // textQuantity
            // 
            resources.ApplyResources(this.textQuantity, "textQuantity");
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.TextChanged += new System.EventHandler(this.textQuantity_TextChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // textRegAdd
            // 
            resources.ApplyResources(this.textRegAdd, "textRegAdd");
            this.textRegAdd.Name = "textRegAdd";
            this.textRegAdd.TextChanged += new System.EventHandler(this.textRegAdd_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioHex);
            this.groupBox1.Controls.Add(this.radioDec);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioHex
            // 
            resources.ApplyResources(this.radioHex, "radioHex");
            this.radioHex.Name = "radioHex";
            this.radioHex.TabStop = true;
            this.radioHex.UseVisualStyleBackColor = true;
            this.radioHex.CheckedChanged += new System.EventHandler(this.radioHex_CheckedChanged);
            // 
            // radioDec
            // 
            resources.ApplyResources(this.radioDec, "radioDec");
            this.radioDec.Name = "radioDec";
            this.radioDec.TabStop = true;
            this.radioDec.UseVisualStyleBackColor = true;
            this.radioDec.CheckedChanged += new System.EventHandler(this.radioDec_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // comboFunc
            // 
            this.comboFunc.FormattingEnabled = true;
            resources.ApplyResources(this.comboFunc, "comboFunc");
            this.comboFunc.Name = "comboFunc";
            this.comboFunc.SelectedIndexChanged += new System.EventHandler(this.comboFunc_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textSlave
            // 
            resources.ApplyResources(this.textSlave, "textSlave");
            this.textSlave.Name = "textSlave";
            this.textSlave.TextChanged += new System.EventHandler(this.textSlave_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabConnect.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabModbus.ResumeLayout(false);
            this.tabModbus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConnect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabModbus;
        private System.Windows.Forms.ComboBox comboStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.ComboBox comboBaud;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textReadTimeO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textWriteTimeO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioDec;
        private System.Windows.Forms.RadioButton radioHex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboFunc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textSlave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textScanRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textRegAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}