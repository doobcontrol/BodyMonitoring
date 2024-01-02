using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    class BMSimulateThread
    {
        public Dictionary<string, Dictionary<string, object>> equDic;

        //消息代理
        public event BMThread.OnlineMessageEventHandler myOnlineMessageEventSender;

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
        }

        System.IO.Ports.SerialPort com;
        private void monitor()
        {
            sendMessage("开始连接……"
                    , null
                , null);


            sendMessage("\r\n已连接"
                    , null
                , null);


            sendMessage("\r\n启动监听"
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
                sendMessage("\r\n收到监控线程结束指令：" + e.Message
                    , null
                , null);
            }
            catch (Exception e)
            {
                sendMessage("\r\n监控线程出错-其它错误：" + e.Message
                    , null
                , null);
            }


            sendMessage("\r\n监控线程已成功停止："
                    , null
                , null);

        }


        Random ran = new Random();
        int HeartRate = 65;
        int Breathe = 20;
        int tAM;
        int tAdd;
        int Read(string equid)
        {
            ran = new Random();
            tAM = ran.Next(100, 1000);
            tAdd = ran.Next(0, 5);
            if (tAM >500)
            {
                if (HeartRate + tAdd <= 100)
                {
                    HeartRate += tAdd;
                }
                else
                {
                    HeartRate -= tAdd;
                }
            }
            else
            {
                if (HeartRate - tAdd >= 30)
                {
                    HeartRate -= tAdd;
                }
                else
                {
                    HeartRate += tAdd;
                }
            }

            tAM = ran.Next(100, 1000);
            tAdd = ran.Next(0, 2);
            if (tAM > 500)
            {
                if (Breathe + tAdd <= 30)
                {
                    Breathe += tAdd;
                }
                else
                {
                    Breathe -= tAdd;
                }
            }
            else
            {
                if (Breathe - tAdd >= 5)
                {
                    Breathe -= tAdd;
                }
                else
                {
                    Breathe += tAdd;
                }
            }

            Dictionary<string, int> bmDataDic = new Dictionary<string, int>();
            bmDataDic.Add("HeartRate", HeartRate);
            bmDataDic.Add("Breathe", Breathe);

            //if (int.Parse(DateTime.Now.ToString("ss")) > 30)
            //{
                sendMessage(
                    "\r\n收到协议：呼吸： " + Breathe + "   心率：" + HeartRate
                    , bmDataDic
                    , equid
                    );
            //}

            return 1;
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
