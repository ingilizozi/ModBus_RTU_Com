using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModBus_RTU_Com
{
    public partial class Form3 : Form
    {
        all_Data all_DATA = new all_Data();
        public Form3()
        {
            InitializeComponent();
        }

 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                all_DATA.write_Config_Data();
            }
            catch (Exception ei)
            {
                MessageBox.Show(this, ei.Message, "Form3 Ok Button!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all_DATA.disconnect_Write_Data();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                   var ports = SerialPort.GetPortNames();
                    comboPorts.DataSource = ports;

                    all_DATA.InitializeData();

                    for (int i = 0; i < all_DATA.baudRate.Length; i++)
                    {
                        comboBaud.Items.Add(all_DATA.baudRate[i]);
                    }
                    for (int i = 0; i < all_DATA.dataBits.Length; i++)
                    {
                        comboDataBits.Items.Add(all_DATA.dataBits[i]);
                    }
                    for (int i = 0; i < all_DATA._paritys.Length; i++)
                    {
                        comboParity.Items.Add(all_DATA._paritys[i]);
                    }
                    for (int i = 0; i < all_DATA.stopBits.Length; i++)
                    {
                        comboStopBits.Items.Add(all_DATA.stopBits[i]);
                    }
                    for (int i = 0; i < all_DATA.funcCode.Length; i++)
                    {
                        comboFunc.Items.Add(all_DATA.funcCode[i]);
                    }

                    textReadTimeO.Text = all_DATA.readTimeOut.ToString();
                    textWriteTimeO.Text = all_DATA.writeTimeOut.ToString();
                    textSlave.Text = all_DATA.slave_Address.ToString();
                    textRegAdd.Text = all_DATA.reg_Address.ToString();
                    textQuantity.Text = all_DATA.numberOfPoints_.ToString();
                    textScanRate.Text = all_DATA.scanRate.ToString();

                    comboBaud.SelectedIndex = all_DATA.baudSel_;
                    comboDataBits.SelectedIndex = all_DATA.dataSel_;
                    comboParity.SelectedIndex = all_DATA.pariSel_;
                    comboStopBits.SelectedIndex = all_DATA.stopSel_;
                    comboFunc.SelectedIndex = all_DATA.funcSel_;

                    radioHex.Checked = all_DATA.hex_Sel;
                    radioDec.Checked = all_DATA.dec_Sel;

                    comboPorts.SelectedIndex = all_DATA.portSel_;

                    if (all_DATA.connect_Status == true)
                    {
                        comboPorts.Enabled = false;
                        comboBaud.Enabled = false;
                        comboDataBits.Enabled = false;
                        comboStopBits.Enabled = false;
                        comboParity.Enabled = false;
                    }
                    else
                    {
                        comboPorts.Enabled = true;
                        comboBaud.Enabled = true;
                        comboDataBits.Enabled = true;
                        comboStopBits.Enabled = true;
                        comboParity.Enabled = true;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message,"Form3 Load Func!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void comboBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            all_DATA.baudSel_ = int.Parse(comboBaud.SelectedIndex.ToString());
        }

        private void comboParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            all_DATA.pariSel_ = int.Parse(comboParity.SelectedIndex.ToString());
        }

        private void comboDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            all_DATA.dataSel_ = int.Parse(comboDataBits.SelectedIndex.ToString());
        }

        private void comboStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
                all_DATA.stopSel_ = int.Parse(comboStopBits.SelectedIndex.ToString());
         }

        private void textReadTimeO_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textReadTimeO.Text != "" && int.TryParse(textReadTimeO.Text, out aa))
            {
                if (aa > 0)
                {
                    all_DATA.readTimeOut = int.Parse(textReadTimeO.Text);
                }
            }
        }

        private void textWriteTimeO_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textWriteTimeO.Text != "" && int.TryParse(textWriteTimeO.Text, out aa))
            {
                if (aa > 0)
                {
                    all_DATA.writeTimeOut = int.Parse(textWriteTimeO.Text);
                }
            }
        }

        private void textSlave_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textSlave.Text != "" && int.TryParse(textSlave.Text, out aa))
            {
                if (aa > 0)
                {
                    all_DATA.slave_Address = byte.Parse(textSlave.Text);
                }
            }
        }

        private void textRegAdd_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textRegAdd.Text != "" && int.TryParse(textRegAdd.Text, out aa))
            {
                if (aa >= 0)
                {
                    all_DATA.reg_Address = ushort.Parse(textRegAdd.Text);
                }
            }
        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textQuantity.Text != "" && int.TryParse(textQuantity.Text, out aa))
            {
                if (aa > 0)
                {
                    all_DATA.numberOfPoints_ = ushort.Parse(textQuantity.Text);
                }
            }
        }

        private void textScanRate_TextChanged(object sender, EventArgs e)
        {
            int aa = 0;
            if (textScanRate.Text != "" && int.TryParse(textScanRate.Text, out aa))
            {
                if (aa > 0)
                {
                    all_DATA.scanRate = int.Parse(textScanRate.Text);
                }
            }
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
                 all_DATA.portSel_ = comboPorts.SelectedIndex;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_DATA.disconnect_Write_Data();
        }

        private void radioHex_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHex.Checked)
            {
                all_DATA.hex_Sel = true;
            }
            else
            {
                all_DATA.hex_Sel = false;
            }
        }

        private void radioDec_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDec.Checked)
            {
                all_DATA.dec_Sel = true;
            }
            else
            {
                all_DATA.dec_Sel = false;
            }
        }

        private void comboFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            all_DATA.funcSel_ = int.Parse(comboFunc.SelectedIndex.ToString());
        }
    }
}
