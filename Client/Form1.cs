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
        Socket SckSPort; // 先行宣告Socket
        int SPort = 6101;
        int RDataLen = 99999;  // 此文Server端和Client端都是用固定長度5在傳送資料~ 可以針對自己的需要改長度 

        // 連線
        private void ConnectServer(object sender, EventArgs e)
        {
            try
            {
                SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SckSPort.Connect(new IPEndPoint(IPAddress.Parse(ipaddr.Text), SPort));
                // RmIp和SPort分別為string和int型態, 前者為Server端的IP, 後者為Server端的Port
                // 同 Server 端一樣要另外開一個執行緒用來等待接收來自 Server 端傳來的資料, 與Server概念同
                Thread SckSReceiveTd = new Thread(SckSReceiveProc);
                SckSReceiveTd.Start();

                SckSPort.Send(Encoding.ASCII.GetBytes("newplayer:" + player.Text));
                button1.Enabled = false;
            }
            catch { }
        }

        // SckSReceiveProc 是接受來自 Server 端的資料其函式內容幾乎同 Server 端的 SckSAcceptProc 接收資料的Code~  ,  只差在 Client 只有一個Socket. 
        private void SckSReceiveProc() {

            try {
                long IntAcceptData;
                byte[] clientData = new byte[RDataLen];
                while (true){
                    // 程式會被 hand 在此, 等待接收來自 Server 端傳來的資料
                    IntAcceptData = SckSPort.Receive(clientData);
                    // 往下就自己寫接收到來自Server端的資料後要做什麼事唄~^^”
                    this.Invoke((MethodInvoker)delegate ()
                    {
                                                
                        switch (Encoding.Default.GetString(clientData).Substring(0, 9)) {
                        case "ConnectFa":
                            MessageBox.Show("撞名惹！");
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
        // 當然 Client 端也可以傳送資料給Server端~ 和 Server 端的SckSSend一樣, 只差在Client端只有一個Socket

  
       

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


