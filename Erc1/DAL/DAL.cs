using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erc1.DAL;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Erc1.Classes
{
    class mission
    {


        // get monthlyid 
        public static int Get_MonthlyID()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c = entity.المهمات_المنفذة
                   .Where(r => r.الرمز_الشهري == entity.المهمات_المنفذة.Max(p => p.الرمز_الشهري))
                   .Select(r => r.الرمز_الشهري).Single()
                   ;
                return c;
            };
        }


        // get yearid 
        public static int Get_YearID()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c = entity.المهمات_المنفذة
                   .Where(r => r.رمز_السنوي == entity.المهمات_المنفذة.Max(p => p.رمز_السنوي))
                   .Select(r => r.رمز_السنوي).Single()
                   ;
                return c;
            };
        }




        //get all centers (column names ="centers","id")
        public static IEnumerable Get_Centers()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = from centers in entity.المراكز
                        where centers.المدن.رمز == centers.المدينة
                        select new
                        {
                            centers = centers.الرمز,// + " - " + centers.المدن.المدينة,
                            id = centers.الرمز
                        };

                return c.ToList();
            };
        }



        // cars of a center by id column name("cars")
        public static IEnumerable Getالآليات()
        {

            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from cars in entity.الآليات
                select new
                {
                    cars = cars.رمز_الآلية
                }
                    ); ;
                return c.ToList();
            };

        }

        // cars of a center by id column name("cars")
        public static IEnumerable Getالآليات_by_المركز(int marakez)
        {

            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from cars in entity.الآليات
                where cars.المركز == marakez
                select new
                {

                    cars = cars.رمز_الآلية
                }
                    ); ;
                return c.ToList();
            };

        }

        // get الحالات names (column names ="المرض","رمز")
        public static IEnumerable Get_الحالات()
        {
            try
            {


                using (ERCEntities entity = new ERCEntities())
                {
                    var c = (
                    from disease in entity.الحالات
                    select new
                    {
                        disease.رمز,
                        المرض = disease.المرض_بالانجليزي + " - " + disease.المرض
                    }
                        ); ;
                    return c.ToList();
                };
            }
            catch
            {
                MessageBox.Show("error");
                return null;
            }
        }
        // get الحالات names by idنوعية_الحالة (column name ="المرض")
        public static IEnumerable Get_الحالات_by_idنوعية_الحالة(int id_type_of_disease)
        {
            using (var entity = new ERCEntities())
            {
                var c = entity.الحالات
                    .Where(r => r.رمز_النوعية == id_type_of_disease)
                    .Select(r => new
                    {
                        r.رمز,
                        المرض = r.المرض_بالانجليزي + " - " + r.المرض
                    });
                return c.ToList();
            }
        }
        // get نوعيات الحالات (column name ="النوعية","الرمز")
        public static IEnumerable Get_نوعيات_الحالات()
        {
            using (var entity = new ERCEntities())
            {
                var c = entity.نوعيات_الحالات;
                return c.ToList();
            }
        }
















        // get العاملون names (column names ="الاسم","الرمز")
        public static IEnumerable Get_العاملون()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }


        // get العاملون names by المراكز(column names ="الاسم","الرمز")
        public static IEnumerable Get_العاملون_by_idالمراكز(int center_id)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => r.المركز == center_id)
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }




        // get المسعفون names by المراكز(column names ="الاسم","الرمز")
        public static IEnumerable Get_المسعفون_by_idالمراكز(int center_id)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.المركز == center_id && r.مسعف_أو_مساعد == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }

        // get السائقون names by المراكز(column names ="الاسم","الرمز")
        public static IEnumerable Get_السائقون_by_idالمراكز(int center_id)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.المركز == center_id && r.سائق_أو_لا == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }

        // get مسؤول مهمة names by المراكز(column names ="الاسم","الرمز")
        public static IEnumerable Get_مسؤول_مهمة_by_idالمراكز(int center_id)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.المركز == center_id && r.مسؤول_مهمة_أو_لا == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }





        // get المسعفون names (column names ="الاسم","الرمز")
        public static IEnumerable Get_المسعفون()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.مسعف_أو_مساعد == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }

        // get السائقون names (column names ="الاسم","الرمز")
        public static IEnumerable Get_السائقون()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.سائق_أو_لا == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }

        // get مسؤول مهمة names (column names ="الاسم","الرمز")
        public static IEnumerable Get_مسؤول_مهمة()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from staff in entity.العاملون.
                Where(r => (r.مسؤول_مهمة_أو_لا == true))
                select new
                {
                    staff.الرمز,
                    staff.الاسم
                }
                    ); ;
                return c.ToList();
            };
        }










        // get المرضى names(column names ="اسم","الرمز")
        public static IEnumerable Get_المرضى()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from p in entity.المرضى
                select new
                {
                    p.الرمز,
                    p.اسم
                }
                    ); ;
                return c.ToList();
            };
        }


        // get المدن names(column names ="المدينة","رمز")
        public static IEnumerable Get_المدن()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from p in entity.المدن
                select new
                {
                    p.رمز,
                    p.المدينة
                }
                    ); ;
                return c.ToList();
            };
        }



        // get المناطق names(column names ="المنطقة","رمز")
        public static IEnumerable Get_المناطق(int city_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from p in entity.المناطق
                where p.المدينة == city_key
                select new
                {
                    p.رمز,
                    p.المنطقة
                }
                    ); ;
                return c.ToList();
            };
        }


        // get المستشفيات(column names ="اسم","رمز_المستشفى")
        public static IEnumerable Get_المستشفيات()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from h in entity.المستشفيات
                select new
                {
                    h.رمز_المستشفى,
                    h.اسم_المستشفى
                }
                    ); ;
                return c.ToList();
            };
        }






        // get أقسام المستشفيات (column names ="sections_id","sections_name")
        public static IEnumerable Get_أقسام_المستشفيات(int hospital_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from h_s in entity.المستشفيات_مع_اقسام
             where h_s.رمز_المشفى == hospital_key && h_s.رمز_القسم == h_s.أقسام_المستشفيات.الرمز
             select new
             {
                 sections_id = h_s.أقسام_المستشفيات.الرمز,
                 sections_name = h_s.أقسام_المستشفيات.اسم_القسم


             });
                return c.ToList();
            }
        }




        // get monthlyid 
        public static int Get_MonthlyID(int year, int month)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c;
                try
                {
                    c = entity.المهمات_المنفذة
                        .Where(r => (r.التاريخ.Value.Year == year) && (r.التاريخ.Value.Month == month))
                        .Max(r => r.الرمز_الشهري)
                        ;
                    c += 1;
                }
                catch (Exception ex)
                {
                    c = 1;
                }
                return c;
            };
        }


        // get yearid 
        public static int Get_YearID(int year)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c;
                try
                {
                    c = entity.المهمات_المنفذة
                   .Where(r => r.التاريخ.Value.Year == year).Max(p => p.رمز_السنوي)

                   ;
                    c += 1;
                }
                catch
                {
                    c = 1;
                }
                return c;
            };
        }




        // get طوابق المستشفيات
        public static short[] Get_طوابق_المستشفيات(int hospital_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                short[] c;
                short c1, c2;

                c1 = entity.المستشفيات.
               Where(r => r.رمز_المستشفى == hospital_key)
               .Select(r => r.الطابق_السفلي).Single().Value;
                c2 = entity.المستشفيات.
                  Where(r => r.رمز_المستشفى == hospital_key)
                  .Select(r => r.الطابق_العلوي).Single().Value;
                c = new short[c2 - c1 + 1];
                for (short i = 0; i <= c2 - c1; i++)
                {
                    c[i] = (short)(c1 + i);
                }
                return c;
            };
        }



        // get الأطباء by hospitalID (column names ="رمز","اسم")
        public static IEnumerable Get_الأطباء()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from doctors in entity.الأطباء

             select new
             {
                 doctors.رمز,
                 doctors.اسم
             }); ;
                return c.ToList();
            }
        }





        // get الجهات_الضامنة(column names ="الجهة_الضامنة","الرمز")
        public static IEnumerable Get_الجهات_الضامنة()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from insurance in entity.الجهات_الضامنة
             select new
             {
                 insurance.الرمز,
                 insurance.الجهة_الضامنة
             }); ;
                return c.ToList();
            }
        }

        // get الأمراض_المعدية(column names ="المرض","الرمز")
        public static IEnumerable Get_الأمراض_المعدية()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from disease in entity.الأمراض_المعدية
             select new
             {
                 disease.الرمز,
                 disease.المرض
             }); ;
                return c.ToList();
            }
        }









        public static bool add_Mission(المهمات_المنفذة new_Mission)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    entity.المهمات_المنفذة.Add(new_Mission);
                    added = entity.SaveChanges() > 0 ? true : false; ;
                    return added;
                }
                catch (Exception ex)
                {
                    added = false;
                    return added;
                }
            };

        }


        public static bool add_Mission(المهماة_المؤجلة new_Mission)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    entity.المهماة_المؤجلة.Add(new_Mission);
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


        public static bool add_Mission(المهمات_الملغاة new_Mission)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    entity.المهمات_الملغاة.Add(new_Mission);
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



        public static bool add_Cases(DataTable new_Case)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    foreach (DataRow row in new_Case.Rows)
                    {
                        حالات_المهمات newCase = new حالات_المهمات()
                        {
                            رمز_الحالة = int.Parse(row["رمز_الحالة"].ToString()),
                            الرمز_الشهري = int.Parse(row["الرمز_الشهري"].ToString()),
                            رمز_السنوي = int.Parse(row["رمز_السنوي"].ToString()),
                            السنة = int.Parse(row["السنة"].ToString())
                        };
                        entity.حالات_المهمات.Add(newCase);
                        entity.SaveChanges();
                    }

                    added = true;
                    return added;
                }
                catch
                {
                    added = false;
                    return added;
                }
            };

        }


        // get  أقسام المستشفى(column names ="اسم_القسم","الرمز","تحويلة_القسم","الطابق")
        public static DataTable Get_أقسام_المستشفى(int hospitalID)
        {

            using (ERCEntities entity = new ERCEntities())
            {
                DataTable dt = new DataTable();
                var c = (from r in entity.المستشفيات_مع_اقسام.AsEnumerable()
                         select new
                         {
                             الرمز = r.أقسام_المستشفيات.الرمز,
                             اسم_القسم = r.أقسام_المستشفيات.اسم_القسم,
                             تحويلة_القسم = r.تحويلة_القسم,
                             الطابق = r.الطابق
                         });
                //creating columns
                dt.Columns.Add("الرمز", typeof(int));
                dt.Columns.Add("اسم_القسم", typeof(string));
                dt.Columns.Add("تحويلة_القسم", typeof(string));
                dt.Columns.Add("الطابق", typeof(int));
                DataRow dr;

                //creating rows

                foreach (var k in c)
                {
                    dr = dt.NewRow();
                    dr["الرمز"] = k.الرمز;
                    dr["اسم_القسم"] = k.اسم_القسم;
                    dr["تحويلة_القسم"] = k.تحويلة_القسم;
                    dr["الطابق"] = k.الطابق;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        //Add member team to a mission
        public static bool add_Mission_Memeber(الفريق mission_member)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
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
            using (ERCEntities entity = new ERCEntities())
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
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    if (entity.من.Count((r => r.من1 == regionID && r.مستشفى_منطقة == false)) == 0)
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
            using (ERCEntities entity = new ERCEntities())
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
        public static int Get_from_Hospital_Section(int hosID, int secID)
        {
            int rep;
            int hos_secID;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    hos_secID = entity.المستشفيات_مع_اقسام.Where((r => r.رمز_المشفى == hosID && r.رمز_القسم == secID)).Select(r => r.الرمز).FirstOrDefault();

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
            using (ERCEntities entity = new ERCEntities())
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


        // get العامل name by id and center id
        public static string Get_العامل_name_byid(int Employee_id, int centerID)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                string name;
                try
                {
                    name = entity.العاملون.Where(r => (r.الرمز == Employee_id && r.المركز == centerID)).Select(r => r.الاسم).Single();
                }
                catch
                {
                    name = "Not founded";
                }
                return name;
            };
        }


        public static bool delete_Mission_Team_Cases(int الرمز_الشهري, int رمز_السنوي, int السنة, int رمز_المركز)
        {
            bool delete1, delete2, delete3, delete;
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


        public static IEnumerable Get_Missions(int? year, int? month, int? center, int? caseType, int? volunteer, int? car, int? patient)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                if (volunteer == null)
                {
                    var c = from missions in entity.المهمات_المنفذة
                            where (
                            ((year == null && missions.السنة != -1) || (year != null && missions.السنة == year)) &&
                            ((month == null && missions.التاريخ.Value.Month != -1) || (month != null && missions.التاريخ.Value.Month == month)) &&
                            ((center == null && missions.رمز__المركز != -1) || (center != null && missions.رمز__المركز == center)) &&
                            ((caseType == null && missions.نوعية_الحالة != -1) || (caseType != null && missions.نوعية_الحالة == caseType)) &&
                            ((car == null && missions.الآلية != -1) || (car != null && missions.الآلية == car)) &&
                            ((patient == null && missions.المريض != -1) || (patient != null && missions.المريض == patient))
                            )
                            select new
                            {
                                missions.الرمز_الشهري,
                                missions.رمز_السنوي,
                                missions.رمز__المركز,
                                missions.طبيعة_المهمة1.طبيعة_المهمة1,
                                patient = missions.المرضى.اسم,
                                employee1 = missions.العاملون.الاسم,
                                employee2 = missions.العاملون1.الاسم,
                                missions.رقم_المتصل,
                                missions.اسم_المتصل,
                                doctor = missions.الأطباء.اسم,
                                missions.الآلية,
                                missions.التاريخ,
                                missions.مريض_مقعد,
                                missions.نوعية_الحالة,

                            };
                    return c.ToList();
                }
                else
                {
                    var c = from missions in entity.الفريق
                            where (
                            ((year == null && missions.المهمات_المنفذة.السنة != -1) || (year != null && missions.المهمات_المنفذة.السنة == year)) &&
                            ((month == null && missions.المهمات_المنفذة.التاريخ.Value.Month != -1) || (month != null && missions.المهمات_المنفذة.التاريخ.Value.Month == month)) &&
                            ((center == null && missions.رمز__المركز != -1) || (center != null && missions.رمز__المركز == center)) &&
                            ((caseType == null && missions.المهمات_المنفذة.نوعية_الحالة != -1) || (caseType != null && missions.المهمات_المنفذة.نوعية_الحالة == caseType)) &&
                            ((car == null && missions.المهمات_المنفذة.الآلية != -1) || (car != null && missions.المهمات_المنفذة.الآلية == car)) &&
                            ((patient == null && missions.المهمات_المنفذة.المريض != -1) || (patient != null && missions.المهمات_المنفذة.المريض == patient)) &&
                            ((missions.رمز_العامل == volunteer))

                            )
                            select new
                            {
                                missions.الرمز_الشهري,
                                missions.رمز_السنوي,
                                missions.رمز__المركز,
                                missions.المهمات_المنفذة.طبيعة_المهمة1.طبيعة_المهمة1,
                                patient = missions.المهمات_المنفذة.المرضى.اسم,
                                employee1 = missions.المهمات_المنفذة.العاملون.الاسم,
                                employee2 = missions.المهمات_المنفذة.العاملون1.الاسم,
                                missions.المهمات_المنفذة.رقم_المتصل,
                                missions.المهمات_المنفذة.اسم_المتصل,
                                doctor = missions.المهمات_المنفذة.الأطباء.اسم,
                                missions.المهمات_المنفذة.الآلية,
                                missions.المهمات_المنفذة.التاريخ,
                                missions.المهمات_المنفذة.مريض_مقعد,
                                missions.المهمات_المنفذة.نوعية_الحالة,

                            };
                    return c.ToList();
                }
            };
        }


        // count mission by month
        public static int Count_Missions(int month, int year)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    // int mon;
                    // if mounth==null mon=-1 else mon=mounth
                    int rep = entity.المهمات_المنفذة
                        .Where(r => r.التاريخ.Value.Month == month && r.السنة == year)
                       .Count()
                    ;
                    return rep;
                }
                catch
                {
                    return -1;
                }
            };
        }


        public static DataTable MissionsInYearByMonth(int year)
        {
            DataTable dt = new DataTable(); ;
            DataRow dr;
            //creating columns
            dt.Columns.Add("Month", typeof(int));
            dt.Columns.Add("Missions Number", typeof(int));
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    dr = dt.NewRow();
                    dr["Month"] = i;
                    dr["Missions Number"] = Count_Missions(i, year);
                    dt.Rows.Add(dr);
                }
            }
            catch { }
            return dt;
        }





    }

    class Hospital
    {

        // get hospital info(column names ="اسم_المستشفى","الرمز","الهاتف","الملاحظات")
        public static DataTable Get_Info_Hospital()
        {
            DataTable dt = new DataTable();
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from h in entity.المستشفيات
                select new
                {
                    h.رمز_المستشفى,
                    h.اسم_المستشفى,
                    h.الهاتف,
                    h.الملاحظات,
                    h.الحالة
                }
                    ); //creating columns
                dt.Columns.Add("رمز_المستشفى", typeof(int));
                dt.Columns.Add("اسم_المستشفى", typeof(string));
                dt.Columns.Add("الهاتف", typeof(string));
                dt.Columns.Add("الملاحظات", typeof(string));
                dt.Columns.Add("الحالة", typeof(string));
                DataRow dr;
                //creating rows
                foreach (var k in c)
                {
                    dr = dt.NewRow();
                    dr["رمز_المستشفى"] = k.رمز_المستشفى;
                    dr["اسم_المستشفى"] = k.اسم_المستشفى;
                    dr["الهاتف"] = k.الهاتف;
                    dr["الملاحظات"] = k.الملاحظات;
                    dr["الحالة"] = k.الحالة;
                    dt.Rows.Add(dr);
                }
                return dt;
            };
        }


        // get  أقسام المستشفى(column names ="اسم_القسم","الرمز","تحويلة_القسم","الطابق")
        public static DataTable Get_أقسام_المستشفى(int hospitalID)
        {

            using (ERCEntities entity = new ERCEntities())
            {
                DataTable dt = new DataTable();
                var c = (from r in entity.المستشفيات_مع_اقسام.AsEnumerable()
                         where r.رمز_المشفى == hospitalID
                         select new
                         {
                             الرمز = r.أقسام_المستشفيات.الرمز,
                             اسم_القسم = r.أقسام_المستشفيات.اسم_القسم,
                             تحويلة_القسم = r.تحويلة_القسم,
                             الطابق = r.الطابق
                         });
                //creating columns
                dt.Columns.Add("الرمز", typeof(int));
                dt.Columns.Add("اسم_القسم", typeof(string));
                dt.Columns.Add("تحويلة_القسم", typeof(string));
                dt.Columns.Add("الطابق", typeof(int));
                DataRow dr;
                //creating rows
                foreach (var k in c)
                {
                    dr = dt.NewRow();
                    dr["الرمز"] = k.الرمز;
                    dr["اسم_القسم"] = k.اسم_القسم;
                    dr["تحويلة_القسم"] = k.تحويلة_القسم;
                    dr["الطابق"] = k.الطابق;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }



        // add Patient with return id
        public static int add_Patient(المرضى new_patient)
        {
            int newID;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    entity.المرضى.Add(new_patient);
                    entity.SaveChanges();
                    newID = new_patient.الرمز;
                    return newID;
                }
                catch (Exception ex)
                {
                    return 00;//error
                }
            };

        }


        // Update hospital from datarow
        public static void UpdateHospitalStatus(DataRow HospitalRow)//I need the id
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




        // check if patient exist
        public static bool Check_Patient(int patientID)
        {
            int rep;
            bool e;
            using (ERCEntities entity = new ERCEntities())
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




        //get all Hospitals
        public static IEnumerable Get_Hospitals()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = from hospitals in entity.المستشفيات
                        select new
                        {
                            hospitals.رمز_المستشفى,
                            hospitals.اسم_المستشفى,
                            hospitals.الهاتف,
                            hospitals.المناطق.المدن.المدينة,
                            hospitals.المناطق.المنطقة,
                            hospitals.العنوان,
                            hospitals.الطابق_السفلي,
                            hospitals.الطابق_العلوي
                        };

                return c.ToList();
            };
        }

    }
    class Employees
    {


        //get all employees 
        public static IEnumerable Get_Employees()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = from employees in entity.العاملون
                        select new
                        {
                            employees.الرمز,
                            employees.الاسم,
                            employees.اللقب,
                            employees.مكان_السجل,
                            employees.رقم_السجل,
                            employees.الجنسية,
                            employees.اسم_الأم,
                            employees.تاريخ_الولادة,
                            employees.تاريخ_الانتساب,
                            employees.البريد,
                            employees.الوظيفة1.الوظيفة1,
                            employees.الدوام,
                            employees.فئة_الدم1.فئة_الدم1,
                            employees.المناطق.المدن.المدينة,
                            employees.المناطق.المنطقة,
                            employees.العنوان,
                            employees.مسعف_أو_مساعد,
                            employees.مسؤول_مهمة_أو_لا,
                            employees.سائق_أو_لا
                        };

                return c.ToList();
            };
        }



    }
}