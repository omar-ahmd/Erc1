using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;


namespace Erc1.DAL
{
    class mission
    {


        //// get المراكز id (column name ="الرمز")
        //public static IEnumerable Get_CentersId()
        //{
        //    using (var entity = new ERCEntities3())
        //    {
        //        var c = entity.المراكز.Select(r =>new { r.الرمز });
        //        return c.ToList();
        //    }
        //}



        // get الحالات names (column names ="المرض","رمز")
        public static IEnumerable Get_الحالات()
        {
            using (ERCEntities3 entity = new ERCEntities3())
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
            using (var entity = new ERCEntities3())
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
            using (var entity = new ERCEntities3())
            {
                var c = entity.نوعيات_الحالات;
                return c.ToList();
            }
        }




        // get العاملون names (column names ="الاسم","الرمز")
        public static IEnumerable Get_العاملون()
        {
            using (ERCEntities3 entity = new ERCEntities3())
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
            using (ERCEntities3 entity = new ERCEntities3())
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





        //get all centers (column names ="centers","id")
        public static IEnumerable Get_Centers()
        {
            using (ERCEntities3 entity = new ERCEntities3())
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




        // cars of a center by id 
        public static IEnumerable Getالآليات(int marakez)
        {

            using (ERCEntities3 entity = new ERCEntities3())
            {
                var c = (
                from cars in entity.الآليات
                where cars.المركز == marakez
                select new
                {
                    id = cars.رمز_الآلية,
                    cars = cars.موديل_
                }
                    ); 
                return c.ToList();
            };

        }
    }
}
