using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Business.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Business.BLL
{
    public class Cooperation
    {
        public string UserName {get;set;}
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public int Type { get; set; }
        public string Product { get; set; }
        public string Advantage { get; set; } 
        public int Know   {get;set;} 
        public string Remark {get;set;} 
        public enum CType
        {
            成为战略合作伙伴 = 1,
            成为地区代理商 = 2,
            成为项目合作伙伴 = 3
        }
        public enum CProduct
        {
            机床联网 = 1,
            程序管理 = 2,
            联网监控 = 3,
            其它 = 4
        }
        public enum CKnow
        {
            官方网站 = 1,
            网络搜索 = 2,
            微信媒体 = 3,
            朋友推荐 = 4,
            电子邮件 = 5,
            销售人员 = 6

        }

        public bool Add()
        {
            string sql = string.Format(@"
INSERT INTO  [Cooperation]
           ([UserName]
           ,[CompanyName]
           ,[Position]
           ,[Mobile]
           ,[Email]
           ,[QQ]
           ,[Type]
           ,[Product]
           ,[Advantage]
           ,[Know]
           ,[Remark])
     VALUES
           (@UserName,
            @CompanyName,
            @Position,
            @Mobile,
            @Email,
            @QQ,
            @Type,
            @Product,
            @Advantage, 
            @Know, 
            @Remark)");
            Database db = ORMDAL.Read;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@UserName", DbType.String, UserName);
            db.AddInParameter(cmd, "@CompanyName", DbType.String, CompanyName);
            db.AddInParameter(cmd, "@Position", DbType.String, Position);
            db.AddInParameter(cmd, "@Mobile", DbType.String, Mobile);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);
            db.AddInParameter(cmd, "@QQ", DbType.String, QQ);
            db.AddInParameter(cmd, "@Type", DbType.Int32, Type);
            db.AddInParameter(cmd, "@Product", DbType.String, Product);
            db.AddInParameter(cmd, "@Advantage", DbType.String, Advantage);
            db.AddInParameter(cmd, "@Know", DbType.Int32, Know);
            db.AddInParameter(cmd, "@Remark", DbType.String, Remark);
            return db.ExecuteNonQuery(cmd) > 0;
        }
    }
}
