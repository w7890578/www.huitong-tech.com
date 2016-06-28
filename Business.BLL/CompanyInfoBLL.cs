using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Business;
using Business.DAL; 

namespace Business.BLL
{
    public class CompanyInfoBLL : BLL<CompanyInfo>
    {
        #region 定义
        private static object lockObject = new object();
        protected CompanyInfoBLL()
            : base(new CompanyInfoDAL())
        {
        }
        private static volatile CompanyInfoBLL _instance;
        public static CompanyInfoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new CompanyInfoBLL());
                    }
                }
                return _instance;
            }
        }
        #endregion
        #region 方法
        #endregion
    }
}