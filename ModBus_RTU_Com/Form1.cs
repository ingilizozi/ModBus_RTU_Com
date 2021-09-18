using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModBus_RTU_Com
{
    public partial class Form1 : Form
    {
        int pen = 1;
        all_Data all_DATA = new all_Data();
 //       Form3 tool_Form = new Form3();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (all_DATA.ComPortState())
            {
                optionsToolStripMenuItem.Enabled = true;
                all_DATA.InitializeData();
                disconnectStripMenuItem1.Enabled = false;
                connectStripMenuItem.Enabled = true;
                sendComStripMenuItem.Enabled = false;
                StatusConnect.ForeColor = Color.Red;
                StatusConnect.Text = "Disconnect";
                StatusPort.ForeColor = Color.Green;
                StatusPort.Text = "Port : " + all_DATA.port_[all_DATA.portSel_];
                all_DATA.connect_Status = false;
                timer1.Enabled = true;
                all_DATA.write_Config_Data();
            }
            else
            {
                optionsToolStripMenuItem.Enabled = false;
                disconnectStripMenuItem1.Enabled = false;
                connectStripMenuItem.Enabled = false;
                sendComStripMenuItem.Enabled = false;
                disconnectStripMenuItem1.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                newToolStripButton.Enabled = false;
                
                StatusConnect.ForeColor = Color.Red;
                StatusConnect.Text = "Disconnect";
                StatusPort.ForeColor = Color.Green;
                StatusPort.Text = "Port : COM Port Yok!";
                all_DATA.connect_Status = false;
                timer1.Enabled = false;
                MessageBox.Show(this, "Uygun Port bulunamadı !", "Açık Port Yok!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var regWin = new Form2();
            regWin.MdiParent=this;
            regWin.Show();
            regWin.Text = "Yeni Bağlantı Penceresi " + pen;
            pen++;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 tool_Form = new Form3();
            tool_Form.ShowDialog(this);
        }

        private void Tool_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void connectStripMenuItem_Click(object sender, EventArgs e)
        {
            if (all_DATA.serialPort != null)
            {
                all_DATA.InitializeData();
                connectStripMenuItem.Enabled = false;
                StatusConnect.ForeColor = Color.Blue;
                StatusConnect.Text = "Connect";
                StatusPort.Text = all_DATA.port_[all_DATA.portSel_];
                disconnectStripMenuItem1.Enabled = true;
                all_DATA.connect_Status = true;
                all_DATA.write_Config_Data();
            }
            else
            {
                connectStripMenuItem.Enabled = true;
            }
        }

        private void disconnectStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (all_DATA.serialPort != null)
            {
                all_DATA.serialPort.Close();
                StatusConnect.ForeColor = Color.Red;
                StatusConnect.Text = "Disconnect";
                disconnectStripMenuItem1.Enabled = false;
                connectStripMenuItem.Enabled = true;
                all_DATA.connect_Status = false;
                all_DATA.disconnect_Write_Data();
                StatusPort.Text = all_DATA.port_[all_DATA.portSel_];
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            all_DATA.disconnect_Write_Data();
            all_DATA.serialPort.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (all_DATA.connect_Status == true)
            {
                sendComStripMenuItem.Enabled = true;
                newToolStripMenuItem.Enabled = true;
                newToolStripButton.Enabled = true;
            }
            else
            {
                sendComStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                newToolStripButton.Enabled = false;
            }
            if (Application.OpenForms.Count > 1)
            {
                disconnectStripMenuItem1.Enabled = false;
            }
            else
            {
                disconnectStripMenuItem1.Enabled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var regWin = new Form2();
            regWin.MdiParent = this;
            regWin.Show();
            regWin.Text = "Yeni Bağlantı Penceresi " + pen;
            pen++;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all_DATA.serialPort.Close();
            Application.Exit();
        }

        private void cascadeStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void sendComStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 send_Form = new Form4();
            send_Form.ShowDialog();
        }
    }
}
