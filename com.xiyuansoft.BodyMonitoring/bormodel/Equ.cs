using com.xiyuansoft.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.bormodel
{
    /// <summary>
    /// 设备房间表
    /// </summary>
    class Equ : KBoModel
    {
        #region 单例模式
        protected Equ()
        {
            boModelID = Equ.BoModelID;
            tableName = Equ.TableName;   //表名（显示名称）
            tableCode = Equ.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static Equ single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static Equ getnSingInstance()
        {
            if (single == null)
            {
                single = new Equ();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "7c7e13358299471196e8eb1917a9dd09"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "设备房间表";   //表名（显示名称）
        static public String TableCode = "tEqu";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fEquID = "fEquID";
        static public String fEquRoom = "fEquRoom";

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            CommListType commListType = CommListType.getnSingInstance();
            CommList commList = CommList.getnSingInstance();

            base.createFieldsAl();
            base.addAStringField("设备编码", fEquID, 50);  //
            base.addAStringField("所在房间", fEquRoom, 500);  //
        }

        #region 数据库操作

        #endregion
    }
}
