using com.xiyuansoft.bormodel;
using com.xiyuansoft.DataBaseUpdate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.bormodel
{
    public class SysBizPars : IInitData
    {
        #region IInitData Members

        void IInitData.getInitData(BaseModel bmodel)
        {
            if (bmodel is BizPars)
            {
                BizPars bpmodel = bmodel as BizPars;
                bpmodel.addInitItem(batabaseV, "1.0");         //数据库结构升级时更改些值

                bpmodel.addInitItem(comPort, "");
                bpmodel.addInitItem(comBaud, "115200");
                bpmodel.addInitItem(comData, "8");
                bpmodel.addInitItem(comStop, StopBitsMapString[System.IO.Ports.StopBits.One]);
                bpmodel.addInitItem(comParity, ParityMapString[System.IO.Ports.Parity.None]);
                bpmodel.addInitItem(HeartRateMax, "100");
                bpmodel.addInitItem(HeartRateMin, "40");
                bpmodel.addInitItem(BreatheMax, "25");
                bpmodel.addInitItem(BreatheMin, "8");
                bpmodel.addInitItem(WarningOpen, "1");
                bpmodel.addInitItem(ModeHartrate, "85");
                bpmodel.addInitItem(ModeBreath, "21");
            }
        }

        #endregion


        static public String batabaseV = UpdateNode.batabaseV;

        static public String comPort = "comPort";
        static public String comBaud = "comBaud";
        static public String comData = "ComData";
        static public String comStop = "ComStop";
        static public String comParity = "ComParity";
        static public String HeartRateMax = "HeartRateMax";
        static public String HeartRateMin = "HeartRateMin";
        static public String BreatheMax = "BreatheMax";
        static public String BreatheMin = "BreatheMin";
        static public String WarningOpen = "WarningOpen";
        static public String ModeHartrate = "ModeHartrate";
        static public String ModeBreath = "ModeBreath";

        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static SysBizPars()
        {
            StopBitsMapString.Add(System.IO.Ports.StopBits.None, "0");
            StopBitsMapString.Add(System.IO.Ports.StopBits.One, "1");
            StopBitsMapString.Add(System.IO.Ports.StopBits.OnePointFive, "1.5");
            StopBitsMapString.Add(System.IO.Ports.StopBits.Two, "2");
            StringMapStopBits.Add("0", System.IO.Ports.StopBits.None);
            StringMapStopBits.Add("1", System.IO.Ports.StopBits.One);
            StringMapStopBits.Add("1.5", System.IO.Ports.StopBits.OnePointFive);
            StringMapStopBits.Add("2", System.IO.Ports.StopBits.Two);


            ParityMapString.Add(System.IO.Ports.Parity.None, "None");
            ParityMapString.Add(System.IO.Ports.Parity.Odd, "Odd");
            ParityMapString.Add(System.IO.Ports.Parity.Even, "Even");
            ParityMapString.Add(System.IO.Ports.Parity.Mark, "Mark");
            ParityMapString.Add(System.IO.Ports.Parity.Space, "Space");
            StringMapParity.Add("None", System.IO.Ports.Parity.None);
            StringMapParity.Add("Odd", System.IO.Ports.Parity.Odd);
            StringMapParity.Add("Even", System.IO.Ports.Parity.Even);
            StringMapParity.Add("Mark", System.IO.Ports.Parity.Mark);
            StringMapParity.Add("Space", System.IO.Ports.Parity.Space);
        }
        static public Dictionary<System.IO.Ports.StopBits, string> StopBitsMapString = new Dictionary<System.IO.Ports.StopBits, string>();
        static public Dictionary<String, System.IO.Ports.StopBits> StringMapStopBits = new Dictionary<string, System.IO.Ports.StopBits>();
        static public Dictionary<System.IO.Ports.Parity, string> ParityMapString = new Dictionary<System.IO.Ports.Parity, string>();
        static public Dictionary<string, System.IO.Ports.Parity> StringMapParity = new Dictionary<string, System.IO.Ports.Parity>();
    }

}
