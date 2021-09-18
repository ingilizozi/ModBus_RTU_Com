using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ModBus_RTU_Com
{
    public partial class Form4 : Form
    {
        XmlDocument doc = new XmlDocument();
        StringBuilder sb = new StringBuilder();
        //The content of each line of XML
        private string xmlLine = "";

        bool hx_ = false;

        //Load
        SerialPort serialPort = new SerialPort();
        all_Data all_DATA = new all_Data();
        String request_Text = "";
        public bool sel_Parent = false;
        ushort reg_Add_DEV;
        string textHex = "";

        bool delay_Get_Info = false;
        private readonly string[] DataTypes = { "INT8", "UINT16", "BOOL", "ENUM", "BITMAP" };
        private readonly string[] Scale_ = { "1", "0.1", "0.01", "0.001" };
        private readonly string[] Unit_ = { "%", "bar", "m", "K", "°C", "cm", "/min", "h", "psi", "/day", "/month", "Hz", "W", "Kwh", "null" };

        private string result = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            lblFunc.Text = "";
            toolStripStatusLabel1.Text = "Please insert data.";
            for(int i = 0; i < DataTypes.Length; i++)
            {
                comboDataType.Items.Add(DataTypes[i]);
            }
            for (int i = 0; i < Scale_.Length; i++)
            {
                comboScale.Items.Add(Scale_[i]);
            }
            for (int i = 0; i < Unit_.Length; i++)
            {
                comboUnit.Items.Add(Unit_[i]);
            }
        }

        private void btnSend_Hex_Click(object sender, EventArgs e)
        {
            string tmp = "";
            string[] tmp0;

            String func_;

                comPort(textSendHex.Text);
                if (request_Text.Length > 0)
                {
                    string[] tmp2 = new string[request_Text.Length - 5];
                    func_ = request_Text.Substring(3, 2);

                    switch (func_)
                    {
                        case "03":
                            lblFunc.Text = "Reading Holding Reg";
                            textBinary.Text = "";
                            tmp = request_Text.Substring(0, request_Text.Length - 7);
                            tmp0 = tmp.Split(' ');

                            for (int i = 0; i < tmp0.Length; i++)
                            {
                                tmp2[i] = all_DATA.HexStringToBinary(tmp0[i]);
                                textBinary.Text += tmp2[i] + "  ";
                            }
                            break;
                        case "04":
                            lblFunc.Text = "Reading Input Reg";
                            
                                textBinary.Text = "";
                                tmp = request_Text.Substring(0, request_Text.Length - 7);
                                tmp0 = tmp.Split(' ');

                                //                            tmp1 = tmp.Replace(" ", "");
                                for (int i = 0; i < tmp0.Length; i++)
                                {
                                    tmp2[i] = all_DATA.HexStringToBinary(tmp0[i]);
                                    textBinary.Text += tmp2[i] + "  ";
                                }
                            break;
                        case "05":
                            lblFunc.Text = "Force Input Coils";

                            textBinary.Text = "";
                            tmp = request_Text.Substring(0, request_Text.Length - 7);
                            tmp0 = tmp.Split(' ');

                            for (int i = 0; i < tmp0.Length; i++)
                            {
                                tmp2[i] = all_DATA.HexStringToBinary(tmp0[i]);
                                textBinary.Text += tmp2[i] + "  ";
                            }
                            break;
                        case "06":
                            lblFunc.Text = "Writing Holding Reg";
                            textBinary.Text = "";
                            tmp = request_Text.Substring(0, request_Text.Length - 7);
                            tmp0 = tmp.Split(' ');

                            for (int i = 0; i < tmp0.Length; i++)
                            {
                                tmp2[i] = all_DATA.HexStringToBinary(tmp0[i]);
                                textBinary.Text += tmp2[i] + "  ";
                            }
                            break;
                        case "10":
                            lblFunc.Text = "Writing many Holding Registers";
                            textBinary.Text = "";
                            tmp = request_Text.Substring(0, request_Text.Length - 7);
                            tmp0 = tmp.Split(' ');

                            for (int i = 0; i < tmp0.Length; i++)
                            {
                                tmp2[i] = all_DATA.HexStringToBinary(tmp0[i]);
                                textBinary.Text += tmp2[i] + "  ";
                            }
                            break;
                        case "84":
                            lblFunc.Text = "Geçersiz adres!";
                            break;
                        default:
                            lblFunc.Text = "Bekleniyor.";
                            break;
                    }
                }
                else
                {
                    textBinary.Text = "Sonuç alınamadı.";
                }
            
        }

        public String Read()
        {
            string message = "";
            bool _continue = true;
            all_DATA.InitializeData();
            all_DATA.connect_RTU();
            while (_continue)
            {
                try
                {
                    message = all_DATA.serialPort.ReadLine();
                    return message;
                }
                catch (TimeoutException) { }
            }
            return message;
        }
        private int readSerial()
        {
            int req;
            all_DATA.InitializeData();
            all_DATA.connect_RTU();

            req = all_DATA.serialPort.ReadByte();
            all_DATA.serialPort.Close();
            return req;
        }

        public String Read_Byte()
        {
            all_DATA.InitializeData();
            all_DATA.connect_RTU();
            return all_DATA.serialPort.ReadExisting();
        }

        /// <summary>
        /// Kendisine parametre olarak girilen dizeyi SerialPort aracılığı ile Com port'a gönderir.
        /// </summary>
        /// <param name="txt"></param>
        private void comPort(string txt)
        {
            String ss = CRCForModbus(txt);
            String resu = textSendHex.Text + ss;
            String[] liste = resu.Split(' ');
            Byte[] veri = new Byte[textSendHex.Text.Length];
            try
            {
                if (all_DATA.serialPort != null)
                {
                    all_DATA.InitializeData();
                    all_DATA.connect_RTU();
                    ushort[] registers = new ushort[textSendHex.Text.Length];

                    for (int b = 0; b < liste.Length; b++)
                    {
                        registers[b] = ushort.Parse(liste[b], System.Globalization.NumberStyles.HexNumber);
                        veri[b] = Convert.ToByte(registers[b]);
                    }
                }

                all_DATA.serialPort.Encoding = System.Text.Encoding.UTF8;
                all_DATA.serialPort.Write(veri, 0, txt.Length);
                System.Threading.Thread.Sleep(150);
                TextRequest.Text += Identify(all_DATA.serialPort) + "\n";
                all_DATA.serialPort.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Form4 comPort() Func!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                all_DATA.serialPort.Close();
            }
        }

        public byte[] ConvertNumToByte2(ushort Number)
        {
            byte[] ByteArray = new byte[0x10];
            string BinString = Convert.ToString(Number, 2);
            char[] BinCharArray = BinString.ToCharArray();
            try
            {
                System.Array.Reverse(BinCharArray);
                if (BinCharArray != null && BinCharArray.Length > 0)
                {
                    for (int index = 0; index < BinCharArray.Length; ++index)
                    {
                        ByteArray[index] = Convert.ToByte(Convert.ToString(BinCharArray[index]));
                    }
                }
            }
            catch
            {
            }
            return ByteArray;
        }

        public byte[] ConvertNumToByte1(ushort Number)
        {
            byte[] ByteArray = new byte[0x08];
            string BinString = Convert.ToString(Number, 2);
            char[] BinCharArray = BinString.ToCharArray();
            try
            {
                System.Array.Reverse(BinCharArray);
                if (BinCharArray != null && BinCharArray.Length > 0)
                {
                    for (int index = 0; index < BinCharArray.Length; ++index)
                    {
                        ByteArray[index] = Convert.ToByte(Convert.ToString(BinCharArray[index]));
                    }
                }
            }
            catch
            {
            }
            return ByteArray;
        }

        /// <summary>
        /// Kendisine girilen SerialPort nesnesine modbus için kullanılan RTU protokolüne gönderilen sorgunun yanıtını alır(Hex olarak.).
        /// </summary>
        /// <param name="port"></param>
        /// <returns>Dönüş mesajı Hex olarak</returns>
        public string Identify(SerialPort port)
        {
            request_Text = "";
            string returnMessage = "";
            try
            {
                System.Threading.Thread.Sleep(1500); // Fails sometimes if this delay is any shorter

                System.Threading.Thread.Sleep(500); // Fails sometimes if this delay is any shorter

                int count = port.BytesToRead;
                int intReturnASCII = 0;
                while (count > 0)
                {
                    intReturnASCII = port.ReadByte();
                    returnMessage = returnMessage + " " + intReturnASCII.ToString("X02");
                    request_Text += intReturnASCII.ToString("X02") + " ";
                    count--;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "Form4 Identify Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                port.Close();
            }

            return returnMessage.Trim();
        }

        /// <summary>
        /// Modebus için CRC kodu üretir. Parametre olarak girilen Hex veya Int dizeyi CRC modbus koduna çevirir.
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>CRC kodu String olarak</returns>
         private static String CRCForModbus(String data)
        {
            // Handle digital conversion
            String tmp = "";
            String tmp1 = "";
            String sendBuf = data;
            String sendnoNull1 = sendBuf.Trim();// Remove spaces before and after the string
            String sendnoNull2 = sendnoNull1.Replace(" ", "");//Remove spaces in the middle of the string
            String sendNOComma = sendnoNull2.Replace(',', ' '); //Remove the English comma
            String sendNOComma1 = sendNOComma.Replace(',', ' '); //Remove Chinese comma
            String strSendNoComma2 = sendNOComma1.Replace("0x", ""); // Remove 0x
            data = strSendNoComma2.Replace("0X", ""); //Remove 0X

            Byte[] crcbuf = strToToHexByte(data);


                         // Calculate and fill in the CRC check code
            Int32 crc = 0xffff;
            Int32 len = crcbuf.Length;
            for (Int32 n = 0; n < len; n++)
            {
                Byte i;
                crc = crc ^ crcbuf[n];
                for (i = 0; i < 8; i++)
                {
                    Int32 TT;
                    TT = crc & 1;
                    crc = crc >> 1;
                    crc = crc & 0x7fff;
                    if (TT == 1)
                    {
                        crc = crc ^ 0xa001;
                    }
                    crc = crc & 0xffff;
                }
            }
            crc = ((crc & 0xFF) << 8 | (crc >> 8));//High and low byte transposition
            String CRCString = crc.ToString("X02");
            if (CRCString.Length > 3)
            {
                tmp = CRCString.Substring(0, 2);
                tmp1 = CRCString.Substring(2, 2);
            }
            else if(CRCString.Length > 2)
            {
                tmp = CRCString.Substring(0, 1);
                tmp1 = CRCString.Substring(1, 2);
            }
            else if(CRCString.Length > 1)
            {
                tmp = CRCString.Substring(0, 2);
            }

            return " " + tmp + " " + tmp1;
        }

        /// <summary>
        /// hexadecimal string to byte array
        /// </summary>
        /// <param name="hexString">hex string</param>
        /// <returns> returns a byte array</returns>
        private static Byte[] strToToHexByte(String hexString)
        {
            hexString = hexString.Replace(" ", " ");
            if ((hexString.Length % 2) != 0)
                hexString = hexString.Insert(hexString.Length - 1, 0.ToString());
            Byte[] returnBytes = new Byte[hexString.Length / 2];
            for (Int32 i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextRequest.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextRequest.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextRequest.Text != "")
            {
                try
                {
                    saveFileDialog1.Filter = "Metin Dosyası | *.txt";
                    saveFileDialog1.OverwritePrompt = true;
                    saveFileDialog1.CreatePrompt = false;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter kayit = new StreamWriter(saveFileDialog1.FileName);
                        kayit.WriteLine(TextRequest.Text + "\n" + textBinary.Text);
                        kayit.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Save Button!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (all_DATA.serialPort != null)
            {
                all_DATA.readHoldingRegisters();
            }
        }

        /// <summary>
        /// TreeView nesnesi için girilen özellikler ile yeni bir Node ekler, Eğer bu Node seçilirse seçilen Node için modifiye
        /// yapacak şekilde hazır hale gelir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Node_Click(object sender, EventArgs e)
        { 
            if (btnAdd_Node.Text == "Add")
            {
                if (textNodeDes.TextLength > 0 && textNode_ID.TextLength > 0)
                {
                    treeNode_Var.Nodes.Add(textNodeName.Text + " " + textNode_ID.Text, textNodeDes.Text);
                    textNodeDes.Text = "";
                    textNode_ID.Text = "";
                    textNodeName.Text = "";
                    treeNode_Var.EndUpdate();
                }
            }
            else
            {
                if (textNodeDes.TextLength > 0 && treeNode_Var.SelectedNode != null)
                {
                    treeNode_Var.SelectedNode.Text = textNodeDes.Text;
                    treeNode_Var.SelectedNode.Name = textNodeName.Text + " " + textNode_ID.Text;
                    textNodeDes.Text = "";
                    textNode_ID.Text = "";
                    textNodeName.Text = "";
                }
            }
        }

        private void btnRem_Node_Click(object sender, EventArgs e)
        {
            if (treeNode_Var.Nodes.Count > 0 && treeNode_Var.SelectedNode != null && sel_Parent)
            {
                try
                {
                    treeNode_Var.SelectedNode.Remove();
                    toolStripStatusLabel1.Text = "Remove Node Successfull.";
                }
                catch (Exception ex)
                {

                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// TreeView alanına girilen özellikleri ile yeni bir alt Node ekler, Eğer bu alt Node seçilirse buton özelliği modifiye edecek şekilde
        /// değişerek düzenleme için hazır hale gelir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Variable_Click(object sender, EventArgs e)
        {
            if (btnAdd_Variable.Text == "Add")
            {
                if (textVariable_Des.TextLength > 0 && treeNode_Var.SelectedNode != null)
                {
                    treeNode_Var.SelectedNode.Nodes.Add(textVar_Name.Text + " " + checkVariable_Ena.Checked + " " + textModbus_Reg.Text + " " + checkHex_Dec.Checked + " " + checkR_W.Checked + " " + comboDataType.SelectedIndex + " " + comboScale.SelectedIndex + " " + comboUnit.SelectedIndex, textVariable_Des.Text);

                    textModbus_Reg.Text = "";
                    textVariable_Des.Text = "";
                    textVar_Name.Text = "";
                    textRegValue.Text = "";
                    textRegValOrg.Text = "";
                }
            }
            else
            {
                if (textVariable_Des.TextLength > 0 && treeNode_Var.SelectedNode != null)
                {
                    treeNode_Var.SelectedNode.Text = textVariable_Des.Text;
                    treeNode_Var.SelectedNode.Name = textVar_Name.Text + " " + checkVariable_Ena.Checked + " " + textModbus_Reg.Text + " " + checkHex_Dec.Checked + " " + checkR_W.Checked + " " + comboDataType.SelectedIndex + " " + comboScale.SelectedIndex + " " + comboUnit.SelectedIndex;

                    treeNode_Var.EndUpdate();
                    string[] tokensV = treeNode_Var.SelectedNode.Name.Split(' ');

                    if (checkVariable_Ena.Checked && textRegValue.Text != "")
                    {
                        if (checkR_W.Checked)
                        {
                            textHex = textRegValOrg.Text;
                            string[] wr = new string[1];
                            wr[0] = textHex;
                            all_DATA.InitializeData();
                            all_DATA.connect_RTU();
                            all_DATA.writeHoldingRegistersDevice(wr, tokensV[2], bool.Parse(tokensV[3]));
                            all_DATA.serialPort.Close();
                        }
                    }

                    textVariable_Des.Text = "";
                    textVar_Name.Text = "";
                    textModbus_Reg.Text = "";
                    textRegValue.Text = "";
                    textRegValOrg.Text = "";
                }
            }
        }

        private void btnRem_Var_Click(object sender, EventArgs e)
        {
            if (treeNode_Var.Nodes.Count > 0 && treeNode_Var.SelectedNode != null && !sel_Parent)
            {
                try
                {
                    treeNode_Var.SelectedNode.Remove();
                    toolStripStatusLabel1.Text = "Remove Variable Successfull.";
                }
                catch (Exception ex)
                {

                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// treeNodeVar seçilen node için gerekli bilgileri ekrana basar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeNode_Var_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent!=null && e.Node.Parent.GetType() == typeof(TreeNode) )
            {
                string[] tokensV = treeNode_Var.SelectedNode.Name.Split(' ');
                sel_Parent = false;
                if (!tabVariable.IsAccessible)
                {
                    btnAdd_Variable.Text = "Modify";

                    textVariable_Des.Text = treeNode_Var.SelectedNode.Text;
                    textVar_Name.Text = tokensV[0];
                    textModbus_Reg.Text = tokensV[2];
                    
                    reg_Add_DEV = ushort.Parse(tokensV[2]);
                    checkVariable_Ena.Checked = bool.Parse(tokensV[1]);

                    hx_ = bool.Parse(tokensV[3]);

                    checkHex_Dec.Checked = bool.Parse(tokensV[3]);
                    checkR_W.Checked = bool.Parse(tokensV[4]);

                    comboDataType.SelectedIndex = int.Parse(tokensV[5]);
                    comboScale.SelectedIndex = int.Parse(tokensV[6]);
                    comboUnit.SelectedIndex = int.Parse(tokensV[7]);

                    Get_Node_Properties();
                }
                else
                {
                    btnAdd_Variable.Text = "Add";

                    textVariable_Des.Text = "";
                    textModbus_Reg.Text = "";
                    textVar_Name.Text = "";
                    textRegValue.Text = "";
                }
            }
            else
            {
                string[] tokensT = treeNode_Var.SelectedNode.Name.Split(' ');
                sel_Parent = true;
                if (!tabNode.IsAccessible)
                {
                    btnAdd_Node.Text = "Modify";
                    textNodeDes.Text = treeNode_Var.SelectedNode.Text;
                    textNodeName.Text = tokensT[0];
                    textNode_ID.Text = tokensT[1];
                }
                else
                {
                    btnAdd_Node.Text = "Add";
                    textNodeDes.Text = "";
                    textNode_ID.Text = "";
                    textNodeName.Text = "";
                }
            }
        }
        /// <summary>
        /// Node'un içeriğini TextRegValue textbox'a yazar.
        /// </summary>
        private void Get_Node_Properties()
        {
            if (checkVariable_Ena.Checked)
            {
                all_DATA.InitializeData();
                all_DATA.connect_RTU();
                all_DATA.readHoldingRegistersDevice(hx_, reg_Add_DEV, 1);
                textRegValOrg.Text = all_DATA.textResult_Dev[0];
                switch (comboScale.SelectedIndex)
                {
                    case 0:
                        switch (comboUnit.SelectedIndex)
                        {
//                        "%", "bar", "m", "K", "°C", "cm", "/min", "h", "psi", "/day", "/month", "Hz", "W", "Kwh", "null"
                            case 0:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " %";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " %";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " %";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " %";
                                }
                                break;
                            case 1:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " bar";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " bar";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " bar";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " bar";
                                }
                                    break;
                            case 2:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " m";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " m";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " m";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " m";
                                }
                                break;
                            case 3:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " K";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " K";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " K";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " K";
                                }
                                break;
                            case 4:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " °C";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " °C";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " °C";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " °C";
                                }
                                break;
                            case 5:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " cm";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " cm";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " cm";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " cm";
                                }
                                break;
                            case 6:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /min";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /min";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /min";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /min";
                                }
                                break;
                            case 7:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " h";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " h";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " h";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " h";
                                }
                                break;
                            case 8:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " psi";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " psi";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " psi";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " psi";
                                }
                                break;
                            case 9:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /day";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /day";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /day";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /day";
                                }
                                break;
                            case 10:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /month";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " /month";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /month";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " /month";
                                }
                                break;
                            case 11:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " Hz";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " Hz";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " Hz";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " Hz";
                                }
                                break;
                            case 12:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " W";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " W";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " W";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " W";
                                }
                                break;
                            case 13:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " kwh";
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString() + " kwh";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " kwh";
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString() + " kwh";
                                }
                                break;
                            case 14:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString();
                                    result = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 1).ToString();
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString();
                                    result = (int.Parse(all_DATA.textResult_Dev[0]) * 1).ToString();
                                }
                                break;
                        }
                        break;
                    case 1:
                        switch (comboUnit.SelectedIndex)
                        {
                            //                        "%", "bar", "m", "K", "°C", "cm", "/min", "h", "psi", "/day", "/month", "Hz", "W", "Kwh", "null"
                            case 0:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " %";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " %";
                                }
                                break;
                            case 1:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " bar";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " bar";
                                }
                                break;
                            case 2:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " m";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " m";
                                }
                                break;
                            case 3:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " K";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " K";
                                }
                                break;
                            case 4:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " °C";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " °C";
                                }
                                break;
                            case 5:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " cm";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " cm";
                                }
                                break;
                            case 6:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " /min";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " /min";
                                }
                                break;
                            case 7:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " h";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " h";
                                }
                                break;
                            case 8:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " psi";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " psi";
                                }
                                break;
                            case 9:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " /day";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " /day";
                                }
                                break;
                            case 10:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " /month";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " /month";
                                }
                                break;
                            case 11:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " Hz";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " Hz";
                                }
                                break;
                            case 12:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " W";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " W";
                                }
                                break;
                            case 13:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString() + " kwh";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString() + " kwh";
                                }
                                break;
                            case 14:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.1).ToString();
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.1).ToString();
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (comboUnit.SelectedIndex)
                        {
                            //                        "%", "bar", "m", "K", "°C", "cm", "/min", "h", "psi", "/day", "/month", "Hz", "W", "Kwh", "null"
                            case 0:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " %";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " %";
                                }
                                break;
                            case 1:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " bar";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " bar";
                                }
                                break;
                            case 2:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " m";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " m";
                                }
                                break;
                            case 3:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " K";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " K";
                                }
                                break;
                            case 4:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " °C";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " °C";
                                }
                                break;
                            case 5:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " cm";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " cm";
                                }
                                break;
                            case 6:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " /min";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " /min";
                                }
                                break;
                            case 7:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " h";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " h";
                                }
                                break;
                            case 8:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " psi";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " psi";
                                }
                                break;
                            case 9:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " /day";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " /day";
                                }
                                break;
                            case 10:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " /month";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " /month";
                                }
                                break;
                            case 11:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " Hz";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " Hz";
                                }
                                break;
                            case 12:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " W";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " W";
                                }
                                break;
                            case 13:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString() + " kwh";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString() + " kwh";
                                }
                                break;
                            case 14:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.01).ToString();
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.01).ToString();
                                }
                                break;
                        }
                        break;
                    case 3:
                        switch (comboUnit.SelectedIndex)
                        {
                            //                        "%", "bar", "m", "K", "°C", "cm", "/min", "h", "psi", "/day", "/month", "Hz", "W", "Kwh", "null"
                            case 0:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " %";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " %";
                                }
                                break;
                            case 1:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " bar";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " bar";
                                }
                                break;
                            case 2:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " m";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " m";
                                }
                                break;
                            case 3:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " K";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " K";
                                }
                                break;
                            case 4:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " °C";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " °C";
                                }
                                break;
                            case 5:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " cm";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " cm";
                                }
                                break;
                            case 6:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " /min";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " /min";
                                }
                                break;
                            case 7:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " h";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " h";
                                }
                                break;
                            case 8:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " psi";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " psi";
                                }
                                break;
                            case 9:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " /day";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " /day";
                                }
                                break;
                            case 10:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " /month";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " /month";
                                }
                                break;
                            case 11:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " Hz";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " Hz";
                                }
                                break;
                            case 12:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " W";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " W";
                                }
                                break;
                            case 13:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString() + " kwh";
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString() + " kwh";
                                }
                                break;
                            case 14:
                                if (hx_)
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0], System.Globalization.NumberStyles.HexNumber) * 0.001).ToString();
                                }
                                else
                                {
                                    textRegValue.Text = (int.Parse(all_DATA.textResult_Dev[0]) * 0.001).ToString();
                                }
                                break;
                        }
                        break;
                }

                all_DATA.serialPort.Close();
                if (checkR_W.Checked)
                {
                    textRegValOrg.Enabled = true;
                }
                else
                {
                    textRegValOrg.Enabled = false;
                }
            }
            else
            {
                textRegValue.Text = "";
            }
        }
        private void treeNode_Var_Click(object sender, EventArgs e)
        {
            treeNode_Var.SelectedNode = null;
            btnAdd_Node.Text = "Add";
            btnAdd_Variable.Text = "Add";
            textNodeDes.Text = "";
            textNode_ID.Text = "";
            textVariable_Des.Text = "";
            textVar_Name.Text = "";
            textModbus_Reg.Text = "";
            textNodeName.Text = "";
            textRegValue.Text = "";
        }

        /// <summary>
        /// Xml dosyasını SaveFileDialog1 nesnesi ile dosya yoluna kaydeder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = "";
            try
            {
                saveFileDialog1.Filter = "XML Dosyası | *.xml";
                saveFileDialog1.OverwritePrompt = false;
                saveFileDialog1.CreatePrompt = false;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    SaveToXml(path);
                    toolStripStatusLabel1.Text = "Save Successfull.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void parseNode(TreeNode tn, StringBuilder sb)
        {
            IEnumerator ie = tn.Nodes.GetEnumerator();

            while (ie.MoveNext())
            {
                TreeNode ctn = (TreeNode)ie.Current;
                xmlLine = GetRSSText(ctn);
                sb.Append(xmlLine);
                //If there are children, continue to traverse
                if (ctn.Nodes.Count > 0)
                {
                    parseNode(ctn, sb);
                }
                sb.Append("</Node>");
            }
        }

        //XML text line of adult RSS node
        private string GetRSSText(TreeNode node)
        {
            //Generate XML text based on Node attributes
            string rssText = "<Node Name=\"" + node.Name + "\" Text=\"" + node.Text + "\" >";

            return rssText;
        }
 
        /// <summary>
        /// Xml dosyasını OpenFileDialog1 nesnesi ile açar ve TreeView Nodes'lerine aktarır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";
            openFileDialog1.Filter = "XML Dosyası | *.xml";
            openFileDialog1.Title = "Dosya Açma";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treeNode_Var.Nodes.Clear();
                path = openFileDialog1.FileName;
                lblFileName.Text = "File Name: " + Path.GetFileNameWithoutExtension(path);
                doc.Load(path); //I put the xml in the debug. Your path is casual. But this is more convenient.
                RecursionTreeControl(doc.DocumentElement, treeNode_Var.Nodes);//Display the loaded XML file in the TreeView control
                treeNode_Var.ExpandAll();//Expand all items in the TreeView control
                toolStripStatusLabel1.Text = "Open Successfull.";
            }

        }

        /// <summary>
        /// Xml dosyasındaki node'ları TreeNodeCollection nesnesine çevirir.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="nodes"></param>
        private void RecursionTreeControl(XmlNode xmlNode, TreeNodeCollection nodes)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)//loop through the collection of child elements of the current element
            {
                TreeNode new_child = new TreeNode();//Define a TreeNode node object
                new_child.Name = node.Attributes["Name"].Value;
                new_child.Text = node.Attributes["Text"].Value;
                nodes.Add(new_child);//Add the current node to the current TreeNodeCollection collection
                RecursionTreeControl(node, new_child.Nodes);//Call this method for recursion
            }
        }

        /// <summary>
        /// Xml Dosyasını kendisine verilen parametre ile dosya yoluna kaydeder.
        /// </summary>
        /// <param name="path"></param>
        private void SaveToXml(string path)
        {
            XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xml = new XDocument(dec);

            XElement root = new XElement("Tree");

            foreach (TreeNode node in treeNode_Var.Nodes)
            {
                XElement e = CreateElements(node);
                root.Add(e);
            }
            xml.Add(root);
            xml.Save(path);
        }

        private XElement CreateElements(TreeNode node)
        {
            XElement root = CreateElement(node);

            foreach (TreeNode n in node.Nodes)
            {
                XElement e = CreateElements(n);
                root.Add(e);
            }
           return root;
        }

        private XElement CreateElement(TreeNode node)
        {
            return new XElement("Node",
                new XAttribute("Name", node.Name),
                new XAttribute("Text", node.Text)
                );
        }

        private void checkR_W_CheckedChanged(object sender, EventArgs e)
        {
            if (checkR_W.Checked)
            {
                textRegValOrg.Enabled = true;
            }
            else
            {
                textRegValOrg.Enabled = false;
            }
        }

        private void checkVariable_Ena_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVariable_Ena.Checked)
            {
                textModbus_Reg.Enabled = true;
                textVariable_Des.Enabled = true;
                textVar_Name.Enabled = true;
                checkHex_Dec.Enabled = true;
                checkR_W.Enabled = true;
            }
            else
            {
                textModbus_Reg.Enabled = false;
                textVariable_Des.Enabled = false;
                textVar_Name.Enabled = false;
                checkHex_Dec.Enabled = false;
                checkR_W.Enabled = false;
            }
        }

        private void btnGet_Info_Click(object sender, EventArgs e)
        {
            Get_RegInfo(treeNode_Var);
        }

        /// <summary>
        /// Kendisine parametre olarak girilen TreeView nesnesinin içeriği ile içeriğin adresine göre kayıtlı bilgilerini ekrana basar.
        /// </summary>
        /// <param name="trNode"></param>
        private void Get_RegInfo(TreeView trNode)
        {
            string[] regtmp = new string[trNode.Nodes.Count];
            string[] regtmp1 = new string[trNode.Nodes.Count];
            string[] regtmp2 = new string[trNode.Nodes.Count];
            string[] dd = new string[regtmp2.Length];

            for (int i = 0; i < trNode.Nodes.Count; i++)
            {
                for (int k = 0; k < trNode.Nodes[i].Nodes.Count; k++)
                {
                    regtmp[i] = trNode.Nodes[i].Nodes[k].Text;
                }
            }

            for (int i = 0; i < trNode.Nodes.Count; i++)
            {
                for (int k = 0; k < trNode.Nodes[i].Nodes.Count; k++)
                {
                    regtmp1[i] += trNode.Nodes[i].Nodes[k].Name;
                    regtmp2[i] = regtmp1[i];

                    string[] regff = regtmp2[i].Split(' ');

                    all_DATA.InitializeData();
                    all_DATA.connect_RTU();
                    dd[i] = " " + all_DATA.ReadHoldingRegistersDevRes(ushort.Parse(regff[2]))[0];
                    

                    all_DATA.serialPort.Close();
                }
            }

            
            for (int y = 0; y < regtmp2.Length; y++)
            {
                if (!delay_Get_Info)
                {
                    txtRequestWilo.Text += regtmp[y] + " " + dd[y] + "\n";
                    toolStripStatusLabel1.Text = "Reading Info from Modbus Device.";
                }
                else
                {
                    txtRequestWilo.Text += regtmp[y] + " " + dd[y] + "\n";
                    toolStripStatusLabel1.Text = "Reading Info from Modbus Device with Delay.";
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Get_RegInfo(treeNode_Var);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                timer2.Enabled = true;
                delay_Get_Info = true;
            }
            else
            {
                timer2.Enabled = false;
                delay_Get_Info = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRequestWilo.Text = "";
        }

        private void btnSave_Log_Click(object sender, EventArgs e)
        {
            if (txtRequestWilo.Text != "")
            {
                try
                {
                    saveFileDialog1.Filter = "Log Dosyası | *.log";
                    saveFileDialog1.OverwritePrompt = true;
                    saveFileDialog1.CreatePrompt = false;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter kayit = new StreamWriter(saveFileDialog1.FileName);
                        kayit.WriteLine("Kayıt Bilgileri: \n" + txtRequestWilo.Text);
                        kayit.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Save Button!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            string s = "";
            txtRequestWilo.Text = "";
                try
                {
                    openFileDialog1.Filter = "Log Dosyası | *.log";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader kayit = File.OpenText(openFileDialog1.FileName);
                    while ((s=kayit.ReadLine()) != null)
                    {
                        txtRequestWilo.Text += s + "\n";
                    }
                        kayit.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Open Button!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }            
        }
    }

}
