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

        //get mustashfa ma3 aksem id

        // add role (admin)


        // add marda with return id and name
        public static int add_Patient(المرضى new_patient)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.المرضى.Add(new_patient);
                    entity.SaveChanges();
                    newID = new_patient.الرمز;
                    return newID;
                }
                catch
                {
                    return 00;//error
                }
            };

        }

        // bool if to or from is present

        // get max

        // change hospital status from id
        public void UpdateHospitalStatus(DataRow HospitalRow)//I need the id
        {
            using (ERCEntities entity = new ERCEntities())
            {
                المستشفيات c = new المستشفيات();
                int id = int.Parse(HospitalRow["رمز_المستشفى"].ToString());
                c = entity.المستشفيات.First(r => r.رمز_المستشفى == id);
                c.الحالة = HospitalRow["الحالة"].ToString();
                c.الملاحظات = HospitalRow["الملاحظات"].ToString();
                entity.SaveChanges();
            };
        }

        // car


    }
}
