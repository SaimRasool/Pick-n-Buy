using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Pick_n_Buy.Models;
using System.Data.SqlClient;
using System.Data;

namespace Pick_n_Buy.DAL
{
    public class DAL_User
    {
        private string _ConnString;
        #region Query

        const String SQL_Register_User = "SPW_SignUP";
        const String SQL_Login_User = "SPW_IsUserExist";
        const String SQL_Read_User = "SPW_ReadUser";

        
        #endregion

        #region Parameters

        const String PARM_USER_ID = "@ID";
        const String PARM_USER_Fname = "@Fname";
        const String PARM_USER_Lname = "@Lname";
        const String PARM_USER_Email = "@Email";
        const String PARM_USER_Password = "@Password";
        const String PARM_USER_Company = "@Company";
        const String PARM_USER_Address = "@Address";
        const String PARM_USER_City = "@City";
        const String PARM_USER_Country = "@Country";
        const String PARM_USER_Phone = "@Phone";
        const String PARM_IsAdmin = "@IsAdmin";

        #endregion

        #region Constructor
        public DAL_User()
        {
            _ConnString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }
        #endregion

        public void DalRegisterUser(MdlAccount mdl)
        {
            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter(PARM_USER_Fname, SqlDbType.NVarChar)
            {
                Value = mdl.FName
            };
            parm[1] = new SqlParameter(PARM_USER_Lname, SqlDbType.NVarChar)
            {
                Value = mdl.Lname
            };
            parm[2] = new SqlParameter(PARM_USER_Email, SqlDbType.NVarChar)
            {
                Value = mdl.Email
            };
            parm[3] = new SqlParameter(PARM_USER_Password, SqlDbType.NVarChar)
            {
                Value = mdl.Password
            };
            parm[4] = new SqlParameter(PARM_USER_City, SqlDbType.NVarChar)
            {
                Value = mdl.City
            };
            parm[5] = new SqlParameter(PARM_USER_Country, SqlDbType.NVarChar)
            {
                Value = mdl.Country
            };
            parm[6] = new SqlParameter(PARM_USER_Address, SqlDbType.NVarChar)
            {
                Value = mdl.Address
            };
            parm[7] = new SqlParameter(PARM_USER_Company, SqlDbType.NVarChar)
            {
                Value = mdl.Company
            };
            parm[8] = new SqlParameter(PARM_USER_Phone, SqlDbType.BigInt)
            {
                Value = mdl.Phone
            };
            parm[9] = new SqlParameter(PARM_IsAdmin, SqlDbType.Int)
            {
                Value = mdl.IsAdmin
            };
            SqlHelper.SaveData(this._ConnString, CommandType.StoredProcedure, SQL_Register_User, parm);

        }

        public MdlAccount DalLoginUser(MdlAccount mdl)
        {
            try
            {
                MdlAccount RtrnVal = new MdlAccount();
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter(PARM_USER_Email, SqlDbType.NVarChar)
                {
                    Value = mdl.Email
                };
                parm[1] = new SqlParameter(PARM_USER_Password, SqlDbType.NVarChar)
                {
                    Value = mdl.Password
                };
                DataTable oTable = SqlHelper.ExecuteTable(this._ConnString, CommandType.StoredProcedure, SQL_Login_User, parm);
                foreach (DataRow oRow in oTable.Rows)
                {
                    RtrnVal.ID = Model.Common.CheckIntegerNull(oRow["ID"]);
                    RtrnVal.Email = Model.Common.CheckStringNull(oRow["Email"]);
                    RtrnVal.Password = Model.Common.CheckStringNull(oRow["Password"]);
                    RtrnVal.IsAdmin = Model.Common.CheckIntegerNull(oRow["IsAdmin"]);
                }

                return RtrnVal;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public MdlAccount DalReadUser(int ID)
        {
            try
            {
                MdlAccount RtrnVal = new MdlAccount();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter(PARM_USER_ID, SqlDbType.Int)
                {
                    Value = ID
                };
                DataTable oTable = SqlHelper.ExecuteTable(this._ConnString, CommandType.StoredProcedure, SQL_Read_User, parm);
                foreach (DataRow oRow in oTable.Rows)
                {
                    RtrnVal.ID = Model.Common.CheckIntegerNull(oRow["ID"]);
                    RtrnVal.Email = Model.Common.CheckStringNull(oRow["Email"]);
                    RtrnVal.FName = Model.Common.CheckStringNull(oRow["Fname"]);
                    RtrnVal.Lname = Model.Common.CheckStringNull(oRow["Lname"]);
                    RtrnVal.Country = Model.Common.CheckStringNull(oRow["Country"]);
                    RtrnVal.Address = Model.Common.CheckStringNull(oRow["Address"]);
                    RtrnVal.City = Model.Common.CheckStringNull(oRow["City"]);
                    RtrnVal.Phone = Model.Common.CheckLongNull(oRow["Phone"]);

                }

                return RtrnVal;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}