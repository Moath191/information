using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace information.Models
{
    public static class Reg
    {
        //تمثل قاعدة البيانات
        public static List<Store> MyStore = new();

        // البيانات الإفتراضية
        public static Store GetDefultStore()
        {

            return new Store
            {
                Id = 20,
                Name = "معاذ",
                FamilyName = "عبدالرحمن",
                Address = "مكة",
                Age = 25,
                CountryOfOrigin = "السعودية",
                EMailAdress = "a@a.com",
                Hired = false,
            };
        }

        //كل البيانات 
        public static List<Store> GetList()
        {
            return MyStore;
        }

        //إضافة
        public static Store? Create_Sort(Store obj)
        {
            try
            {
                MyStore.Add(obj);
                return obj;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        //تعديل
        public static Store? Update_Sort(int id, Store Up)
        {
            try
            {

                var store_Org = Detalis_Sort(id);
                if (store_Org != null)
                {
                    Console.WriteLine("1------");
                    // store_Org.Name = Up.Name;
                    // store_Org.FamilyName = Up.FamilyName;
                    Delete_Sort(id);
                    Console.WriteLine("2------");

                    Create_Sort(Up);
                    Console.WriteLine("3------");
                    return Up;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //عرض 
        public static Store? Detalis_Sort(int id)
        {
            try
            {
                var store = MyStore.FirstOrDefault(w => w.Id == id);
                return store;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        //حذف
        public static bool Delete_Sort(int id)
        {
            try
            {
                var store = Detalis_Sort(id);
                if (store != null)
                {
                    MyStore.Remove(store);
                    return true;
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }



    }
}