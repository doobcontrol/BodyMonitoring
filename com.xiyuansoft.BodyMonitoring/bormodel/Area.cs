using com.xiyuansoft.bormodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.bormodel
{
    /// <summary>
    /// 监区表
    /// </summary>
    public class Area : KBoModel
    {
        #region 单例模式
        protected Area()
        {
            boModelID = Area.BoModelID;
            tableName = Area.TableName;   //表名（显示名称）
            tableCode = Area.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static Area single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static Area getnSingInstance()
        {
            if (single == null)
            {
                single = new Area();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "7c7e13358299471196e8eb1917a9dd09"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "监区表";   //表名（显示名称）
        static public String TableCode = "tArea";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fAreaName = "fAreaName";

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            base.createFieldsAl();
            base.addAStringField("监区名", fAreaName, 500);  //
        }

        #region 数据库操作

        #endregion
    }
}
