using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using ORM;

namespace Business.DAL
{
    public static class ORMDAL
    {
        #region DB
        private static object _readLock = new object();
        private static volatile Database _read;
        public static Database Read
        {
            get
            {
                if (_read == null)
                {
                    lock (_readLock)
                    {
                        return _read ?? (_read = DatabaseFactory.CreateDatabase("DataRead"));
                    }
                }
                return _read;
            }
        }
        private static object _writeLock = new object();
        private static volatile Database _write;
        public static Database Write
        {
            get
            {
                if (_write == null)
                {
                    lock (_writeLock)
                    {
                        return _write ?? (_write = DatabaseFactory.CreateDatabase("DataWrite"));
                    }
                }
                return _write;
            }
        }
        private static object _adminLock = new object();
        private static volatile Database _admin;
        public static Database Admin
        {
            get
            {
                if (_admin == null)
                {
                    lock (_adminLock)
                    {
                        return _admin ?? (_admin = DatabaseFactory.CreateDatabase("Data"));
                    }
                }
                return _admin;
            }
        }
        internal static GetDb GetNormal = delegate() { return Admin; };
        internal static GetDb GetRead = delegate() { return Read; };
        internal static GetDb GetWrite = delegate() { return Write; };
        #endregion
    }
}
