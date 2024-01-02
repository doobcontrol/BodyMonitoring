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
    /// 用户表
    /// </summary>
    class User : KBoModel
    {
        #region 单例模式
        protected User()
        {
            boModelID = User.BoModelID;
            tableName = User.TableName;   //表名（显示名称）
            tableCode = User.TableCode;   //表物理名（数据库操作名）	

            doExportData = true;
        }

        private static User single;

        /**
         * 返回本类唯一实例，饿汉式单例类
         */
        public static User getnSingInstance()
        {
            if (single == null)
            {
                single = new User();
            }
            return single;
        }

        #endregion

        static public String BoModelID = "79d2fd76c86c4846a267bdc28244dca5"; //? System.Guid.NewGuid().ToString("N");
        static public String TableName = "用户表";   //表名（显示名称）
        static public String TableCode = "tUser";   //表物理名（数据库操作名）

        //字段（属性）名称定义
        static public String fLoginName = "fLoginName";
        static public String fLoginPass = "fLoginPass";
        static public String fUserName = "fUserName";
        static public String fIsAdmin = "fIsAdmin";

        //常量定义

        /**
         * 生成字段信息集，由子类覆盖，并总是先调用父类
         */
        protected override void createFieldsAl()
        {
            CommListType commListType = CommListType.getnSingInstance();
            CommList commList = CommList.getnSingInstance();

            base.createFieldsAl();
            base.addAStringField("登陆名", fLoginName, 50);  //
            base.addAStringField("登陆密码", fLoginPass, 50);  //
            base.addAStringField("用户姓名", fUserName, 50);  //
            base.addAComFKeyField("管理员", fIsAdmin, CommListType.ID_YesNo);
            commList.addOptInitItems(CommListType.ID_YesNo);


            Hashtable tempRecordHt = new Hashtable();
            initDataAl.Add(tempRecordHt);
            tempRecordHt.Add(fID, "admin");//System.Guid.NewGuid().ToString("N"));
            tempRecordHt.Add(fLoginName, "admin");
            tempRecordHt.Add(fLoginPass, "admin");
            tempRecordHt.Add(fUserName, "管理员");
            tempRecordHt.Add(fIsAdmin, CommListType.ID_YesNo_y);
        }

        #region 数据库操作

        public DataTable selectAllNormalUser()
        {
            string sqlStr = "select * from " + tableCode + " where " + fIsAdmin + "='" + CommListType.ID_YesNo_n + "'";

            return exeSqlForDataSet(sqlStr);
        }

        public void newUser(Hashtable uHt)
        {
            if (checkLoginNameExist(uHt))
            {
                throw new ApplicationException("登陆名已经存在");
            }
            else
            {
                insertMainRecord(uHt);
            }
        }

        public void editUser(string userID, Hashtable uHt)
        {
            if (checkLoginNameExist(uHt))
            {
                throw new ApplicationException("登陆名已经存在");
            }
            else
            {
                updateByPKey(userID, uHt);
            }
        }

        public void delUser(string userID)
        {
            if (checkUserBisExist(userID))
            {
                throw new ApplicationException("做过业务的用户不能删除");
            }
            else
            {
                deleteByPKey(userID);
            }
        }

        public bool checkLoginNameExist(Hashtable uHt)
        {
            DataTable uDt = selectByOneField(fLoginName, uHt[fLoginName].ToString());
            if (uDt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkUserBisExist(string userID)
        {
            return false; //??
        }

        public DataRow Login(string loginName, string loginPass)
        {
            DataTable uTb = selectByOneField(fLoginName, loginName);
            if (uTb.Rows.Count == 0)
            {
                throw new ApplicationException("登陆名不存在");
            }
            DataRow uDr = uTb.Rows[0];
            if (uDr[fLoginPass].ToString() != loginPass)
            {
                throw new ApplicationException("密码不正确");
            }
            return uDr;
        }

        public DataRow EditPassword(string userID, string newPass)
        {
            Hashtable tHt = new Hashtable();
            tHt.Add(fLoginPass, newPass);
            updateByPKey(userID, tHt);
            return selectByPKey(userID).Rows[0];
        }

        #endregion
    }
}
