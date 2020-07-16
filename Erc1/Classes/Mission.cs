﻿using System;
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


        // get Department(column names ="اسم_القسم","الرمز")
        public static IEnumerable Get_أقسام_المستشفيات()
        {
            using (ERCEntities entity = new ERCEntities())
            {
                var c = (
             from department in entity.أقسام_المستشفيات
             select new
             {
                 department.الرمز,
                 department.اسم_القسم
             }); ;
                return c.ToList();
            }
        }

        // add department
        public static int add_Department(string dep)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    أقسام_المستشفيات NewDep = new أقسام_المستشفيات();
                    NewDep.اسم_القسم = dep;
                    entity.أقسام_المستشفيات.Add(NewDep);
                    entity.SaveChanges();
                    newID = NewDep.الرمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }



        // add Employee
        public static int add_Employee(العاملون employee)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.العاملون.Add(employee);
                    entity.SaveChanges();
                    newID = employee.الرمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }



        // add doctor
        public static int add_doctor(الأطباء doctor)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.الأطباء.Add(doctor);
                    entity.SaveChanges();
                    newID = doctor.رمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };
        }



        // add center
        public static int add_center(المراكز center)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.المراكز.Add(center);
                    entity.SaveChanges();
                    newID = center.الرمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }



        // add Insurance
        public static int add_insurance(الجهات_الضامنة insurance)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.الجهات_الضامنة.Add(insurance);
                    entity.SaveChanges();
                    newID = insurance.الرمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }


        // add Region
        public static int add_region(string region,int city)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    المناطق r = new المناطق();
                    r.المنطقة = region;
                    r.المدينة = city;
                    entity.المناطق.Add(r);
                    entity.SaveChanges();
                    newID = r.رمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }


        // add Disease type
        public static int add_disease(string diseaseType)
        {
            int newID;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    نوعيات_الحالات r = new نوعيات_الحالات();
                    r.النوعية = diseaseType;
                    entity.نوعيات_الحالات.Add(r);
                    entity.SaveChanges();
                    newID = r.رمز;
                    return newID;
                }
                catch
                {
                    return -1;//error
                }
            };

        }













        //Add Hospital
        public static bool add_Hospital(المستشفيات new_hospital)
        {
            bool ok;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    entity.المستشفيات.Add(new_hospital);
                    entity.SaveChanges();
                    ok = true;
                }
                catch
                {
                    ok = false;
                }
                return ok;
            };
        }

        // check if Hospital exist
        public static bool Check_hospital(int HospitalID)
        {
            int rep;
            bool e;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    rep = entity.المستشفيات
                      .Where(r => r.رمز_المستشفى == HospitalID)
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

        //Get hospital info
        public static المستشفيات Get_hospital_INFO(int HospitalID)
        {
            المستشفيات hos;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    hos = entity.المستشفيات
                      .Where(r => r.رمز_المستشفى == HospitalID).FirstOrDefault();
                    return hos;
                }
                catch
                {
                    return null;
                }
            };
        }

        // get city by region id
        public static int Get_city_by_regionID(int regionID)
        {
            using (ERCEntities entity = new ERCEntities())
            {
                int city;
                try
                {
                    city = entity.المناطق.Where(r => r.رمز == regionID).Select(r => r.المدينة).Single();
                }
                catch
                {
                    city =-1;
                }
                return city;
            };
        }

        //// change hospital status from id
        //public void UpdateHospital(المستشفيات hos)
        //{
        //    using (ERCEntities entity = new ERCEntities())
        //    {
        //        المستشفيات c = new المستشفيات();
        //        int id = HospitalRow["رمز_المستشفى"].ToString());
        //        c = entity.المستشفيات.First(r => r.رمز_المستشفى == id);
        //        c.الحالة = HospitalRow["الحالة"].ToString();
        //        c.الملاحظات = HospitalRow["الملاحظات"].ToString();
        //        entity.SaveChanges();
        //    };
        //}


        //Add or update HospitalDepartment
        public static bool addOrUpdate_HospitalDepartment(DataTable new_Hospital_Dep, int hosID)
        {
            bool added = false;
            using (ERCEntities entity = new ERCEntities())
            {
                try
                {
                    foreach (DataRow row in new_Hospital_Dep.Rows)
                    {
                        المستشفيات_مع_اقسام newDep = entity.المستشفيات_مع_اقسام.Where((r => r.رمز_المشفى == hosID && r.رمز_القسم == int.Parse(row["الرمز"].ToString()))).FirstOrDefault();
                        if (newDep != null)
                        {
                            newDep.رمز_القسم = int.Parse(row["الرمز"].ToString());
                            newDep.تحويلة_القسم = row["تحويلة_القسم"].ToString();
                            newDep.الطابق = short.Parse(row["الطابق"].ToString());
                            entity.SaveChanges();
                        }
                        else
                        {
                            newDep = new المستشفيات_مع_اقسام()
                            {
                                رمز_المشفى = hosID,
                                رمز_القسم = int.Parse(row["الرمز"].ToString()),
                                تحويلة_القسم = row["تحويلة_القسم"].ToString(),
                                الطابق = short.Parse(row["الطابق"].ToString())
                            };
                            entity.المستشفيات_مع_اقسام.Add(newDep);
                            entity.SaveChanges();
                        }
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



        //Add HospitalDepartment
        public static bool add_HospitalDepartment(DataTable new_Hospital_Dep,int hosID)
        {
            bool added = false;
            using (ERCEntities entity = new model.ERCEntities())
            {
                try
                {
                    foreach (DataRow row in new_Hospital_Dep.Rows)
                    {
                        المستشفيات_مع_اقسام newDep = new المستشفيات_مع_اقسام()
                        {
                            رمز_المشفى = hosID,
                            رمز_القسم = int.Parse(row["رمز_القسم"].ToString()),
                            تحويلة_القسم = row["تحويلة_القسم"].ToString(),
                            الطابق = short.Parse(row["الطابق"].ToString())
                        };
                        entity.المستشفيات_مع_اقسام.Add(newDep);
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




        // add to row if 0 in mustashfa/aksem  else if 1 in manate2

        //get mustashfa ma3 aksem id

        // add role (admin)



        // bool if to or from is present

        // get max

        // car


    }
}
