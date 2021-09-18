
namespace ModBus_RTU_Com
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.checkDelay = new System.Windows.Forms.CheckBox();
            this.btnReadHoldingReg = new System.Windows.Forms.Button();
            this.btnWriteHoldingRegisters = new System.Windows.Forms.Button();
            this.btnStopReading = new System.Windows.Forms.Button();
            this.textEdit_Reg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit_Reg = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHex_Dec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regList = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkDelay
            // 
            this.checkDelay.AutoSize = true;
            this.checkDelay.Location = new System.Drawing.Point(14, 8);
            this.checkDelay.Name = "checkDelay";
            this.checkDelay.Size = new System.Drawing.Size(146, 27);
            this.checkDelay.TabIndex = 3;
            this.checkDelay.Text = "Delay Request";
            this.checkDelay.UseVisualStyleBackColor = true;
            this.checkDelay.CheckedChanged += new System.EventHandler(this.checkDelay_CheckedChanged);
            // 
            // btnReadHoldingReg
            // 
            this.btnReadHoldingReg.Location = new System.Drawing.Point(14, 41);
            this.btnReadHoldingReg.Name = "btnReadHoldingReg";
            this.btnReadHoldingReg.Size = new System.Drawing.Size(245, 33);
            this.btnReadHoldingReg.TabIndex = 4;
            this.btnReadHoldingReg.Text = "Read Holding Registers";
            this.btnReadHoldingReg.UseVisualStyleBackColor = true;
            this.btnReadHoldingReg.Click += new System.EventHandler(this.btnReadHoldingReg_Click);
            // 
            // btnWriteHoldingRegisters
            // 
            this.btnWriteHoldingRegisters.Location = new System.Drawing.Point(14, 131);
            this.btnWriteHoldingRegisters.Name = "btnWriteHoldingRegisters";
            this.btnWriteHoldingRegisters.Size = new System.Drawing.Size(245, 33);
            this.btnWriteHoldingRegisters.TabIndex = 6;
            this.btnWriteHoldingRegisters.Text = "Write Holding Registers";
            this.btnWriteHoldingRegisters.UseVisualStyleBackColor = true;
            this.btnWriteHoldingRegisters.Click += new System.EventHandler(this.btnWriteHodigRegisters_Click);
            // 
            // btnStopReading
            // 
            this.btnStopReading.Location = new System.Drawing.Point(14, 80);
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.Size = new System.Drawing.Size(245, 33);
            this.btnStopReading.TabIndex = 5;
            this.btnStopReading.Text = "Stop Reading Registers";
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);
            // 
            // textEdit_Reg
            // 
            this.textEdit_Reg.Location = new System.Drawing.Point(168, 436);
            this.textEdit_Reg.Name = "textEdit_Reg";
            this.textEdit_Reg.Size = new System.Drawing.Size(91, 30);
            this.textEdit_Reg.TabIndex = 1;
            this.textEdit_Reg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit_Reg_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Edit Registry Key";
            // 
            // btnEdit_Reg
            // 
            this.btnEdit_Reg.Location = new System.Drawing.Point(14, 474);
            this.btnEdit_Reg.Name = "btnEdit_Reg";
            this.btnEdit_Reg.Size = new System.Drawing.Size(245, 33);
            this.btnEdit_Reg.TabIndex = 2;
            this.btnEdit_Reg.Text = "Edit Reg Key";
            this.btnEdit_Reg.UseVisualStyleBackColor = true;
            this.btnEdit_Reg.Click += new System.EventHandler(this.btnEdit_Reg_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblHex_Dec);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnEdit_Reg);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textEdit_Reg);
            this.panel2.Controls.Add(this.btnStopReading);
            this.panel2.Controls.Add(this.btnWriteHoldingRegisters);
            this.panel2.Controls.Add(this.btnReadHoldingReg);
            this.panel2.Controls.Add(this.checkDelay);
            this.panel2.Location = new System.Drawing.Point(540, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 520);
            this.panel2.TabIndex = 7;
            // 
            // lblHex_Dec
            // 
            this.lblHex_Dec.AutoSize = true;
            this.lblHex_Dec.ForeColor = System.Drawing.Color.Green;
            this.lblHex_Dec.Location = new System.Drawing.Point(146, 182);
            this.lblHex_Dec.Name = "lblHex_Dec";
            this.lblHex_Dec.Size = new System.Drawing.Size(113, 23);
            this.lblHex_Dec.TabIndex = 11;
            this.lblHex_Dec.Text = "Hexadecimal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Okuma Modu :";
            // 
            // regList
            // 
            this.regList.GridLines = true;
            this.regList.HideSelection = false;
            this.regList.Location = new System.Drawing.Point(15, 30);
            this.regList.Name = "regList";
            this.regList.Size = new System.Drawing.Size(470, 470);
            this.regList.TabIndex = 12;
            this.regList.UseCompatibleStateImageBehavior = false;
            this.regList.SelectedIndexChanged += new System.EventHandler(this.regList_SelectedIndexChanged);
            this.regList.DoubleClick += new System.EventHandler(this.regList_DoubleClick_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.regList);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 520);
            this.panel1.TabIndex = 8;
            this.panel1.TabStop = false;
            this.panel1.Text = "Request Data";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkDelay;
        private System.Windows.Forms.Button btnReadHoldingReg;
        private System.Windows.Forms.Button btnWriteHoldingRegisters;
        private System.Windows.Forms.Button btnStopReading;
        private System.Windows.Forms.TextBox textEdit_Reg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit_Reg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHex_Dec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView regList;
        private System.Windows.Forms.GroupBox panel1;
    }
}