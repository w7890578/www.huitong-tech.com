using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Business;
using Business.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Business.BLL
{
    public class ArticleBLL : BLL<Article>
    {
        #region 定义
        private static object lockObject = new object();
        protected ArticleBLL()
            : base(new ArticleDAL())
        {
        }
        private static volatile ArticleBLL _instance;
        public static ArticleBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new ArticleBLL());
                    }
                }
                return _instance;
            }
        }
        #endregion
        #region 方法
        public bool Update(Article entity)
        {
            Database db = Business.DAL.ORMDAL.Read;
            string sql = string.Format("update Article set TiTle=@TiTle,Text=@Text,ImgUrl=@ImgUrl,IsHomeShow=@IsHomeShow,Sort=@Sort,Description=@Description where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@TiTle", DbType.String, entity.Title);
            db.AddInParameter(cmd, "@Text", DbType.String, entity.Text);
            db.AddInParameter(cmd, "@ImgUrl", DbType.String, entity.ImgUrl);
            db.AddInParameter(cmd, "@Description", DbType.String, entity.Description);

            db.AddInParameter(cmd, "@IsHomeShow", DbType.Boolean, entity.IsHomeShow);
            db.AddInParameter(cmd, "@Sort", DbType.Int32, entity.Sort);
            db.AddInParameter(cmd, "@ID", DbType.Int32, entity.ID);
            object ob = db.ExecuteNonQuery(cmd);
            return (ob == null ? 0 : Convert.ToInt32(ob)) > 0;

        }

        public bool Add(Article entity)
        {
            Database db = Business.DAL.ORMDAL.Read;
            string sql = string.Format(@"insert into  Article (TiTle,Text,ImgUrl,IsHomeShow,Sort,ParentID,Description) 
            values(@TiTle,@Text,@ImgUrl,@IsHomeShow,@Sort,@ParentID,@Description)");
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@TiTle", DbType.String, entity.Title);
            db.AddInParameter(cmd, "@Text", DbType.String, entity.Text);
            db.AddInParameter(cmd, "@ImgUrl", DbType.String, entity.ImgUrl);
            db.AddInParameter(cmd, "@Description", DbType.String, entity.Description);

            db.AddInParameter(cmd, "@IsHomeShow", DbType.Boolean, entity.IsHomeShow);
            db.AddInParameter(cmd, "@Sort", DbType.Int32, entity.Sort);
            db.AddInParameter(cmd, "@ParentID", DbType.Int32, entity.ParentID); 

            object ob = db.ExecuteNonQuery(cmd);
            return (ob == null ? 0 : Convert.ToInt32(ob)) > 0;

        }
        #endregion
    }
}