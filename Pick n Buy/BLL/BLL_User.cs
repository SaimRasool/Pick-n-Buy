using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pick_n_Buy.Models;
using Pick_n_Buy.DAL;

namespace Pick_n_Buy.BLL
{
    public class BLL_User
    {
        public void bllRegisterUser(MdlAccount mdl)
        {
            DAL_User obj = new DAL_User();
            obj.DalRegisterUser(mdl);
        }

        public MdlAccount bllLoginUser(MdlAccount mdl)
        {
            DAL_User obj = new DAL_User();
           return obj.DalLoginUser(mdl);
        }

        public MdlAccount bllReadUser(int ID)
        {
            DAL_User obj = new DAL_User();
            return obj.DalReadUser(ID);
        }

    }
}