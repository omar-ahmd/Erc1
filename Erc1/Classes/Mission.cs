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
        public static bool delete_Mission_Team_Cases(int الرمز_الشهري, int رمز_السنوي, int السنة, int رمز_المركز)
        {
            bool delete1, delete2, delete3,delete;
            delete1 = delete2 = delete3 = false;
            using (var context = new ERCEntities())
            {
                try
                {
                    المهمات_المنفذة mission = context.المهمات_المنفذة.Where(x => ((x.الرمز_الشهري == الرمز_الشهري) && (x.رمز_السنوي == رمز_السنوي) && (x.السنة == السنة) && (x.رمز__المركز == رمز_المركز))).Single<المهمات_المنفذة>();
                    context.المهمات_المنفذة.Remove(mission);
                    context.SaveChanges();
                    delete1 = true;
                }
                catch { delete1 = false; }


                try
                {
                    context.حالات_المهمات.RemoveRange(context.حالات_المهمات.Where(x => ((x.الرمز_الشهري == الرمز_الشهري) && (x.رمز_السنوي == رمز_السنوي) && (x.السنة == السنة))));
                    context.SaveChanges();
                    delete2 = true;
                }
                catch { delete2 = false; }




                try
                {
                    context.الفريق.RemoveRange(context.الفريق.Where(x => ((x.الرمز_الشهري == الرمز_الشهري) && (x.رمز_السنوي == رمز_السنوي) && (x.السنة == السنة) && (x.رمز__المركز == رمز_المركز))));
                    context.SaveChanges();
                    delete3 = true;
                }
                catch { delete3 = false; }

                delete = delete1 && delete2 && delete3;
                return delete;
            }
        }


        // add to row if 0 in mustashfa/aksem  else if 1 in manate2

        //get mustashfa ma3 aksem id

        // add role (admin)



        // bool if to or from is present

        // get max

        // car


    }
}
