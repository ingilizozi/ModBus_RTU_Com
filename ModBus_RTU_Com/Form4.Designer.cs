
namespace ModBus_RTU_Com
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabNode = new System.Windows.Forms.TabPage();
            this.btnRem_Node = new System.Windows.Forms.Button();
            this.btnAdd_Node = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textNodeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNode_ID = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textNodeDes = new System.Windows.Forms.TextBox();
            this.tabVariable = new System.Windows.Forms.TabPage();
            this.btnRem_Var = new System.Windows.Forms.Button();
            this.btnAdd_Variable = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboScale = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDataType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textRegValOrg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textRegValue = new System.Windows.Forms.TextBox();
            this.checkR_W = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textVar_Name = new System.Windows.Forms.TextBox();
            this.checkHex_Dec = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textModbus_Reg = new System.Windows.Forms.TextBox();
            this.checkVariable_Ena = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textVariable_Des = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeNode_Var = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGet_Info = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnSave_Log = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtRequestWilo = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFunc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBinary = new System.Windows.Forms.RichTextBox();
            this.TextRequest = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textSendHex = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSend_Hex = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabNode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabVariable.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.statusStrip1);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(943, 634);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Device Control Panel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(937, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(924, 616);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl3);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(916, 583);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Device Parameters";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl3.Controls.Add(this.tabNode);
            this.tabControl3.Controls.Add(this.tabVariable);
            this.tabControl3.Location = new System.Drawing.Point(419, 3);
            this.tabControl3.Multiline = true;
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.Padding = new System.Drawing.Point(6, 4);
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(481, 577);
            this.tabControl3.TabIndex = 8;
            // 
            // tabNode
            // 
            this.tabNode.Controls.Add(this.btnRem_Node);
            this.tabNode.Controls.Add(this.btnAdd_Node);
            this.tabNode.Controls.Add(this.groupBox5);
            this.tabNode.Location = new System.Drawing.Point(32, 4);
            this.tabNode.Name = "tabNode";
            this.tabNode.Padding = new System.Windows.Forms.Padding(3);
            this.tabNode.Size = new System.Drawing.Size(445, 569);
            this.tabNode.TabIndex = 0;
            this.tabNode.Text = "Nodes";
            this.tabNode.UseVisualStyleBackColor = true;
            // 
            // btnRem_Node
            // 
            this.btnRem_Node.Location = new System.Drawing.Point(6, 229);
            this.btnRem_Node.Name = "btnRem_Node";
            this.btnRem_Node.Size = new System.Drawing.Size(100, 31);
            this.btnRem_Node.TabIndex = 4;
            this.btnRem_Node.Text = "Remove";
            this.btnRem_Node.UseVisualStyleBackColor = true;
            this.btnRem_Node.Click += new System.EventHandler(this.btnRem_Node_Click);
            // 
            // btnAdd_Node
            // 
            this.btnAdd_Node.Location = new System.Drawing.Point(6, 175);
            this.btnAdd_Node.Name = "btnAdd_Node";
            this.btnAdd_Node.Size = new System.Drawing.Size(100, 31);
            this.btnAdd_Node.TabIndex = 3;
            this.btnAdd_Node.Text = "Add";
            this.btnAdd_Node.UseVisualStyleBackColor = true;
            this.btnAdd_Node.Click += new System.EventHandler(this.btnAdd_Node_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(112, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(327, 557);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Node Info";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.textNodeName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textNode_ID);
            this.panel4.Location = new System.Drawing.Point(6, 128);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 129);
            this.panel4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Node Name";
            // 
            // textNodeName
            // 
            this.textNodeName.Location = new System.Drawing.Point(162, 72);
            this.textNodeName.Name = "textNodeName";
            this.textNodeName.Size = new System.Drawing.Size(124, 27);
            this.textNodeName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Node ID";
            // 
            // textNode_ID
            // 
            this.textNode_ID.Location = new System.Drawing.Point(162, 30);
            this.textNode_ID.Name = "textNode_ID";
            this.textNode_ID.Size = new System.Drawing.Size(124, 27);
            this.textNode_ID.TabIndex = 6;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textNodeDes);
            this.groupBox6.Location = new System.Drawing.Point(6, 52);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(298, 70);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Description";
            // 
            // textNodeDes
            // 
            this.textNodeDes.Location = new System.Drawing.Point(6, 26);
            this.textNodeDes.Name = "textNodeDes";
            this.textNodeDes.Size = new System.Drawing.Size(286, 27);
            this.textNodeDes.TabIndex = 5;
            // 
            // tabVariable
            // 
            this.tabVariable.Controls.Add(this.btnRem_Var);
            this.tabVariable.Controls.Add(this.btnAdd_Variable);
            this.tabVariable.Controls.Add(this.groupBox7);
            this.tabVariable.Location = new System.Drawing.Point(32, 4);
            this.tabVariable.Name = "tabVariable";
            this.tabVariable.Padding = new System.Windows.Forms.Padding(3);
            this.tabVariable.Size = new System.Drawing.Size(445, 569);
            this.tabVariable.TabIndex = 1;
            this.tabVariable.Text = "Variables";
            this.tabVariable.UseVisualStyleBackColor = true;
            // 
            // btnRem_Var
            // 
            this.btnRem_Var.Location = new System.Drawing.Point(6, 229);
            this.btnRem_Var.Name = "btnRem_Var";
            this.btnRem_Var.Size = new System.Drawing.Size(100, 31);
            this.btnRem_Var.TabIndex = 10;
            this.btnRem_Var.Text = "Remove";
            this.btnRem_Var.UseVisualStyleBackColor = true;
            this.btnRem_Var.Click += new System.EventHandler(this.btnRem_Var_Click);
            // 
            // btnAdd_Variable
            // 
            this.btnAdd_Variable.Location = new System.Drawing.Point(6, 175);
            this.btnAdd_Variable.Name = "btnAdd_Variable";
            this.btnAdd_Variable.Size = new System.Drawing.Size(100, 31);
            this.btnAdd_Variable.TabIndex = 9;
            this.btnAdd_Variable.Text = "Add";
            this.btnAdd_Variable.UseVisualStyleBackColor = true;
            this.btnAdd_Variable.Click += new System.EventHandler(this.btnAdd_Variable_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel3);
            this.groupBox7.Controls.Add(this.panel2);
            this.groupBox7.Controls.Add(this.checkVariable_Ena);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Location = new System.Drawing.Point(112, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(327, 560);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Variable Info";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.comboUnit);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.comboScale);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboDataType);
            this.panel3.Location = new System.Drawing.Point(6, 416);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 128);
            this.panel3.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "Unit";
            // 
            // comboUnit
            // 
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Location = new System.Drawing.Point(110, 89);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(176, 28);
            this.comboUnit.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Scale";
            // 
            // comboScale
            // 
            this.comboScale.FormattingEnabled = true;
            this.comboScale.Location = new System.Drawing.Point(110, 49);
            this.comboScale.Name = "comboScale";
            this.comboScale.Size = new System.Drawing.Size(176, 28);
            this.comboScale.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Data Type";
            // 
            // comboDataType
            // 
            this.comboDataType.FormattingEnabled = true;
            this.comboDataType.Location = new System.Drawing.Point(110, 11);
            this.comboDataType.Name = "comboDataType";
            this.comboDataType.Size = new System.Drawing.Size(176, 28);
            this.comboDataType.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textRegValOrg);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textRegValue);
            this.panel2.Controls.Add(this.checkR_W);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textVar_Name);
            this.panel2.Controls.Add(this.checkHex_Dec);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textModbus_Reg);
            this.panel2.Location = new System.Drawing.Point(6, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 282);
            this.panel2.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Register Value(ORG) :";
            // 
            // textRegValOrg
            // 
            this.textRegValOrg.Location = new System.Drawing.Point(161, 159);
            this.textRegValOrg.Name = "textRegValOrg";
            this.textRegValOrg.Size = new System.Drawing.Size(124, 27);
            this.textRegValOrg.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Register Value :";
            // 
            // textRegValue
            // 
            this.textRegValue.Enabled = false;
            this.textRegValue.Location = new System.Drawing.Point(161, 116);
            this.textRegValue.Name = "textRegValue";
            this.textRegValue.Size = new System.Drawing.Size(124, 27);
            this.textRegValue.TabIndex = 15;
            // 
            // checkR_W
            // 
            this.checkR_W.AutoSize = true;
            this.checkR_W.Location = new System.Drawing.Point(11, 241);
            this.checkR_W.Name = "checkR_W";
            this.checkR_W.Size = new System.Drawing.Size(115, 24);
            this.checkR_W.TabIndex = 17;
            this.checkR_W.Text = "Read / Write";
            this.checkR_W.UseVisualStyleBackColor = true;
            this.checkR_W.CheckedChanged += new System.EventHandler(this.checkR_W_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Variable Name";
            // 
            // textVar_Name
            // 
            this.textVar_Name.Location = new System.Drawing.Point(161, 31);
            this.textVar_Name.Name = "textVar_Name";
            this.textVar_Name.Size = new System.Drawing.Size(124, 27);
            this.textVar_Name.TabIndex = 13;
            // 
            // checkHex_Dec
            // 
            this.checkHex_Dec.AutoSize = true;
            this.checkHex_Dec.Location = new System.Drawing.Point(11, 211);
            this.checkHex_Dec.Name = "checkHex_Dec";
            this.checkHex_Dec.Size = new System.Drawing.Size(101, 24);
            this.checkHex_Dec.TabIndex = 16;
            this.checkHex_Dec.Text = "HEX / DEC";
            this.checkHex_Dec.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Modbus Register";
            // 
            // textModbus_Reg
            // 
            this.textModbus_Reg.Location = new System.Drawing.Point(161, 72);
            this.textModbus_Reg.Name = "textModbus_Reg";
            this.textModbus_Reg.Size = new System.Drawing.Size(124, 27);
            this.textModbus_Reg.TabIndex = 14;
            // 
            // checkVariable_Ena
            // 
            this.checkVariable_Ena.AutoSize = true;
            this.checkVariable_Ena.Location = new System.Drawing.Point(17, 26);
            this.checkVariable_Ena.Name = "checkVariable_Ena";
            this.checkVariable_Ena.Size = new System.Drawing.Size(134, 24);
            this.checkVariable_Ena.TabIndex = 11;
            this.checkVariable_Ena.Text = "Enable Variable";
            this.checkVariable_Ena.UseVisualStyleBackColor = true;
            this.checkVariable_Ena.CheckedChanged += new System.EventHandler(this.checkVariable_Ena_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textVariable_Des);
            this.groupBox8.Location = new System.Drawing.Point(6, 52);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(298, 70);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Description";
            // 
            // textVariable_Des
            // 
            this.textVariable_Des.Location = new System.Drawing.Point(6, 26);
            this.textVariable_Des.Name = "textVariable_Des";
            this.textVariable_Des.Size = new System.Drawing.Size(286, 27);
            this.textVariable_Des.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblFileName);
            this.groupBox4.Controls.Add(this.btnOpen);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.treeNode_Var);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 564);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nodes and Variables";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 31);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(62, 20);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "Untitled";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(110, 514);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(98, 34);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeNode_Var
            // 
            this.treeNode_Var.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeNode_Var.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.treeNode_Var.Location = new System.Drawing.Point(6, 57);
            this.treeNode_Var.Name = "treeNode_Var";
            this.treeNode_Var.Size = new System.Drawing.Size(355, 442);
            this.treeNode_Var.TabIndex = 0;
            this.treeNode_Var.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNode_Var_AfterSelect);
            this.treeNode_Var.Click += new System.EventHandler(this.treeNode_Var_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnOpenLog);
            this.tabPage4.Controls.Add(this.btnClear);
            this.tabPage4.Controls.Add(this.btnGet_Info);
            this.tabPage4.Controls.Add(this.groupBox13);
            this.tabPage4.Controls.Add(this.btnSave_Log);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(916, 583);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Durum Bilgisi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(747, 68);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(140, 40);
            this.btnOpenLog.TabIndex = 5;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(747, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGet_Info
            // 
            this.btnGet_Info.Location = new System.Drawing.Point(747, 22);
            this.btnGet_Info.Name = "btnGet_Info";
            this.btnGet_Info.Size = new System.Drawing.Size(140, 40);
            this.btnGet_Info.TabIndex = 1;
            this.btnGet_Info.Text = "G&et Info";
            this.btnGet_Info.UseVisualStyleBackColor = true;
            this.btnGet_Info.Click += new System.EventHandler(this.btnGet_Info_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.radioButton2);
            this.groupBox13.Controls.Add(this.radioButton1);
            this.groupBox13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox13.ForeColor = System.Drawing.Color.Fuchsia;
            this.groupBox13.Location = new System.Drawing.Point(747, 226);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(139, 112);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Info Delay";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.ForeColor = System.Drawing.Color.Red;
            this.radioButton2.Location = new System.Drawing.Point(36, 71);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 27);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "OFF";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radioButton1.Location = new System.Drawing.Point(36, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 27);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "ON";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnSave_Log
            // 
            this.btnSave_Log.Location = new System.Drawing.Point(747, 114);
            this.btnSave_Log.Name = "btnSave_Log";
            this.btnSave_Log.Size = new System.Drawing.Size(140, 40);
            this.btnSave_Log.TabIndex = 2;
            this.btnSave_Log.Text = "S&ave Log";
            this.btnSave_Log.UseVisualStyleBackColor = true;
            this.btnSave_Log.Click += new System.EventHandler(this.btnSave_Log_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtRequestWilo);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox9.Location = new System.Drawing.Point(16, 22);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(713, 538);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "General Informations";
            // 
            // txtRequestWilo
            // 
            this.txtRequestWilo.Location = new System.Drawing.Point(6, 41);
            this.txtRequestWilo.Name = "txtRequestWilo";
            this.txtRequestWilo.ReadOnly = true;
            this.txtRequestWilo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtRequestWilo.Size = new System.Drawing.Size(701, 491);
            this.txtRequestWilo.TabIndex = 0;
            this.txtRequestWilo.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(943, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manuel Command Prompt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFunc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSend_Hex);
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 606);
            this.panel1.TabIndex = 10;
            // 
            // lblFunc
            // 
            this.lblFunc.AutoSize = true;
            this.lblFunc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFunc.Location = new System.Drawing.Point(584, 33);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(59, 23);
            this.lblFunc.TabIndex = 9;
            this.lblFunc.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(513, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "FUNC :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.TextRequest);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 467);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Hex Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBinary);
            this.groupBox3.Location = new System.Drawing.Point(0, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(861, 219);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request Binary Data";
            // 
            // textBinary
            // 
            this.textBinary.Location = new System.Drawing.Point(12, 26);
            this.textBinary.Name = "textBinary";
            this.textBinary.ReadOnly = true;
            this.textBinary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textBinary.Size = new System.Drawing.Size(836, 167);
            this.textBinary.TabIndex = 8;
            this.textBinary.Text = "";
            // 
            // TextRequest
            // 
            this.TextRequest.Location = new System.Drawing.Point(12, 26);
            this.TextRequest.Name = "TextRequest";
            this.TextRequest.ReadOnly = true;
            this.TextRequest.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.TextRequest.Size = new System.Drawing.Size(836, 167);
            this.TextRequest.TabIndex = 7;
            this.TextRequest.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ex&it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(374, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textSendHex);
            this.groupBox1.Location = new System.Drawing.Point(24, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Hex numbers separated by \" space\"";
            // 
            // textSendHex
            // 
            this.textSendHex.Location = new System.Drawing.Point(6, 26);
            this.textSendHex.Name = "textSendHex";
            this.textSendHex.Size = new System.Drawing.Size(453, 27);
            this.textSendHex.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "C&opy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "S&ave";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSend_Hex
            // 
            this.btnSend_Hex.Location = new System.Drawing.Point(30, 81);
            this.btnSend_Hex.Name = "btnSend_Hex";
            this.btnSend_Hex.Size = new System.Drawing.Size(110, 30);
            this.btnSend_Hex.TabIndex = 2;
            this.btnSend_Hex.Text = "S&end";
            this.btnSend_Hex.UseVisualStyleBackColor = true;
            this.btnSend_Hex.Click += new System.EventHandler(this.btnSend_Hex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(951, 667);
            this.tabControl1.TabIndex = 21;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Interval = 2500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 677);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Manual Command and Wilo Module";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabNode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabVariable.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabNode;
        private System.Windows.Forms.Button btnAdd_Node;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textNodeDes;
        private System.Windows.Forms.TabPage tabVariable;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView treeNode_Var;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnSave_Log;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox txtRequestWilo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox textBinary;
        private System.Windows.Forms.RichTextBox TextRequest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textSendHex;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSend_Hex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNode_ID;
        private System.Windows.Forms.Button btnAdd_Variable;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textModbus_Reg;
        private System.Windows.Forms.CheckBox checkVariable_Ena;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textVariable_Des;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnRem_Node;
        private System.Windows.Forms.Button btnRem_Var;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNodeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textVar_Name;
        private System.Windows.Forms.CheckBox checkHex_Dec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRegValue;
        private System.Windows.Forms.CheckBox checkR_W;
        private System.Windows.Forms.Button btnGet_Info;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboDataType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboScale;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRegValOrg;
    }
}