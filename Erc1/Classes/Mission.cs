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
       //Add member team to a mission
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


        // check if patient exist
        public static bool Check_Patient(int patientID)
        {
            int rep;
            bool e;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    rep = entity.المرضى
                      .Where(r => r.الرمز == patientID)
                      .Count()
                      ;
                    if (rep == 0) e = false;
                    else e = true;
                    return e;
                }
                catch
                {
                    e = false;
                    return e;
                }
            };

        }


        // return int إلى if no error occured and -1 if there is an error
        public static int Get_from_Region(int regionID)
        {
            int rep;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    if(entity.من.Count((r => r.من1 == regionID && r.مستشفى_منطقة==false)) == 0)
                    {
                        من fom = new من();
                        fom.مستشفى_منطقة = false;
                        fom.من1 = regionID;
                        entity.من.Add(fom);
                        entity.SaveChanges();
                        rep = fom.الرمز;
                    }
                    else
                    {
                        rep = entity.من.Where((r => r.من1 == regionID && r.مستشفى_منطقة == false)).First().الرمز;
                    }
                    return rep;
                }
                catch
                {
                    rep = -1;
                    return rep;
                }
            };

        }


        // return int إلى if no error occured and -1 if there is an error
        public static int Get_to_Region(int regionID)
        {
            int rep;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    if (entity.إلى.Count((r => r.إلى1 == regionID && r.مستشفى_منطقة == false)) == 0)
                    {
                        إلى fom = new إلى();
                        fom.مستشفى_منطقة = false;
                        fom.إلى1 = regionID;
                        entity.إلى.Add(fom);
                        entity.SaveChanges();
                        rep = fom.الرمز;
                    }
                    else
                    {
                        rep = entity.إلى.Where((r => r.إلى1 == regionID && r.مستشفى_منطقة == false)).First().الرمز;
                    }
                    return rep;
                }
                catch
                {
                    rep = -1;
                    return rep;
                }
            };

        }



        // return int من if no error occured and -1 if there is an error
        public static int Get_from_Hospital_Section(int hosID,int secID)
        {
            int rep;
            int hos_secID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                  hos_secID =entity.المستشفيات_مع_اقسام.Where((r => r.رمز_المشفى == hosID && r.رمز_القسم == secID)).Select(r => r.الرمز).FirstOrDefault();

                    if (entity.من.Count((r => r.من1 == hos_secID && r.مستشفى_منطقة == true)) == 0)
                    {
                        من fom = new من();
                        fom.مستشفى_منطقة = true;
                        fom.من1 = hos_secID;
                        entity.من.Add(fom);
                        entity.SaveChanges();
                        rep = fom.الرمز;
                    }
                    else
                    {
                        rep = entity.من.Where((r => r.من1 == hos_secID && r.مستشفى_منطقة == true)).First().الرمز;
                    }
                    return rep;
                }
                catch
                {
                    rep = -1;
                    return rep;
                }
            };

        }



        // return int إلى if no error occured and -1 if there is an error
        public static int Get_to_Hospital_Section(int hosID, int secID)
        {
            int rep;
            int hos_secID;
            using (ERCEntities entity = new model.ERCEntities())
            {

                hos_secID = entity.المستشفيات_مع_اقسام.Where((r => r.رمز_المشفى == hosID && r.رمز_القسم == secID)).Select(r => r.الرمز).FirstOrDefault();
                try
                {
                    if (entity.إلى.Count((r => r.إلى1 == hos_secID && r.مستشفى_منطقة == true)) == 0)
                    {
                        إلى fom = new إلى();
                        fom.مستشفى_منطقة = true;
                        fom.إلى1 = hos_secID;
                        entity.إلى.Add(fom);
                        entity.SaveChanges();
                        rep = fom.الرمز;
                    }
                    else
                    {
                        rep = entity.إلى.Where((r => r.إلى1 == hos_secID && r.مستشفى_منطقة == true)).First().الرمز;
                    }
                    return rep;
                }
                catch
                {
                    rep = -1;
                    return rep;
                }
            };

        }










        // add to row if 0 in mustashfa/aksem  else if 1 in manate2

        //get mustashfa ma3 aksem id

        // add role (admin)



        // bool if to or from is present

        // get max

        // car


    }
}
