using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication2{
    public partial class Form1 : Form {public Form1() {InitializeComponent();}
        bool turnme = false;
        int opponent = 0;
        Socket SckSPort; 
        int SPort = 6101;
        int RDataLen = 99999; 

        private void ConnectServer(object sender, EventArgs e)
        {
            try
            {
                SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SckSPort.Connect(new IPEndPoint(IPAddress.Parse(ipaddr.Text), SPort));
                Thread SckSReceiveTd = new Thread(SckSReceiveProc);
                SckSReceiveTd.Start();

                SckSPort.Send(Encoding.ASCII.GetBytes("newplayer:" + player.Text));
                button1.Enabled = false;
            }
            catch { }
        }
        private void SckSReceiveProc() {

            try {
                long IntAcceptData;
                byte[] clientData = new byte[RDataLen];
                while (true){
                    IntAcceptData = SckSPort.Receive(clientData);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                                                
                        switch (Encoding.Default.GetString(clientData).Substring(0, 9)) {
                        case "ConnectFa":
                            MessageBox.Show("撞名");
                            button1.Enabled = true;
                            break;
                        case "newplayer":
                                member.Items.Add(Encoding.Default.GetString(clientData).Split(':')[1]);
                                 break;
                            case "offplayer":
                                member.Items.RemoveAt(member.FindString(Encoding.Default.GetString(clientData).Split(':')[1]));
                                break;
                            case "startgame":
                                Start.Enabled = false;
                                opponent = Int32.Parse(Encoding.Default.GetString(clientData).Split(':')[1]);
                                break;
                            case "answerggg":
                                switch(Encoding.Default.GetString(clientData).Substring(10, 1)) {
                                    case "A": A.BackColor = Color.White;break;
                                    case "B": B.BackColor = Color.White; break;
                                    case "C": C.BackColor = Color.White; break;
                                    case "D": D.BackColor = Color.White; break;
                                    case "E": E.BackColor = Color.White; break;
                                    case "F": F.BackColor = Color.White; break;
                                    case "G": G.BackColor = Color.White; break;
                                    case "H": H.BackColor = Color.White; break;
                                    case "I": I.BackColor = Color.White; break;
                                }

                                turnme = true;
                                if (winorlose())
                                {
                                    this.Hide();
                                    MessageBox.Show("你輸了");
                                    Environment.Exit(0);
                                }
                                break;
                        }





                    });
                }
            }catch{            }
        }

  
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Start_Click(object sender, EventArgs e){ if (member.SelectedItem != null) { SckSPort.Send(Encoding.ASCII.GetBytes("startgame:" + member.SelectedItem)); turnme = true; } }
        private void answer_Click(object sender, EventArgs e) {
            if ((!Start.Enabled) && turnme && ((Button)sender).BackColor == SystemColors.Control) {
                SckSPort.Send(Encoding.ASCII.GetBytes("answer:" + ((Button)sender).Name.ToString() + ":" + opponent.ToString()));
                ((Button)sender).BackColor = Color.Black;
                  turnme = false;
                if (winorlose())
                {
                    this.Hide();
                    MessageBox.Show("你贏了");
                    Environment.Exit(0);
                }
            } }
        private bool winorlose() {
            return ((A.BackColor!=SystemColors.Control && A.BackColor == B.BackColor && B.BackColor == C.BackColor) || 
                (G.BackColor != SystemColors.Control && G.BackColor == H.BackColor && H.BackColor == I.BackColor) || 
                (A.BackColor != SystemColors.Control && A.BackColor == D.BackColor && D.BackColor == G.BackColor) ||
                (A.BackColor != SystemColors.Control && A.BackColor == E.BackColor && E.BackColor == I.BackColor) ||
                (B.BackColor != SystemColors.Control && B.BackColor == E.BackColor && E.BackColor == H.BackColor) ||
                (C.BackColor != SystemColors.Control && C.BackColor == E.BackColor && E.BackColor == G.BackColor) ||
                (C.BackColor != SystemColors.Control && C.BackColor == F.BackColor && F.BackColor == I.BackColor) ||
                (D.BackColor != SystemColors.Control && D.BackColor == E.BackColor && E.BackColor == F.BackColor));
                  }
        }


        

        }


