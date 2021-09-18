using System;
using System.IO;
using System.Text;
using System.IO.Ports;
using Modbus.Device;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace ModBus_RTU_Com
{
    public class all_Data
    {
        public bool connect_Status;
        private String fileName;
        public String data_Received;

        public readonly int[] baudRate = { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200 };
        public readonly int[] dataBits = { 1, 2, 3, 4, 5, 6, 7, 8 };
        public readonly int[] _paritys = { 0, 1, 2 };
        public readonly int[] stopBits = { 0, 1, 2 };
        public int[] funcCode = { 1, 2, 3, 4, 5, 6, 15, 16 };

        public String[] port_;

        public byte slave_Address;
        public ushort reg_Address;
        public ushort numberOfPoints_;
        public int scanRate;

        public int readTimeOut;
        public int writeTimeOut;

        public int funcSel_;

        public int baudSel_;
        public int dataSel_;
        public int pariSel_;
        public int stopSel_;
        public int portSel_;

        public bool hex_Sel;
        public bool dec_Sel;

        public string[] textResult_Dev;
        public string Device_Wri;
        public String[] textResult;
        public ushort[] textResultUshort;

        public SerialPort serialPort = new SerialPort();
        public all_Data()
        {
            this.fileName = "config.osm";

            this.data_Received = "";

            this.baudSel_ = 5;
            this.dataSel_ = 7;
            this.pariSel_ = 0;
            this.stopSel_ = 1;
            this.slave_Address = 1;
            this.reg_Address = 1;
            this.readTimeOut = 300;
            this.writeTimeOut = 300;
            this.numberOfPoints_ = 0;
            this.scanRate = 2000;
            this.portSel_ = 0;
            this.connect_Status = false;
            this.hex_Sel = false;
            this.dec_Sel = false;

            this.funcSel_ = 1;

        }

        public bool ComPortState()
        {
            if (SerialPort.GetPortNames().Count() > 0)
            {
                return true;
            }
            else
            {
                write_Config_Data();
                return false;


            }
        }
         public void write_Config_Data()
        {
            try
            {
                File.SetAttributes(fileName,FileAttributes.Normal);
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] baudSel = new UTF8Encoding(true).GetBytes(baudSel_.ToString() + "\n");
                    fs.Write(baudSel, 0, baudSel.Length);
                    Byte[] dataSel = new UTF8Encoding(true).GetBytes(dataSel_.ToString() + "\n");
                    fs.Write(dataSel, 0, dataSel.Length);
                    Byte[] _paritySel = new UTF8Encoding(true).GetBytes(pariSel_.ToString() + "\n");
                    fs.Write(_paritySel, 0, _paritySel.Length);
                    Byte[] stopSel = new UTF8Encoding(true).GetBytes(stopSel_.ToString() + "\n");
                    fs.Write(stopSel, 0, stopSel.Length);
                    Byte[] slAveSel = new UTF8Encoding(true).GetBytes(slave_Address.ToString() + "\n");
                    fs.Write(slAveSel, 0, slAveSel.Length);
                    Byte[] reg_Sel = new UTF8Encoding(true).GetBytes(reg_Address.ToString() + "\n");
                    fs.Write(reg_Sel, 0, reg_Sel.Length);
                    Byte[] read_Sel = new UTF8Encoding(true).GetBytes(readTimeOut.ToString() + "\n");
                    fs.Write(read_Sel, 0, read_Sel.Length);
                    Byte[] write_Sel = new UTF8Encoding(true).GetBytes(writeTimeOut.ToString() + "\n");
                    fs.Write(write_Sel, 0, write_Sel.Length);
                    Byte[] numOf = new UTF8Encoding(true).GetBytes(numberOfPoints_.ToString() + "\n");
                    fs.Write(numOf, 0, numOf.Length);
                    Byte[] scanRa = new UTF8Encoding(true).GetBytes(scanRate.ToString() + "\n");
                    fs.Write(scanRa, 0, scanRa.Length);
                    Byte[] port_Sel = new UTF8Encoding(true).GetBytes(portSel_.ToString() + "\n");
                    fs.Write(port_Sel, 0, port_Sel.Length);
                    Byte[] con_Sta = new UTF8Encoding(true).GetBytes(connect_Status.ToString() + "\n");
                    fs.Write(con_Sta, 0, con_Sta.Length);

                    Byte[] hex_ = new UTF8Encoding(true).GetBytes(hex_Sel.ToString() + "\n");
                    fs.Write(hex_, 0, hex_.Length);
                    Byte[] dec_ = new UTF8Encoding(true).GetBytes(dec_Sel.ToString() + "\n");
                    fs.Write(dec_, 0, dec_.Length);

                    Byte[] fun_C = new UTF8Encoding(true).GetBytes(funcSel_.ToString() + "\n");
                    fs.Write(fun_C, 0, fun_C.Length);

                    fs.Close();
                }
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "write_Config_Data() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Bağlantı durumunu yerel dosyaya kaydeden fonksiyon.
        /// </summary>
        public void disconnect_Write_Data()
        {
            try
            {
                int line_to_edit = 12; // Warning: 1-based indexing!

                // Read the appropriate line from the file.
                string lineToWrite = null;
                lineToWrite = connect_Status.ToString();
                if (lineToWrite == null)
                    throw new InvalidDataException("Line does not exist in " + fileName);

                // Read the old file.
                File.SetAttributes(fileName, FileAttributes.Normal);
                string[] lines = File.ReadAllLines(fileName);

                // Write the new file over the old file.
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                    {
                        if (currentLine == line_to_edit)
                        {
                            writer.WriteLine(lineToWrite);
                        }
                        else
                        {
                            writer.WriteLine(lines[currentLine - 1]);
                        }
                    }
                }
                /*     Byte[] con_Sta = new UTF8Encoding(true).GetBytes(connect_Status.ToString() + "\n");
                         fs.(con_Sta, 0, con_Sta.Length);

                         fs.Close();*/

            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "disconnect_Write_Data() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void readHoldingRegistersDevice(bool hx, ushort reg_Add_Dev, ushort nOfP)
        {
            textResult_Dev = new string[20];
            if (serialPort != null)
            {
                try
                {
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                    ushort[] result = master.ReadHoldingRegisters(slave_Address, reg_Add_Dev, nOfP);
                    if (hx)
                    {
                        for (int i = 0; i < nOfP; i++)
                        {
                            textResult_Dev[i] = String.Format("{0:X}", result[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < nOfP; i++)
                        {
                            textResult_Dev[i] += String.Format("{0:D}", result[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "readHoldingRegistersDevice() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public string[] ReadHoldingRegistersDevRes(ushort reg_Add_Dev)
        {
            string[] res = new string[1];
            textResult_Dev = new string[20];
            if (serialPort != null)
            {
                try
                {
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                    ushort[] result = master.ReadHoldingRegisters(slave_Address, reg_Add_Dev, 1);

                //            textResult_Dev[0] = String.Format("{0:X}", result);

                    res[0] = result[0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "readHoldingRegistersDevice() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return res;
        }
        public void readHoldingRegisters()
        {
            textResult = new String[numberOfPoints_];
            if (serialPort != null)
            {

                try {
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                    ushort[] result = master.ReadHoldingRegisters(slave_Address, reg_Address, numberOfPoints_);
                    if (hex_Sel)
                    {

                        for (int i = 0; i < result.Length; i++)
                        {
                            textResult[i] += String.Format("{0:X02}", result[i]);
                        }
                    }
                    else if (dec_Sel)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            textResult[i] += String.Format("{0:D2}", result[i]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("OLMADI !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "readHoldingRegisters() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public void readinputRegisters()
        {
            try
            {
                textResult = new String[numberOfPoints_];
                if (serialPort != null)
                {
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(serialPort);
                    ushort[] result = master.ReadInputRegisters(slave_Address, reg_Address, numberOfPoints_);
                    if (hex_Sel)
                    {

                        for (int i = 0; i < result.Length; i++)
                        {
                            textResult[i] += String.Format("{0:X02}", result[i]);
                        }
                    }
                    else if (dec_Sel)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            textResult[i] += String.Format("{0:D}", result[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("OLMADI !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "readinputRegisters() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void writeHoldingRegisters()
        {
            try
            {
                IModbusMaster masterRTU = ModbusSerialMaster.CreateRtu(serialPort);
                ushort[] registers = new ushort[numberOfPoints_];
                for (int i = 0; i < numberOfPoints_; i++)
                {
                    registers[i] = ushort.Parse(textResult[i]);
                }
                masterRTU.WriteMultipleRegisters(slave_Address, reg_Address, registers);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "writeHoldingRegisters() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void writeHoldingRegistersDevice(string[] wR, string RegAdd, bool hx_)
        {
            try
            {
                IModbusMaster masterRTU = ModbusSerialMaster.CreateRtu(serialPort);
                ushort[] registers = new ushort[1];
                ushort[] wRUshort = new ushort[1];
                if (hx_)
                {
                    wRUshort[0] = ushort.Parse(wR[0], System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    wRUshort[0] = ushort.Parse(wR[0]);
                }

                for (int i = 0; i < 1; i++)
                {
                    registers[i] = wRUshort[i];
                }
                    masterRTU.WriteMultipleRegisters(slave_Address, ushort.Parse(RegAdd), registers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "writeHoldingRegistersDevice() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void InitializeData()
        {
            try
            {
                    var ports = SerialPort.GetPortNames();
                    port_ = ports;

                    StreamReader sr = File.OpenText(fileName);
                    File.SetAttributes(fileName, FileAttributes.Normal);

                    int ii = 0;
                    String s = "";
                    String[] dR = new String[15];
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s != null)
                        {
                            dR[ii] = s;
                            ii++;
                        }
                    }

                    baudSel_ = int.Parse(dR[0]);
                    dataSel_ = int.Parse(dR[1]);
                    pariSel_ = int.Parse(dR[2]);
                    stopSel_ = int.Parse(dR[3]);

                    slave_Address = byte.Parse(dR[4]);
                    reg_Address = ushort.Parse(dR[5]);
                    readTimeOut = int.Parse(dR[6]);
                    writeTimeOut = int.Parse(dR[7]);
                    numberOfPoints_ = ushort.Parse(dR[8]);
                    scanRate = int.Parse(dR[9]);
                    portSel_ = int.Parse(dR[10]);
                    connect_Status = bool.Parse(dR[11]);

                    hex_Sel = bool.Parse(dR[12]);
                    dec_Sel = bool.Parse(dR[13]);

                    funcSel_ = int.Parse(dR[14]);

                    sr.Close();
                }
                catch (Exception ie)
            {
                MessageBox.Show(ie.Message, "initializeData() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void connect_RTU()
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.PortName = port_[portSel_];
                    serialPort.ReadTimeout = readTimeOut;
                    serialPort.WriteTimeout = writeTimeOut;
                    serialPort.BaudRate = baudRate[baudSel_];
                    serialPort.DataBits = dataBits[dataSel_];
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits[stopSel_].ToString());
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _paritys[pariSel_].ToString());
                    serialPort.Open();
                }
            }
            catch(Exception ef)
            {
                MessageBox.Show(ef.Message, "Connect_RTU() Func!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
    { '0', "0000" },
    { '1', "0001" },
    { '2', "0010" },
    { '3', "0011" },
    { '4', "0100" },
    { '5', "0101" },
    { '6', "0110" },
    { '7', "0111" },
    { '8', "1000" },
    { '9', "1001" },
    { 'a', "1010" },
    { 'b', "1011" },
    { 'c', "1100" },
    { 'd', "1101" },
    { 'e', "1110" },
    { 'f', "1111" }
};

        public string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                // This will crash for non-hex characters. You might want to handle that differently.
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }
    }
}
