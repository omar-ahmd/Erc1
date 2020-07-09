using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erc1.model;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Data.Linq;
using System.Windows.Documents;

namespace Erc1.Classes
{

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
                    where hospital.[رمز المستشفى] =" + hospital_key + "sections");
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
            }
            return table;
        }

        public static IEnumerable center()
        {
            using (var entity = new ERCEntities())
            {
                try
                {
                    var c = (
                  from center in entity.المراكز
                  select new
                  {
                      center.الرمز
                  }
                      ); ;
                    return c.ToList();
                }
                catch {
                    var c = "".ToList();//try catch barra kermel combobox

                    return c;
                }
            };
        }

        public static DataTable Get_center_DATALAYER()
        {
            DataLayer dt;
            DataTable centers;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
            centers = dt.GetData("select الرمز from المراكز ", "centers");
            return centers;
        }



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
        public static int Get_MonthlyID(int year, int month)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c;
                try
                {
                    c = entity.المهمات_المنفذة
                      .Where(r => r.التاريخ.Value.Year == year && r.التاريخ.Value.Month == month && r.الرمز_الشهري == entity.المهمات_المنفذة.Max(p => p.الرمز_الشهري))
                      .Select(r => r.الرمز_الشهري).Single()
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


        // get yearid 
        public static int Get_YearID(int year)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int c;
                try
                {
                    c = entity.المهمات_المنفذة
                   .Where(r => r.التاريخ.Value.Year == year && r.رمز_السنوي == entity.المهمات_المنفذة.Max(p => p.رمز_السنوي))
                   .Select(r => r.رمز_السنوي).Single()
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
                    .Select(r => new { r.رمز,
                        المرض = r.المرض_بالانجليزي + " - " + r.المرض });
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
            string c = dt.GetValue("select الرمز from المرضى where اسم = '" +
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
            city = dt.GetData("select * from المدن", "city");
            return city;
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

        public static DataTable Get_المناطق_DATALAYER(int city_key)
        {
            DataLayer dt;
            DataTable region;
            dt = new DataLayer(@"QSC-2019\SQLEXPRESS", "ERC");
            region = dt.GetData("select رمز,المنطقة from المناطق where المدينة='" +
                city_key.ToString() + "'", "region");
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
                    where hospital.[رمز المستشفى] =" + hospital_key, "sections");
            return sections;
        }



        // get الأطباء by hospitalID (column names ="رمز","اسم")
        public static IEnumerable Get_الأطباء(int hospital_key)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from doctors in entity.الأطباء
             where doctors.مكان_العمل == hospital_key
             select new
             {
                 doctors.رمز,
                 doctors.اسم
             }); ;
                return c.ToList();
            }
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










        // add mission


        public static bool add_Mission(المهمات_المنفذة new_Mission)
        {
            bool added = false;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.المهمات_المنفذة.Add(new_Mission);
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


        public static bool add_Mission(المهماة_المؤجلة new_Mission)
        {
            bool added = false;
            using (ERCEntities entity = new model.ERCEntities())
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
            using (ERCEntities entity = new model.ERCEntities())
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
            using (ERCEntities entity = new model.ERCEntities())
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

    class hospitals
    {
        // get hospital info(column names ="اسم_المستشفى","الرمز","الهاتف")
        public static IEnumerable Get_Info_Hospital(int hospitalID)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from h in entity.المستشفيات
                where (h.رمز_المستشفى == hospitalID)
                select new
                {
                    h.رمز_المستشفى,
                    h.اسم_المستشفى,
                    h.الهاتف,
                    h.الملاحظات
                }
                    ); ;
                return c.ToList();
            };
        }


        // get  أقسام المستشفى(column names ="اسم_القسم","الرمز","تحويلة_القسم","الطابق")
        public static IEnumerable Get_أقسام_المستشفى(int hospitalID)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
                from h in entity.المستشفيات_مع_اقسام
                where (h.رمز_المشفى == hospitalID)
                select new
                {
                    h.أقسام_المستشفيات.الرمز,
                    h.أقسام_المستشفيات.اسم_القسم,
                    h.تحويلة_القسم,
                    h.الطابق
                }
                    ); ;
                return c.ToList();
            };
        }


        public static DataTable Get_1أقسام_المستشفى(int hospitalID) {
            
            using (ERCEntities entity = new ERCEntities())
            {
                DataTable dt = new DataTable();
                var c = (from r in entity.المستشفيات_مع_اقسام.AsEnumerable()
                         select new
                         {
                             الرمز = r.أقسام_المستشفيات.الرمز,
                             اسم_القسم= r.أقسام_المستشفيات.اسم_القسم,
                             تحويلة_القسم=  r.تحويلة_القسم,
                             الطابق=r.الطابق
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
                    dr= dt.NewRow();
                    dr["الرمز"] = k.الرمز;
                    dr["اسم_القسم"] = k.اسم_القسم;
                    dr["تحويلة_القسم"] = k.تحويلة_القسم;
                    dr["الطابق"] =k.الطابق;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }



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


        //add team member
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
        public static int Get_from_Hospital_Section(int hosID, int secID)
        {
            int rep;
            int hos_secID;
            using (ERCEntities entity = new model.ERCEntities())
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






        // get العامل name by id
        public static string Get_العامل_name_byid(int Employee_id)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                string name;
                try
                {
                    name = entity.العاملون.Where(r => r.الرمز == Employee_id).Select(r => r.الاسم).Single();
                }
                catch
                {
                    name = "";
                }
                return name;
            };
        }











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


        //DataTable usersTable = new DataTable();

        //usersTable.Columns.Add("رمز المستشفى",typeof(int));
        //    usersTable.Columns.Add("الحالة",typeof(int));
        //    usersTable.Columns.Add("الملاحظات",typeof(DateTime));

        //    DataRow userRow = usersTable.NewRow();
        //DateTime date = new DateTime(2002, 10, 2);
        //userRow["رمز المستشفى"] = 500;
        //    userRow["الحالة"] = 2;
        //    userRow["الملاحظات"] = date;
        //        using (ERCEntities entity = new ERCEntities())
        //        {
        //            المراكز c = new المراكز();
        //DateTime dateValue = Convert.ToDateTime(userRow["الملاحظات"]);
        //int id = int.Parse(userRow["رمز المستشفى"].ToString());
        //c = entity.المراكز.First(r => r.الرمز ==id);
        //            c.المدينة = int.Parse(userRow["الحالة"].ToString());
        //c.تاريخ_التاسيس =dateValue;
        //        entity.SaveChanges();
        //        };
        //}
    }

}