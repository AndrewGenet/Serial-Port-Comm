using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Serial_port_comm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.IO.Ports.SerialPort myPort = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

        //  ^B^X^X^B^X^X*0^M" <- turn all ports off
        //  ^B^X^X^B^X^X*1^M" <- turn all ports on

        string b = ((char)2).ToString();         // ^B
        string x = ((char)24).ToString();        // ^X
        string m = ((char)13).ToString();        // ^M
        string star = ((char)42).ToString();     // *

        string myString = "words";
        int myInt = 7;
        

        int value = 0; // 0 is OFF, 1 is ON
        
        private void talkData()
        {
            // if port is closed, open it
            if (myPort.IsOpen == false)
                    myPort.Open();

            // send the command
            myPort.Write(b+x+x+b+x+x+star+value+m);

            // close the port
            myPort.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = 1;
            talkData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            value = 0;
            talkData();
        }
    }
}
