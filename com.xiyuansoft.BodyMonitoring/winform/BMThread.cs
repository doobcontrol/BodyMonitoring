using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    class BMThread
    {
        public Dictionary<string, Dictionary<string, object>> equDic;
        
        //消息代理
        public delegate void OnlineMessageEventHandler(string msg, Dictionary<string, int> bmDataDic, string equid);
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
            if (com != null)
            {
                com.Close();
            }
        }

        System.IO.Ports.SerialPort com;
        private void monitor()
        {
            sendMessage("开始连接……"
                    , null
                , null);
            //com = new System.IO.Ports.SerialPort("COM4");
            //com.BaudRate = 115200;//信号机 4800 车检器 9600;
            //com.Parity = System.IO.Ports.Parity.None;
            //com.DataBits = 8;
            //com.StopBits = System.IO.Ports.StopBits.One;

            com = new System.IO.Ports.SerialPort(BizPars.getnSingInstance().getPar(SysBizPars.comPort));
            com.BaudRate = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.comBaud));//信号机 4800 车检器 9600;
            com.Parity = SysBizPars.StringMapParity[BizPars.getnSingInstance().getPar(SysBizPars.comParity)];
            com.DataBits = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.comData));
            com.StopBits = SysBizPars.StringMapStopBits[BizPars.getnSingInstance().getPar(SysBizPars.comStop)];

            try
            {
                com.Open();
            }
            catch (Exception e)
            {
                sendMessage("串口打开失败："+e.Message
                        , null
                    , null);
                return;
            }

            if (!com.IsOpen)
            {
                sendMessage("连接失败"
                    , null
                , null);
                return;
            }

            com.ReadTimeout = 500;
            //com.WriteTimeout = 100;
            sendMessage("已连接"
                    , null
                , null);


            sendMessage("启动监听"
                    , null
                , null);

            try
            {
                while (!stopFlag)
                {

                    foreach (string equid in equDic.Keys)
                    {
                        if ((bool)equDic[equid]["work"])
                        {
                            Read(equid);
                        }
                    }

                    System.Threading.Thread.Sleep(1000); //1分钟？？
                }
            }
            catch (System.Threading.ThreadAbortException e)
            {
                sendMessage("收到监控线程结束指令：" + e.Message
                    , null
                , null);
            }
            catch (IOException e)
            {
                sendMessage("监控线程出错-物理连接断开：" + e.Message
                    , null
                , null);
            }
            catch (InvalidOperationException e)
            {
                sendMessage("监控线程出错-端口错误：" + e.Message
                    , null
                , null);
            }
            catch (Exception e)
            {
                sendMessage("监控线程出错-其它错误：" + e.Message
                    , null
                , null);
            }


            sendMessage("监控线程已成功停止："
                    , null
                , null);

        }

        int Read(string equid)
        {
            byte[] sendData = new byte[11]; //C2C605A4D763
            sendData[0] = 0x55;
            sendData[1] = 0xaa;
            sendData[2] = 0x03;
            sendData[3] = byte.Parse(equid.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);// 0xC2;
            sendData[4] = byte.Parse(equid.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);//  0xC6;
            sendData[5] = byte.Parse(equid.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);//  0x05;
            sendData[6] = byte.Parse(equid.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);//  0xA4;
            sendData[7] = byte.Parse(equid.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);//  0xD7;
            sendData[8] = byte.Parse(equid.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);//  0x63;
            sendData[9] = 0x0d;
            sendData[10] = 0x0a;

            //新设备自动发结果来，不需请求？？ sendData保留用作收到数据的验证
            //com.DiscardInBuffer();
            //com.Write(sendData, 0, sendData.Length);

            byte[] ReceivedData = new byte[16];
            int retInt = 0;
            try
            {
                        retInt = com.Read(ReceivedData, 0, 16);
                        com.DiscardInBuffer();
            }
            catch (Exception e)
            {
                sendMessage("读串口错：" + e.Message
                    , null
                , equid);
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
                Decoder(ReceivedData, equid);
            }
            else
            {
                sendMessage("收到的数据错误："
                    , null
                , equid);
            }

            return retInt;
        }
        private void Decoder(byte[] ReceivedData, string equid)
        {
            Dictionary<string, int> bmDataDic = new Dictionary<string, int>();
            //if (ReceivedData[10] * 256 + ReceivedData[11] != 0 && ReceivedData[9] != 0)
            //{
                bmDataDic.Add("HeartRate", ReceivedData[10] * 256 + ReceivedData[11]);
                bmDataDic.Add("Breathe", ReceivedData[9]);
            //}
            //else
            //{
            //    bmDataDic = null; //过滤0值
            //}
            sendMessage(
                "收到协议：呼吸： " + ReceivedData[9] + "   心率：" + (ReceivedData[10] * 256 + ReceivedData[11])
                , bmDataDic
                , equid
                );
        }

        private void sendMessage(string messageStr, Dictionary<string, int> bmDataDic, string equid)
        {

            if (this.myOnlineMessageEventSender != null)
            {
                this.myOnlineMessageEventSender(messageStr, bmDataDic, equid);
            }
        }
    
    }
}
