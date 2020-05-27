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
                            centers = centers.الرمز ,// + " - " + centers.المدن.المدينة,
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
                        .Where(r => (r.التاريخ.Value.Year == year) && (r.التاريخ.Value.Month == month) )
                        .Max(r => r.الرمز_الشهري)
                        ;
                    c += 1;
                }
                catch(Exception ex)
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
                catch(Exception ex)
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


    }
}