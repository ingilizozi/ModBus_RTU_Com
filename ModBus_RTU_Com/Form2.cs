using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModBus_RTU_Com
{
    public partial class Form2 : Form
    {
        all_Data all_DATA = new all_Data();
        public ushort result;
        String regN = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            Point pt = new Point();
            pt.X = this.Size.Width - 340;
            regList.Width = this.Size.Width - 430;
            regList.Height = this.Size.Height - 130;
            panel1.Width = this.Size.Width - 400;
            panel1.Height = this.Size.Height - 80;
            panel2.Location = pt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Point pt = new Point();
            all_DATA.InitializeData();
            pt.X = this.Size.Width - 340;
            regList.Width = this.Size.Width - 430;
            regList.Height = this.Size.Height - 130;
            panel1.Width = this.Size.Width - 400;
            panel1.Height = this.Size.Height - 80;
            panel2.Location = pt;

            if (checkDelay.Checked)
            {
                btnStopReading.Enabled = true;
                btnWriteHoldingRegisters.Enabled = false;
                btnEdit_Reg.Enabled = false;
                textEdit_Reg.Enabled = false;
            }
            else
            {
                btnStopReading.Enabled = false;
                if (regList.Items.Count > 0 && regList.Items.Count <= 10)
                {
                    btnWriteHoldingRegisters.Enabled = true;
                    btnEdit_Reg.Enabled = true;
                    textEdit_Reg.Enabled = true;
                }
                else
                {
                    btnWriteHoldingRegisters.Enabled = false;
                    btnEdit_Reg.Enabled = false;
                    textEdit_Reg.Enabled = false;
                }
                timer1.Enabled = false;
            }
            if (all_DATA.hex_Sel)
            {
                lblHex_Dec.Text = "Hexadecimal";
            }
            else
            {
                lblHex_Dec.Text = "Decimal";
            }

            if (all_DATA.funcSel_ == 3)
            {
                btnWriteHoldingRegisters.Enabled = false;
            }
            else if (all_DATA.funcSel_ == 2)
            {
                btnWriteHoldingRegisters.Enabled = true;
            }
            else
            {
                btnWriteHoldingRegisters.Enabled = true;
            }

            btnStopReading.Enabled = false;
            pt.X = this.Size.Width - 280;

            timer1.Interval = all_DATA.scanRate;
        }

        private void btnReadHoldingReg_Click(object sender, EventArgs e)
        {
            all_DATA.InitializeData();
            timer1.Interval = all_DATA.scanRate;
            if (!checkDelay.Checked)
            {
                regList.Clear();
                readHoldingRegisters();
                btnWriteHoldingRegisters.Enabled = true;
                btnEdit_Reg.Enabled = true;
                textEdit_Reg.Enabled = true;
            }
            else
            {
                timer1.Enabled = true;
            }
            if (all_DATA.hex_Sel)
            {
                lblHex_Dec.Text = "Hexadecimal";
            }
            else
            {
                lblHex_Dec.Text = "Decimal";
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_DATA.serialPort.Close();
        }

        private void btnEdit_Reg_Click(object sender, EventArgs e)
        {
            SetListBoxSelectedValue(regList, textEdit_Reg.Text);
        }

        public static string GetListBoxSelectedValue(ListView Listbox1)
        {
            string selectedItem = "";
            if (Listbox1.Items.Count > 0)
            {
                for (int i = 0; i < Listbox1.Items.Count; i++)
                {
                    if (Listbox1.Items[i].Selected)
                    {
                        if (selectedItem == "")
                        {
                            selectedItem = Listbox1.Items[i].Text;
                            break;
                        }
                    }
                }
            }
            return selectedItem;
        }

        public string[] GetListBoxAllValue(ListView Listbox1)
        {
            string[] selectedItem = new String[Listbox1.Items.Count + 1];
            try
            {
                if (Listbox1.Items.Count > 0)
                {
                    for (int i = 0; i < Listbox1.Items.Count; i++)
                    {
                        if (all_DATA.hex_Sel)
                        {
                            selectedItem[i] = ushort.Parse(Listbox1.Items[i].Text, System.Globalization.NumberStyles.HexNumber).ToString();
                        }
                        else
                        {
                            selectedItem[i] = Listbox1.Items[i].Text;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return selectedItem;
        }

        public int OnlyHexInString(ListView list)
        {
            int sonuc = -1;
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            String tmp = "";
            for (int i = 0; i < list.Items.Count; i++)
            {
                tmp += list.Items[i].Text;
            }
            String buff = tmp.Trim();

            if (System.Text.RegularExpressions.Regex.IsMatch(buff, @"\A\b[0-9a-fA-F]+\b\Z"))
            {
                sonuc = 1;
            }
            else
                sonuc = 0;

            return sonuc;
        }

        public int hex_Control(ListView list)
        {
            int hex_Value = -1;
            String tmp = "";
            for(int i = 0; i < list.Items.Count; i++)
            {
                tmp += list.Items[i].Text;
            }
            String buff = tmp.Trim();

            char[] val = { 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f',
                '0','1','2','3','4','5','6','7','8','9'};
            
            if (buff.IndexOfAny(val) == -1)
            {
                hex_Value = 0;
            }
            else if(buff.IndexOfAny(val) >= 0)
            {
                hex_Value = 1;
            }
            return hex_Value;
        }
        public static void SetListBoxSelectedValue(ListView Listbox1, String sel)
        {
            string selectedItem = "";
            if (Listbox1.Items.Count > 0)
            {
                for (int i = 0; i < Listbox1.Items.Count; i++)
                {
                    if (Listbox1.Items[i].Selected)
                    {
                        if (selectedItem == "")
                        {
                            Listbox1.Items[i].Text = sel;
                            break;
                        }
                    }
                }
            }
        }

        private void btnWriteHodigRegisters_Click(object sender, EventArgs e)
        {
            all_DATA.InitializeData();
            if (regList.Items.Count > 0)
            {
                if (all_DATA.hex_Sel)
                {
                    lblHex_Dec.Text = "Hexadecimal";
                }
                else
                {
                    lblHex_Dec.Text = "Decimal";
                }
                writeHoldingRegisters();
                regList.Clear();
                readHoldingRegisters();
            }
        }

        private void writeHoldingRegisters()
        {
            all_DATA.InitializeData();
            all_DATA.connect_RTU();
            all_DATA.textResult = GetListBoxAllValue(regList);
            all_DATA.writeHoldingRegisters();
            all_DATA.serialPort.Close();
        }

        private void readHoldingRegisters()
        {

            all_DATA.InitializeData();
            all_DATA.connect_RTU();
            all_DATA.readHoldingRegisters();
            for (int i = 0; i < all_DATA.textResult.Length; i++)
            {
                regList.Items.Add(all_DATA.textResult[i]);
            }
            all_DATA.serialPort.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            readHoldingRegisters();
        }

        private void checkDelay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDelay.Checked)
            {
                btnStopReading.Enabled = true;
                btnWriteHoldingRegisters.Enabled = false;
                btnEdit_Reg.Enabled = false;
                textEdit_Reg.Enabled = false;
            }
            else
            {
                btnStopReading.Enabled = false;
                if (regList.Items.Count > 0 && regList.Items.Count <= 10)
                {
                    btnWriteHoldingRegisters.Enabled = true;
                    btnEdit_Reg.Enabled = true;
                    textEdit_Reg.Enabled = true;
                }
                else
                {
                    btnWriteHoldingRegisters.Enabled = false;
                    btnEdit_Reg.Enabled = false;
                    textEdit_Reg.Enabled = false;
                }
                timer1.Enabled = false;
            }

        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void textEdit_Reg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textEdit_Reg.Text != "")
                {
                    SetListBoxSelectedValue(regList, textEdit_Reg.Text);
                }
            }
        }

        private void regList_DoubleClick_1(object sender, EventArgs e)
        {
            input_Dialog input_ = new input_Dialog();
            String a = "";
            String b = "";
            if (regList.Items.Count > 0)
            {
                for (int i = 0; i < regList.Items.Count; i++)
                {
                    if (regList.Items[i].Selected)
                    {
                        b = regList.Items[i].Text;
                        input_.InputBox("Register Değeri Girin.", "Değeri girin :", ref a, b);
                        regList.Items[i].Text = string.Format("{0:X02}", a);
                        break;
                    }
                }
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            all_DATA.InitializeData();

            if (all_DATA.hex_Sel)
            {
                lblHex_Dec.Text = "Hexadecimal";
            }
            else
            {
                lblHex_Dec.Text = "Decimal";
            }

            if (all_DATA.funcSel_ == 3 && regList.Items.Count > 0 && regList.Items.Count <= 10)
            {
                btnWriteHoldingRegisters.Enabled = false;
            }
            else if (all_DATA.funcSel_ == 2 && regList.Items.Count > 0 && regList.Items.Count <= 10)
            {
                btnWriteHoldingRegisters.Enabled = true;
            }
            else
            {
                btnWriteHoldingRegisters.Enabled = false;
            }
        }

        private void regList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkDelay.Checked)
            {
                regN = GetListBoxSelectedValue(regList);
                textEdit_Reg.Text = regN;
            }
        }
    }
}
