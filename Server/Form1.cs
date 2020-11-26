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
namespace WindowsFormsApplication1{  public partial class Form1 : Form { public Form1() { InitializeComponent();}
        Socket[] SckSs; 
        int SckCIndex;
        int SPort = 6101;
        int RDataLen = 99999;

        string[] playerlist=new string[1000];

        private void Listen()  {
                                  Array.Resize(ref SckSs, 1);
                        SckSs[0] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        SckSs[0].Bind(new IPEndPoint(IPAddress.Any, SPort));
                       SckSs[0].Listen(10); 
                        SckSWaitAccept();   
                    }
        
        private void SckSWaitAccept()  {
                                    bool FlagFinded = false;
                        for (int i = 1; i < SckSs.Length; i++)                            {
                                                if (SckSs[i] != null)                {
                    if (SckSs[i].Connected == false)                    {
                     SckCIndex = i;
                       FlagFinded = true;
                      break;
                    }
                }
            }
             if (FlagFinded == false){
                SckCIndex = SckSs.Length;
                Array.Resize(ref SckSs, SckCIndex + 1);
            }
            Thread SckSAcceptTd = new Thread(SckSAcceptProc);
            SckSAcceptTd.Start();  
        }
        private void SckSAcceptProc() {
            int Scki=0;
            string playername="";
            try {
                SckSs[SckCIndex] = SckSs[0].Accept();  
                Scki = SckCIndex;
                SckSWaitAccept();
                long IntAcceptData;
                byte[] clientData = new byte[RDataLen];
                while (true){
                    
                    IntAcceptData = SckSs[Scki].Receive(clientData);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        
                        switch (Encoding.Default.GetString(clientData).Split(':')[0])
                        {
                            case "newplayer":
                                if (member.FindString(Encoding.Default.GetString(clientData).Split(':')[1]) == ListBox.NoMatches)
                                {   
                                    playername = Encoding.Default.GetString(clientData).Split(':')[1];
                                    
                                    playerlist[Scki] = playername;
                                    for (int i = 0; i < member.Items.Count; i++) SckSSend(Scki, "newplayer:"+member.Items[i].ToString());
                                                           

                                    member.Items.Add(playername);

                                    for (int i = 1; i < SckSs.Length; i++)if(i!=Scki)SckSSend(i, "newplayer:"+playername);
                                    }
                                else SckSSend(Scki, "ConnectFailed");
                                break;
                            case "startgame":
                                for (int i = 1; i < SckSs.Length; i++) if (playerlist[i] == Encoding.Default.GetString(clientData).Split(':')[1])
                                    { 
                                        SckSSend(i, "startgame:" + Scki.ToString());
                                        SckSSend(Scki, "startgame:" + i.ToString());
                                    }
                                break;
                            case "answer":
                    
                                SckSSend(Int32.Parse(Encoding.Default.GetString(clientData).Substring(9,1)), "answerggg:" + Encoding.Default.GetString(clientData).Substring(7, 1));
                                break;
                        }







                    });    
                }
            }
            catch{
                this.Invoke((MethodInvoker)delegate ()
                {
                    member.Items.RemoveAt(member.FindString(playername));
                    for (int i = 1; i < SckSs.Length; i++) if (i != Scki) SckSSend(i, "offplayer:" + playername); else playerlist[i] = "";


                });
            }
        }
        private void SckSSend(int SocketNumber,string replymessage){
                    try{
                       
                        SckSs[SocketNumber].Send(Encoding.ASCII.GetBytes(replymessage));
                    }catch {
              }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
