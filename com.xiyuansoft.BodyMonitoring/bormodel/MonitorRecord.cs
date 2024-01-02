using com.xiyuansoft.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.bormodel
{
    /// <summary>
    /// 监测记录表
    /// </summary>
    public class MonitorRecord : KBoModel
    {
        #region 单例模式
        protected MonitorRecord()
        {
            boModelID = MonitorRecord.BoModelID;
            tableName = MonitorRecord.TableName;   //表名（显示名称）
            tableCode = MonitorRecord.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static MonitorRecord single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static MonitorRecord getnSingInstance()
        {
            if (single == null)
            {
                single = new MonitorRecord();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "7c7e13358299471196e8eb1917a9dd09"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "监测记录表";   //表名（显示名称）
        static public String TableCode = "tMonitorRecord";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fPersonnel = "fPersonnel";
        static public String fEqu = "fEqu";
        static public String fMonitorTime = "fMonitorTime";


        static public String fHeartRate = "fHeartRate";
        static public String fBreathee = "fBreathee";

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            CommListType commListType = CommListType.getnSingInstance();
            CommList commList = CommList.getnSingInstance();

            base.createFieldsAl();
            base.addAStringField("监测时间", fMonitorTime, 50);  //

            base.addAKBoFKeyField("监测目标", fPersonnel,
                    Personnel.TableCode, Personnel.getnSingInstance());
            base.addAKBoFKeyField("监测房间", fEqu,
                    Equ.TableCode, Equ.getnSingInstance());

            base.addAIntField("心率", fHeartRate);
            base.addAIntField("呼吸", fBreathee);
        }

        #region 数据库操作

        #endregion
    }
}
