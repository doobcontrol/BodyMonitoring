using com.xiyuansoft.bormodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.xiyuansoft.BodyMonitoring.bormodel
{
    /// <summary>
    /// 干警表
    /// </summary>
    public class Police : KBoModel
    {
        #region 单例模式
        protected Police()
        {
            boModelID = Police.BoModelID;
            tableName = Police.TableName;   //表名（显示名称）
            tableCode = Police.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static Police single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static Police getnSingInstance()
        {
            if (single == null)
            {
                single = new Police();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "7c7e13358299471196e8eb1917a9dd09"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "干警表";   //表名（显示名称）
        static public String TableCode = "tPolice";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fPoliceName = "fPoliceName";
        static public String fArea = "fArea";

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            base.createFieldsAl();
            base.addAStringField("干警姓名", fPoliceName, 500);  //
            base.addAKBoFKeyField("所属监区", fArea,
                    Area.TableCode, Area.getnSingInstance());
        }

        #region 数据库操作

        #endregion
    }
}
