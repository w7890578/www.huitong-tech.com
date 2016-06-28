using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Business; 

namespace Business.DAL
{
    public class CompanyInfoDAL : DAL<CompanyInfo>
    {
        public CompanyInfoDAL()
        {
            initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}