using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.BodyMonitoring.winform;
using com.xiyuansoft.bormodel;
using com.xiyuansoft.DataBasePro;
using com.xiyuansoft.xyAppConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace com.xiyuansoft.BodyMonitoring.start
{
    public class AppStart
    {
        static public void start(Form LoginForm, Form MainForm)
        {
            if (XyAppConfig.getAppinited() == "false")
            {
                //初始化系统
                DbInit();
            }

            xyAppInit();

            if (login(LoginForm))
            {
                Application.Run(MainForm);
                //if (BizPars.getnSingInstance().getPar(SysBizPars.bisInited) == "true")
                //{
                //    Application.Run(MainForm);
                //}
                //else
                //{
                //    if (new FrmBizInit().ShowDialog() == DialogResult.OK)
                //    {
                //        Application.Run(MainForm);
                //    }
                //}
            }

        }

        static private void DbInit()
        {
            //配置？？
            System.Collections.Hashtable dpPars = new System.Collections.Hashtable();
            dpPars.Add("dbName", "ederpdb");
            string DataBaseType = "com.xiyuansoft.DataBasePro.SQLite64.SQLiteDbAccess,com.xiyuansoft.DataBasePro.SQLite64";

            //检查数据库是否已经存在
            com.xiyuansoft.DataBasePro.DbService.DataBaseType = DataBaseType;
            com.xiyuansoft.DataBasePro.DbService tempDbServer = new com.xiyuansoft.DataBasePro.DbService(dpPars);

            //建立数据库
            string ConnectionString = tempDbServer.DbCreate(dpPars);
            com.xiyuansoft.DataBasePro.DbService.ConnectionString = ConnectionString;

            //修改配置文件，把连接串写入配置文件，并修改本运行时连接配置
            //XyAppConfig.setDbConconnectionString(ConnectionString);
            XyAppConfig.setDbInfo(ConnectionString, DataBaseType);

            //从配置文件中读取业务对象数据，生成业务对象表
            XmlNode BizObjsNode = XyAppConfig.getBizObjs();
            ArrayList BizObjsAl = new ArrayList();

            foreach (XmlNode bizObj in BizObjsNode.ChildNodes)
            {
                string bizObjClassName = bizObj.Attributes["className"].Value;

                BaseModel bizModelForCreateTable;

                //反射执行静态方法获得单例
                Type tx = System.Type.GetType(bizObjClassName);
                System.Reflection.MethodInfo mf = tx.GetMethod("getnSingInstance",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, new Type[] { }, null);
                bizModelForCreateTable = (BaseModel)mf.Invoke(null, null);

                //读初始数据及测试数据生成器
                if (bizObj.Attributes["idatacreater"] != null)
                {
                    string initDataClassName = bizObj.Attributes["idatacreater"].Value;
                    IInitData initDataClass = (IInitData)System.Activator.CreateInstance(System.Type.GetType(initDataClassName));
                    bizModelForCreateTable.initDataList.Add(initDataClass);
                }
                if (bizObj.Attributes["tdatacreater"] != null)
                {
                    string testDataClassName = bizObj.Attributes["tdatacreater"].Value;
                    ITestData testDataClass = (ITestData)System.Activator.CreateInstance(System.Type.GetType(testDataClassName));
                    bizModelForCreateTable.testDataList.Add(testDataClass);
                }

                BizObjsAl.Add(bizModelForCreateTable);
            }

            //*，生成物理表
            foreach (BaseModel BaseModelForCreateTable in BizObjsAl)
            {
                BaseModelForCreateTable.createTable();
            }

            //*，生成外键约束
            foreach (BaseModel BaseModelForCreateTable in BizObjsAl)
            {
                BaseModelForCreateTable.createFKey();
            }
            //*，生成元数据信息（表信息及字段信息）
            foreach (BaseModel BaseModelForCreateTable in BizObjsAl)
            {
                BaseModelForCreateTable.createMetaData();
            }
            //*，生成初始数据记录（业务对象内含的初始数据）
            if (BizObjsNode.Attributes["initdata"].Value == "true")
            {
                foreach (BaseModel BaseModelForCreateTable in BizObjsAl)
                {
                    BaseModelForCreateTable.createInitRecords();
                }
            }
            //*，生成测试数据记录（业务对象内含的测试数据）
            //if (BizObjsNode.Attributes["testdata"].Value == "true")
            //{
            //    foreach (BaseModel BaseModelForCreateTable in BizObjsAl)
            //    {
            //        BaseModelForCreateTable.createTestRecords();
            //    }
            //}

            //*，执行定制化SQL (暂不实现)
            //*，执行可选的SQL (暂不实现)
            //*,根据客户端数据执行定制的初始化操作 (暂不实现)

            //修改配置文件，写系统状态为已初始化
            XyAppConfig.setAppinited();

        }

        static private bool login(Form LoginForm)
        {
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                //记录登陆用户信息

                return true;
            }
            else
            {
                return false;
            }
        }

        static private void xyAppInit()
        {
            DbService.ConnectionString = XyAppConfig.getDbConconnectionString();
            DbService.DataBaseType = XyAppConfig.getDataBaseType();

            //检查数据库版本更新
            string thisV = BizPars.getnSingInstance().getPar(SysBizPars.batabaseV);

            //UpdateNode_1to1_1 un_1to1_1 = new UpdateNode_1to1_1();
            //UpdateNode_1_1to1_2 un_1_1to1_2 = new UpdateNode_1_1to1_2();
            //un_1to1_1.NextUn = un_1_1to1_2;
            //un_1_1to1_2.PreUn = un_1to1_1;

            //if (un_1_1to1_2.NewDbv != thisV)
            //{
            //    un_1_1to1_2.doUpdate(thisV);
            //}

        }
    }
}
