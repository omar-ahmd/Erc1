using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Erc1.model;
using System.Collections;
using System.Data;

namespace Erc1.Classes
{
    class Mission
    {
        // add 3amel fari2
       // public static bool add_Mission_Memeber(int الرمز_الشهري,int رمز_السنوي,int السنة, int رمز_المركز,int رمز_العامل,int دور_العامل)
        public static bool add_Mission_Memeber(الفريق mission_member)
        {
            bool added = false;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.الفريق.Add(mission_member);
                    added = entity.SaveChanges() > 0 ? true : false; ;
                    return added;
                }
                catch
                {
                    added = false;
                    return added;
                }
            };

        }



        // add to row if 0 in mustashfa/aksem  else if 1 in manate2

        // add role (admin)


        // add marda with return id and name

        // bool if to or from is present

        // get max

        // change hospital status from id



        //public static bool updateHospitalStatus(int Hospital_ID)
        //{
        //    using (ERCEntities entity = new ERCEntities())
        //    {
        //        المستشفيات c = new المستشفيات();
        //        c = entity.المستشفيات.First(r => r.رمز_المستشفى == Hospital_ID);
        //        c. = newphone;
        //        t_1.SaveChanges();
        //        return c;
        //    };
        //}

        // car


    }
}
