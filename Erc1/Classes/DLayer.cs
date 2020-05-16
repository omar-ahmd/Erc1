using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erc1.model;
using System.Collections;
using System.Data;
using System.ComponentModel;

namespace Erc1.Classes
{
    class cent 
    
    {
        int key;
      public int Key {
            get;
            set;
        }
    
    }

    class mission
    {

        public static DataTable d(int hospital_key) 
        {
            var table = new DataTable();
            using (var entity = new ERCEntities())
            { 
                
                var cmd = entity.Database.Connection.CreateCommand();
                cmd.CommandText = (@"select kesem.[الرمز] , kesem.[اسم القسم] 
                    from[أقسام المستشفيات] as kesem
                    join[المستشفيات مع اقسام] as hk
                    on kesem.[الرمز] = hk.[رمز القسم]
                    join[المستشفيات] as hospital
                    on hk.[رمز المشفى] = hospital.[رمز المستشفى]
                    where hospital.[رمز المستشفى] =" + hospital_key+ "sections");
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }
   
        //public static IList<cent> center()
        //{ 
        //    using (var entity = new ERCEntities())
        //    {
        //        IList<cent> c;
        //        c = int.Parse(entity.المراكز.Select(r => new { r.الرمز }).ToString()) ;
        //        return c;
        //    }
        //}


        //public static DataTable ConvertToDataTable<T>(IList<T> data)
        //{
        //    PropertyDescriptorCollection properties =
        //        TypeDescriptor.GetProperties(typeof(T));

        //    DataTable table = new DataTable();

        //    foreach (PropertyDescriptor prop in properties)
        //        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        //    foreach (T item in data)
        //    {
        //        DataRow row = table.NewRow();
        //        foreach (PropertyDescriptor prop in properties)
        //        {
        //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //        }
        //        table.Rows.Add(row);
        //    }
        //    return table;
        //}



        //DataTable dt = new DataTable();
        //public static DataTable center()
        //{

        //    using (ERCEntities entity = new ERCEntities())
        //    {
        //        (from center in entity.المراكز.AsEnumerable()
        //         select new
        //         {
        //             id = center.الرمز,
        //             name = center.المدن.المدينة

        //         }).Aggregate(table, (dt, r) =>
        //         {
        //             dt.Rows.Add(r.id, r.Name);
        //             return dt;
        //         });
        //    };

        //}


        //// get المراكز id (column name ="الرمز")
        //public static IEnumerable Get_CentersId()
        //{
        //    using (var entity = new ERCEntities())
        //    {
        //        var c = entity.المراكز.Select(r =>new { r.الرمز });
        //        return c.ToList();
        //    }
        //}


        // get monthlyid 
        public static int Get_MonthlyID()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                 int c = entity.المهمات_المنفذة
                    .Where (r=>r.الرمز_الشهري==entity.المهمات_المنفذة.Max(p=>p.الرمز_الشهري))
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
                            centers = centers.الرمز + " - " + centers.المدن.المدينة,
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
                    ) ; ;
                return c.ToList();
            };
        }

        // get الحالات names by idنوعية_الحالة (column name ="المرض")
        public static IEnumerable Get_الحالات_by_idنوعية_الحالة(int id_type_of_disease)
        {
            using (var entity = new ERCEntities())
            {
                var c = entity.الحالات
                    .Where(r=>r.رمز_النوعية== id_type_of_disease)
                    .Select(r => new { r.رمز,
                        المرض= r.المرض_بالانجليزي +" - "+r.المرض });
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
                Where(r => (r.المركز == center_id  && r.مسعف_أو_مساعد==true))
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
                Where(r => (r.المركز == center_id  && r.سائق_أو_لا == true))
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


        // get المرضى id from name
        public static string Get_المرضى_DATALAYER(string name)
        {
            DataLayer dt;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
            string c=dt.GetValue("select الرمز from المرضى where اسم = '" + 
                name + "'").ToString();
            return c;
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

        public static DataTable Get_المدن_DATALAYER()
        {
            DataLayer dt;
            DataTable city;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
             city = dt.GetData("select * from المدن","city");
            return city;
        }

        // get المناطق names(column names ="المنطقة","رمز")
        public static IEnumerable Get_المناطق(int city_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from p in entity.المناطق
                where p.المدينة==city_key
                select new
                {
                    p.رمز,
                    p.المنطقة
                }
                    ); ;
                return c.ToList();
            };
        }

        public static DataTable Get_المناطق_DATALAYER(int city_key)
        {
            DataLayer dt;
            DataTable region;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
            region = dt.GetData("select رمز,المنطقة from المناطق where المدينة='"+
                city_key.ToString()+"'", "region");
            return region;
        }

        // get المستشفيات(column names ="اسم","الرمز")
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


        // get طوابق المستشفيات (column names ="عدد_الطوابق","رمز_المستشفى")
        public static IEnumerable Get_طوابق_المستشفيات(int hospital_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from h in entity.المستشفيات
                where h.رمز_المستشفى == hospital_key
                select new
                {
                    h.رمز_المستشفى,
                    h.عدد_الطوابق
                }
                    ); ;
                return c.ToList();
            };
        }



        //// get أقسام المستشفيات (column names ="sections_id","sections_name")
        //public static IEnumerable Get_أقسام_المستشفيات(int hospital_key)
        //{
        //    using (ERCEntities entity = new ERCEntities())
        //    {
        //        var c = (
        //     from h_s in entity.المستشفيات_مع_اقسام
        //     from s in entity.أقسام_المستشفيات
        //     where h_s.رمز_المشفى == hospital_key && h_s.رمز_القسم==s.الرمز
        //     select new
        //     { 
        //         sections_id =s.الرمز,
        //         sections_name = s.اسم_القسم
        //     }) ;
        //        return c.ToList();
        //    }
        //}



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

        public static DataTable Get_أقسام_المستشفيات_Datalayer(int hospital_key)
        {
            DataLayer dt;
            DataTable sections;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
            sections = dt.GetData(@"select kesem.[الرمز] , kesem.[اسم القسم] 
                    from[أقسام المستشفيات] as kesem
                    join[المستشفيات مع اقسام] as hk
                    on kesem.[الرمز] = hk.[رمز القسم]
                    join[المستشفيات] as hospital
                    on hk.[رمز المشفى] = hospital.[رمز المستشفى]
                    where hospital.[رمز المستشفى] ="+hospital_key,"sections");
            return sections;
        }









    

        // add mission
        public static void AddMission(int الرمز_الشهري, DateTime التاريخ, int الآلية, int المريض, Nullable<int> من_مشفى, Nullable<int> من_القسم, Nullable<int> الطبيب_المعالج,
             Nullable<int> الجهة_الضامنة, Nullable<int> إلى_مشفى, Nullable<int> إلى_القسم, int مسؤول_المهمة, int مسعف_1, int مسعف_2,
            int السائق, int الهاتف, Nullable<int> متلقي_المهمة, int رمز_الحالة, int رمز_السنوي,
            int السنة, string تفاصيل_ال_من, string تفاصيل_ال_الى, Nullable<int> من_رمز_المدينة, Nullable<int> من_رمز_المنطقة,
            Nullable<int> الى_رمز_المدينة, Nullable<int> الى_رمز_المنطقة, string التفاصيل, string اسم_المتصل,
            int طبيعة_المهمة, int رمز__المركز)
        {
            using (ERCEntities entity = new model.ERCEntities())
            {
                المهمات_المنفذة newmission = new المهمات_المنفذة()
                {
                    الرمز_الشهري = الرمز_الشهري,
                    التاريخ = التاريخ,
                    الآلية = الآلية,
                    المريض = المريض,
                    من_مشفى = من_مشفى,
                    من_القسم = من_القسم,
                    الطبيب_المعالج = الطبيب_المعالج,
                    الجهة_الضامنة = الجهة_الضامنة,
                    إلى_مشفى = إلى_مشفى,
                    إلى_القسم = إلى_القسم,
                    مسؤول_المهمة = مسؤول_المهمة,
                    مسعف_1 = مسعف_1,
                    مسعف_2 = مسعف_2,
                    السائق = السائق,
                    الهاتف = الهاتف,
                    متلقي_المهمة = متلقي_المهمة,
                    رمز_السنوي = رمز_السنوي,
                    السنة = السنة,
                    تفاصيل_ال_من = تفاصيل_ال_من,
                    تفاصيل_ال_الى = تفاصيل_ال_الى,
                    من_رمز_المدينة = من_رمز_المدينة,
                    من_رمز_المنطقة = من_رمز_المنطقة,
                    الى_رمز_المدينة = الى_رمز_المدينة,
                    الى_رمز_المنطقة = الى_رمز_المنطقة,
                    التفاصيل = التفاصيل,
                    اسم_المتصل = اسم_المتصل,
                    طبيعة_المهمة = طبيعة_المهمة,
                    رمز__المركز = رمز__المركز
                };
                entity.المهمات_المنفذة.Add(newmission);
                entity.SaveChanges();
            };
        }

    }
    
}