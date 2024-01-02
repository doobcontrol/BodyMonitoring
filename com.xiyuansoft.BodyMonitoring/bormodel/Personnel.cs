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
    /// 人员表
    /// </summary>
    public class Personnel : KBoModel
    {
        #region 单例模式
        protected Personnel()
        {
            boModelID = Personnel.BoModelID;
            tableName = Personnel.TableName;   //表名（显示名称）
            tableCode = Personnel.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static Personnel single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static Personnel getnSingInstance()
        {
            if (single == null)
            {
                single = new Personnel();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "4ea0d7d08a054c0aaa1e36244ffcdde3"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "人员表";   //表名（显示名称）
        static public String TableCode = "tPersonnel";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fPersonnelName = "fPersonnelName"; //姓名
        static public String fPersonnelCode = "fPersonnelCode"; //编码
        static public String fPersonnelSex = "fPersonnelSex"; //性别
        static public String fPersonnelBirth = "fPersonnelBirth"; //出生日期
        static public String fPersonnelPhoto = "fPersonnelPhoto"; //照片
        static public String fAreaName = "fAreaName"; //监区
        static public String fArea = "fArea"; //监区
        static public String fPoliceName = "fPoliceName"; //干警
        static public String fPolice = "fPolice"; //干警

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            CommListType commListType = CommListType.getnSingInstance();
            CommList commList = CommList.getnSingInstance();

            base.createFieldsAl();
            base.addAStringField("姓名", fPersonnelName, 50);  //
            base.addAStringField("编码", fPersonnelCode, 50);  //
            base.addAComFKeyField("性别", fPersonnelSex, CommListType.ID_SEX);
            commList.addOptInitItems(CommListType.ID_SEX);
            base.addAStringField("出生日期", fPersonnelBirth, 50);  //
            base.addAStringField("照片", fPersonnelPhoto, 500);  //



            base.addAStringField("所属监区", fAreaName, 100);  //
            base.addAKBoFKeyField("监区ID", fArea,
                    Area.TableCode, Area.getnSingInstance());
            base.addAStringField("干警姓名", fPoliceName, 50);  //
            base.addAKBoFKeyField("干警ID",fPolice,
                    Police.TableCode, Police.getnSingInstance());

        }

        #region 数据库操作

        #endregion
    }
}
