using System;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Mahjong.Control;
using System.Runtime.Serialization.Formatters.Binary;
using Mahjong.Forms;
using Mahjong.Brands;

namespace Mahjong.Control
{
    public class NetPlayer
    {
        internal Socket connection; // Socket for accepting a connection  
        private NetworkStream socketStream; // network data stream 
        public ChatServerForm server; // reference to server 
        private BinaryWriter writer; // facilitates writing to the stream    
        private BinaryReader reader; // facilitates reading from the stream 
        public const string AllPlayers_Head = "/allplaysize:";
        public const string newgameround = "/newgame";
        //General g2;        
        string theReply = "";
        public string number; // player number      
        internal bool threadSuspended = true;
        public const string Brand_Head = "/brand:";
        public const string Check_Head = "/check:";
        public const string BrandplayerArray_Head = "/brandplayerarray:";
        public const string Brandplayer_Head = "/brandplayer:";
        //private string mark; // player mark on the board
        public event newGameHandler getNewGame;
        public event allPlayerHandler getAllPlayer;
        public event brandHandler getBrand;
        public event CheckResultHandler getCheckResult;
        public event BrandplayersHandler getBrandplayers;
        public event BrandplayerHandler getBrandplayer;

        internal NetPlayer(Socket socket, ChatServerForm serverValue, int newNumber)
        {
            connection = socket;
            server = serverValue;
            number = newNumber + ".player";

            // create NetworkStream object for Socket      
            socketStream = new NetworkStream(connection);

            // create Streams for reading/writing bytes
            writer = new BinaryWriter(socketStream);
            reader = new BinaryReader(socketStream);
            getBrand += new brandHandler(server.PC.getClientBrand);
            getCheckResult += new CheckResultHandler(server.PC.CheckUserResult);
            getBrandplayer += new BrandplayerHandler(server.PC.CheckChowResult);
        } // end constructor       
        
        public object getObjectWithByteArray(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;

            return bf1.Deserialize(ms);
        }
        /// <summary>
        /// Server 端的接收
        /// </summary>
        /// <param name="s"></param>
        private void stringcheck(string s)
        {
            byte[] allplayer;
            
            if (s.Contains(AllPlayers_Head))
            {
                allplayer = reader.ReadBytes(int.Parse(s.Remove(0, AllPlayers_Head.Length)));
                //g2 = (General)getObjectWithByteArray(allplayer);
                //MessageBox.Show(server.PC.all.Name[server.PC.all.state], "server");

                //server.PC.all = (AllPlayers)getObjectWithByteArray(allplayer);
                getObjectWithByteArray(allplayer);

                //MessageBox.Show(g2.Name,"Server");                

                server.servermessage(AllPlayers_Head + allplayer.Length.ToString());
                server.serverobject(allplayer);
            }
            else if (s.Contains(Check_Head))
            {
                allplayer = reader.ReadBytes(int.Parse(s.Remove(0, Check_Head.Length)));
                getCheckResult(getObjectWithByteArray(allplayer), null);
            }
            else if (s.Contains(Brand_Head))
            {
                allplayer = reader.ReadBytes(int.Parse(s.Remove(0, Brand_Head.Length)));
                getBrand(getObjectWithByteArray(allplayer), null);

            }
            else if (s.Contains(BrandplayerArray_Head))
            {
                allplayer = reader.ReadBytes(int.Parse(s.Remove(0, BrandplayerArray_Head.Length)));
                getBrandplayers(getObjectWithByteArray(allplayer), null);
            }
            else if (s.Contains(Brandplayer_Head))
            {
                allplayer = reader.ReadBytes(int.Parse(s.Remove(0, Brandplayer_Head.Length)));
                getBrandplayer(getObjectWithByteArray(allplayer), null);
            }
            else if (s.Contains("："))
            {
                theReply = s;
            }
            else if (s.Contains("."))
            {
                string[] sss = s.Split('.');
                server.name[int.Parse(sss[0])] = sss[2];
                //MessageBox.Show(server.name[int.Parse(sss[0])]);
            }

        }

        internal void Run()
        {

            bool done = false;
            server.DisplayMessage("Waiting for connection");
            // accept an incoming connection     

            server.DisplayMessage(number + " Connection " + " received.");

            // inform client that connection was successfull
            writer.Write(number);
            writer.Write("SERVER>>> Connection successful");

            //server.DisableInput(false); // enable inputTextBox

            if (number == "1.player")
            {
                // wait for notification from server that another
                // player has connected
                lock (this)
                {
                    while (threadSuspended)
                        Monitor.Wait(this);
                } // end lock
                
                writer.Write("2號玩家已連線");
            } // end if
            else if (number == "2.player")
            {
                // wait for notification from server that another
                // player has connected
                lock (this)
                {
                    while (threadSuspended)
                        Monitor.Wait(this);
                } // end lock

                writer.Write("3號玩家已連線");
            } // end if
            else if (number == "3.player")
            {
                // wait for notification from server that another
                // player has connected
                lock (this)
                {
                    while (threadSuspended)
                        Monitor.Wait(this);
                } // end lock
                writer.Write("4號玩家已連線");
            } // end if


            // loop until server signals termination
            do
            {
                // Step 3: processing phase
                try
                {
                    while (connection.Available == 0)
                    {
                        Thread.Sleep(100);
                        if (server.disconnected)
                            return;
                    }
                    // read message from server        
                    stringcheck(reader.ReadString());
                    // display the message
                    server.DisplayMessage(theReply);
                    server.servermessage(theReply);

                } // end try
                catch (IOException)
                {
                    // handle exception if error reading data
                    break;
                } // end catch
                if (server.GameOver())
                    done = true;

            } while (connection.Connected || !done);

            server.DisplayMessage("\r\nUser terminated connection\r\n");

            // Step 5: close connection  
            writer.Close();
            reader.Close();
            socketStream.Close();
            connection.Close();

            server.DisableInput(true); // disable InputTextBox            
        }
    }
}
