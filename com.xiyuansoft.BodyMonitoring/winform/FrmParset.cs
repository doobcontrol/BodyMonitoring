using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmParset : Form
    {
        public FrmParset()
        {
            InitializeComponent();

            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "系统参数设置";

            UIHelper.SetDialogForm(this);

            GetComList();
            GetComPar();
        }

        private void FrmParset_Load(object sender, EventArgs e)
        {
            cmbComPort.Text = BizPars.getnSingInstance().getPar(SysBizPars.comPort);
            cmbComBaud.Text = BizPars.getnSingInstance().getPar(SysBizPars.comBaud);
            cmbComData.Text = BizPars.getnSingInstance().getPar(SysBizPars.comData);
            cmbComStop.Text = BizPars.getnSingInstance().getPar(SysBizPars.comStop);
            cmbComParity.Text = BizPars.getnSingInstance().getPar(SysBizPars.comParity);

            nudHeartRateMax.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMax));
            nudHeartRateMin.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMin));
            nudBreatheMax.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.BreatheMax));
            nudBreatheMin.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.BreatheMin));
            nudModeHartrate.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.ModeHartrate));
            nudModeBreath.Value = int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.ModeBreath));

            ckbWarningOpen.Checked =
                (BizPars.getnSingInstance().getPar(SysBizPars.WarningOpen)=="1")?true:false;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbComPort.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.comPort)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.comPort, cmbComPort.Text.Trim());
            }
            if (cmbComBaud.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.comBaud)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.comBaud, cmbComBaud.Text.Trim());
            }
            if (cmbComData.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.comData)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.comData, cmbComData.Text.Trim());
            }
            if (cmbComStop.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.comStop)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.comStop, cmbComStop.Text.Trim());
            }
            if (cmbComParity.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.comParity)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.comParity, cmbComParity.Text.Trim());
            }
            if (nudHeartRateMax.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMax)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.HeartRateMax, nudHeartRateMax.Text.Trim());
            }
            if (nudHeartRateMin.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMin)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.HeartRateMin, nudHeartRateMin.Text.Trim());
            }
            if (nudBreatheMax.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.BreatheMax)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.BreatheMax, nudBreatheMax.Text.Trim());
            }
            if (nudBreatheMin.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.BreatheMin)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.BreatheMin, nudBreatheMin.Text.Trim());
            }
            if (ckbWarningOpen.Checked != (BizPars.getnSingInstance().getPar(SysBizPars.WarningOpen)=="1"?true:false)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.WarningOpen, (ckbWarningOpen.Checked)?"1":"0");
            }
            if (nudModeHartrate.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.ModeHartrate)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.ModeHartrate, nudModeHartrate.Text.Trim());
            }
            if (nudModeBreath.Text.Trim() != BizPars.getnSingInstance().getPar(SysBizPars.ModeBreath)

                )
            {
                BizPars.getnSingInstance().changePar(SysBizPars.ModeBreath, nudModeBreath.Text.Trim());
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //using Microsoft.Win32;
        public void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                this.cmbComPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    this.cmbComPort.Items.Add(sValue);
                }
            }
        }
        public void GetComPar()
        {
            //Baud rate
            this.cmbComBaud.Items.Add("110");
            this.cmbComBaud.Items.Add("300");
            this.cmbComBaud.Items.Add("600");
            this.cmbComBaud.Items.Add("1200");
            this.cmbComBaud.Items.Add("2400");
            this.cmbComBaud.Items.Add("4800");
            this.cmbComBaud.Items.Add("9600");
            this.cmbComBaud.Items.Add("14400");
            this.cmbComBaud.Items.Add("19200");
            this.cmbComBaud.Items.Add("38400");
            this.cmbComBaud.Items.Add("56000");
            this.cmbComBaud.Items.Add("57600");
            this.cmbComBaud.Items.Add("115200");
            this.cmbComBaud.Items.Add("128000");
            this.cmbComBaud.Items.Add("230400");
            this.cmbComBaud.Items.Add("256000");

            this.cmbComData.Items.Add("5");
            this.cmbComData.Items.Add("6");
            this.cmbComData.Items.Add("7");
            this.cmbComData.Items.Add("8");

            this.cmbComStop.Items.Add("0");
            this.cmbComStop.Items.Add("1");
            this.cmbComStop.Items.Add("1.5");
            this.cmbComStop.Items.Add("2");

            this.cmbComParity.Items.Add("None");
            this.cmbComParity.Items.Add("Odd");
            this.cmbComParity.Items.Add("Even");
            this.cmbComParity.Items.Add("Mark");
            this.cmbComParity.Items.Add("Space");

            nudHeartRateMax.Maximum = 256;
            nudHeartRateMax.Minimum = 0;
            nudHeartRateMin.Maximum = 256;
            nudHeartRateMin.Minimum = 0;
            nudBreatheMax.Maximum = 256;
            nudBreatheMax.Minimum = 0;
            nudBreatheMin.Maximum = 256;
            nudBreatheMin.Minimum = 0;
        }
    }
}
