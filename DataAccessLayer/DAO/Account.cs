using System;
using System.Collections;
using System.Data;

namespace DataAccessLayer.DAO
{
    public class Account : TableEntity, ICloneable
    {
        private string password;

        public Account()
        {
        }

        public Account(int id)
            : this()
        {
            Id = id;
            Load();
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return this["Name"].ToString(); }
        }

        public int AccessLevel
        {
            get { return this["AccessLevel"].ToInt(); }
        }

        public string UserName
        {
            get { return this["Username"].ToString(); }
        }

        #region ICloneable Members
        public object Clone()
        {
            return new Account { values = values, Id = Id, password = password };
        }
        #endregion

        public bool Login(string username, string pass)
        {
            ResetConnection();
            password = pass;
            if (LoadFiltered(tabledef.tableName + ".Username = '" + username + "'"))
            {
                values = Table();
                base.Id = this["Id"].ToInt();
                return values.Rows.Count == 1 && !this["Suspended"].ToBoolean();
            }
            return false;
        }

        protected override int SaveRow(DataRow row, bool forced)
        {
            if (row.RowState == DataRowState.Detached || row.RowState == DataRowState.Added)
            {
                return Create() ? GetInsertId() : 0;
            }
            return 0;
        }

        public override bool DeleteRow(DataRow row)
        {
            return ExecuteScalar("DeleteUser", new Hashtable { { "@Id", row["Id"] } }) == 0;
        }

        public override bool Create()
        {
            return ExecuteScalar("CreateUser", new Hashtable
                                                   {
                                                       {"@UserName", UserName},
                                                       {"@Password", Password},
                                                       {"@RealName", Name},
                                                       {"@Role", AccessLevel}
                                                   }) == 0;
        }

        public bool ChangeSuspensionState()
        {
            return ExecuteScalar("ChangeUserSuspension", new Hashtable
                                                             {
                                                                 {"@AccountId", base.Id}
                                                             }) == 0;
        }

        public bool ChangePassword(string newPassword)
        {
            return Execute("ALTER LOGIN " + UserName + " WITH Password ='" + newPassword + "'");
        }
    }
}