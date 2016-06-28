using System;
using ORM;
namespace Business 
{
    [Serializable]
    [DbTable("CompanyInfo")]
    public class CompanyInfo
    {
        public CompanyInfo() { }
        #region 字段属性
        protected int _id = 0;
        ///<summary>
        ///
        ///</summary>
        [DbField("id", "INT", ORMType = ORMFieldType.Identity | ORMFieldType.Key | ORMFieldType.Unique)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected string _name = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("name", "NVARCHAR", 50)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        protected string _address = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("address", "NVARCHAR", 500)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        protected string _contactUserName = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("contactUserName", "NVARCHAR", 50)]
        public string ContactUserName
        {
            get { return _contactUserName; }
            set { _contactUserName = value; }
        }
        protected string _contactUserMobile = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("contactUserMobile", "NVARCHAR", 50)]
        public string ContactUserMobile
        {
            get { return _contactUserMobile; }
            set { _contactUserMobile = value; }
        }
        protected string _fixedPhone = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("fixedPhone", "NVARCHAR", 50)]
        public string FixedPhone
        {
            get { return _fixedPhone; }
            set { _fixedPhone = value; }
        }
        protected string _email = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("email", "NVARCHAR", 50)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}
