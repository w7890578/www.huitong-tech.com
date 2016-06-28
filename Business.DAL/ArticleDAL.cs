using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Business;

namespace Business.DAL
{
    public class ArticleDAL : DAL<Article>
    {
        public ArticleDAL()
        {
            initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}