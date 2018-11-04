using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dao;
using Models;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;

namespace DataBase
{
    public class DbOps
    {
        //登录用
        public String getPwdbyUname(String uname)
        {
            String pwd = null;
            using (var db = SugarDao.GetInstance())
            {
                pwd = db.GetString("select passwd from user where username=@username", new { username = uname });
            }
            return pwd;
        }
        //操作cookie
        public int getIsAuto()
        {
            int isauto = 0;
            using (var db = SugarDao.GetInstance())
            {
                isauto = db.GetInt("select isauto from cookie where id=1 limit 1");
            }
            return isauto;
        }
        public int getIsLogPwd()
        {
            int isauto = 0;
            using (var db = SugarDao.GetInstance())
            {
                isauto = db.GetInt("select islogpwd from cookie where id=1 limit 1");
            }
            return isauto;
        }
        public DataTable getCookies()
        {
            DataTable cookies = null;
            using (var db = SugarDao.GetInstance())
            {
                cookies = db.GetDataTable("select username,passwd from cookie where id=@id limit 1", new { id = 1 });
            }
            return cookies;
        }
        public int updateCookies(string username, string passwd, int isauto, int islogpwd)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update cookie set username=@username,passwd=@passwd,isauto=@isauto,islogpwd=@islogpwd where id=@id", new { username = username, passwd = passwd, isauto = isauto, islogpwd = islogpwd, id = 1 });
            }
            return num;
        }

        public DataTable getItemView()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from testitems order by sortid asc");
            }
            return dt;
        }
        public DataTable dcgetItemView()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from dcitems order by sortid asc");
            }
            return dt;
        }
        public DataTable getItemViewChecked()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from testitems where ischecked=1 order by sortid asc");
            }
            return dt;
        }
        public DataTable dcgetItemViewChecked()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from dcitems where ischecked=1 order by sortid asc");
            }
            return dt;
        }
        public int updatecheckedbyid(int chk, int sortid)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update testitems set ischecked=@chk where sortid=@sortid", new { chk = chk, sortid = sortid });
            }
            return num;
        }
        public int dcupdatecheckedbyid(int chk, int sortid)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update dcitems set ischecked=@chk where sortid=@sortid", new { chk = chk, sortid = sortid });
            }
            return num;
        }
        //更新排列顺序
        public int updatesortids(int tableid,int sortid)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update testitems set sortid=@sortid where id=@id", new { sortid = sortid, id = tableid });
            }
            return num;
        }
        public int dcupdatesortids(int tableid, int sortid)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update dcitems set sortid=@sortid where id=@id", new { sortid = sortid, id = tableid });
            }
            return num;
        }
        public DataTable getsortidlist()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select sortid from testitems order by id asc");
            }
            return dt;
        }
        public DataTable dcgetsortidlist()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select sortid from dcitems order by id asc");
            }
            return dt;
        }
        //更新测试结果
        public int updateTestResult(int tableid, string result)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update testitems set result=@result where id=@id", new { result = result, id = tableid });
            }
            return num;
        }
        public int dcupdateTestResult(int tableid, string result)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update dcitems set result=@result where id=@id", new { result = result, id = tableid });
            }
            return num;
        }
        //串口设置
        public DataTable getComSettings()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from comsettings order by id asc");
            }
            return dt;
        }
        public int updateComSettings(int tableid, string port,int bundrate,int databit,float stopbit,string parity)
        {
            int num = 0;
            using (var db = SugarDao.GetInstance())
            {
                num = db.ExecuteCommand("update comsettings set port=@port,bundrate=@bundrate,databit=@databit,stopbit=@stopbit,parity=@parity where id=@id", new { port = port, bundrate = bundrate, databit = databit, stopbit = stopbit, parity = parity, id = tableid });
            }
            return num;
        }
        //协议一致性试验
        public DataTable XYgetItemView()
        {
            DataTable dt = null;
            using (var db = SugarDao.GetInstance())
            {
                dt = db.GetDataTable("select * from protocol order by id asc");
            }
            return dt;
        }
    }
}
