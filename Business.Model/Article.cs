using System;
using ORM;
namespace Business 
{
    [Serializable]
    [DbTable("Article")]
    public class Article
    {
        public Article() { }
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
        protected string _title = string.Empty;
        ///<summary>
        ///标题
        ///</summary>
        [DbField("title", "NVARCHAR", 500)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        protected int _parentID = 0;
        ///<summary>
        ///
        ///</summary>
        [DbField("parentID", "INT")]
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }
        protected string _text = string.Empty;
        ///<summary>
        ///内容（存储html）
        ///</summary>
        [DbField("text", "TEXT")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        protected int _sort = 5000;
        ///<summary>
        ///排序
        ///</summary>
        [DbField("sort", "INT")]
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        protected bool _state = true;
        ///<summary>
        ///
        ///</summary>
        [DbField("state", "BIT")]
        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }
        protected DateTime _createTime;
        ///<summary>
        ///创建时间
        ///</summary>
        [DbField("createTime", "DATETIME")]
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        protected DateTime _updateTime;
        ///<summary>
        ///更新时间
        ///</summary>
        [DbField("updateTime", "DATETIME")]
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
        protected int _productID = 0;
        ///<summary>
        ///产品ID
        ///</summary>
        [DbField("productID", "INT")]
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }
        protected int _type = 0;
        ///<summary>
        ///类型
        ///</summary>
        [DbField("type", "INT")]
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        protected string _imgUrl = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("imgUrl", "NVARCHAR", 500)]
        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
        protected bool _isHomeShow = false;
        ///<summary>
        ///
        ///</summary>
        [DbField("isHomeShow", "BIT")]
        public bool IsHomeShow
        {
            get { return _isHomeShow; }
            set { _isHomeShow = value; }
        }

        protected string _description = string.Empty;
        ///<summary>
        ///
        ///</summary>
        [DbField("description", "NVARCHAR", 500)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
    }
}
