using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestBench
{
    class BMThread
    {        //消息代理
        public delegate void OnlineMessageEventHandler(string msg, Dictionary<string,int> bmDataDic);
        public event OnlineMessageEventHandler myOnlineMessageEventSender;

        //在线处理线程
        private System.Threading.Thread myOnlineThread;
        bool stopFlag = false;

        public void StartMonitor()
        {               
            //启动线程
            stopFlag = false;
            myOnlineThread = new System.Threading.Thread(new System.Threading.ThreadStart(monitor));
            myOnlineThread.Start();
        }
        public void EndtMonitor()
        {
            //结束本线程
            stopFlag = true;
            if (myOnlineThread != null)
            {
                myOnlineThread.Abort();
                //myOnlineThread.Join();
            }
            com.Close();
        }

        System.IO.Ports.SerialPort com;
        private void monitor()
        {
            sendMessage("开始连接……"
                    , null);
            com = new System.IO.Ports.SerialPort("COM4");
            com.BaudRate = 115200;//信号机 4800 车检器 9600;
            com.Parity = System.IO.Ports.Parity.None;
            com.DataBits = 8;
            com.StopBits = System.IO.Ports.StopBits.One;
            com.RtsEnable = false;
            com.DtrEnable = false;
            com.Open();

            if (!com.IsOpen)
            {
                sendMessage("\r\n连接失败"
                    , null);
                return;
            }

            //com.ReadTimeout = 500;
            //com.WriteTimeout = 100;
            sendMessage("\r\n已连接"
                    , null);


            sendMessage("\r\n启动监听"
                    , null);

            try
            {
                while (!stopFlag)
                {

                    Read();

                    System.Threading.Thread.Sleep(500); //1分钟？？
                }
            }
            catch (System.Threading.ThreadAbortException e)
            {
                sendMessage("\r\n收到监控线程结束指令：" + e.Message
                    , null);
            }
            catch (IOException e)
            {
                sendMessage("\r\n监控线程出错-物理连接断开：" + e.Message
                    , null);
            }
            catch (InvalidOperationException e)
            {
                sendMessage("\r\n监控线程出错-端口错误：" + e.Message
                    , null);
            }
            catch (Exception e)
            {
                sendMessage("\r\n监控线程出错-其它错误：" + e.Message
                    , null);
            }


            sendMessage("\r\n监控线程已成功停止："
                    , null);

        }


        int Read()
        {
            byte[] sendData = new byte[11]; //C2C605A4D763
            sendData[0] = 0x55;
            sendData[1] = 0xaa;
            sendData[2] = 0x03;
            sendData[3] = 0xC2;
            sendData[4] = 0xC6;
            sendData[5] = 0x05;
            sendData[6] = 0xA4;
            sendData[7] = 0xD7;
            sendData[8] = 0x63;
            sendData[9] = 0x0d;
            sendData[10] = 0x0a;

            com.Write(sendData, 0, sendData.Length);

            //com.DiscardInBuffer();

            byte[] ReceivedData = new byte[16];
            int retInt = 0;
            int rInt = 0;
            try
            {
                while (rInt < 16)
                {
                    if (com.BytesToRead > 1)
                    {
                        retInt = com.Read(ReceivedData, rInt, 16 - rInt);
                        rInt += retInt;
                    }

                }
            }
            catch (Exception e)
            {
                sendMessage("\r\n读串口错：" + e.Message
                    , null);
                return retInt;
            }

            //
            bool dataCheck = true;

            for (int i = 0; i < 9; i++)
            {
                if (ReceivedData[i] != sendData[i])
                {
                    dataCheck = false;
                    break;
                }
            }
            if (dataCheck && ReceivedData[14] == 0x0d && ReceivedData[15] == 0x0a)
            {
                Decoder(ReceivedData);
            }
            else
            {
                sendMessage("\r\n收到的数据错误："
                    ,null);
            }

            return retInt;
        }
        private void Decoder(byte[] ReceivedData)
        {
            Dictionary<string, int> bmDataDic = new Dictionary<string, int>();
            if (ReceivedData[10] * 256 + ReceivedData[11] != 0 && ReceivedData[9] != 0)
            {
                bmDataDic.Add("HeartRate", ReceivedData[10] * 256 + ReceivedData[11]);
                bmDataDic.Add("Breathe", ReceivedData[9]);
            }
            else
            {
                bmDataDic = null;
            }
            sendMessage(
                "\r\n收到协议：呼吸： " + ReceivedData[9] + "   心率：" + (ReceivedData[10] * 256 + ReceivedData[11])
                , bmDataDic
                );
        }

        private void sendMessage(string messageStr, Dictionary<string, int> bmDataDic)
        {
            this.myOnlineMessageEventSender(messageStr, bmDataDic);
        }
    }
}
