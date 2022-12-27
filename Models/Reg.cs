using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace information.Models
{
    public static class Reg
    {

/// <summary>
/// إضافة خطأ داخل قاعدة البيانات
/// </summary>
/// <param name="db"></param>
/// <param name="ex"></param>
/// <returns></returns>
public static async Task<bool> CreateErr(string location,MyDB db,Exception ex){
try{
string innerMess="";
Exception? Inner=ex.InnerException;
if(Inner!=null){   innerMess= Inner.Message;}

Err err=new () {
    Location=location,
Message=ex.Message,
InnerMessage=innerMess
};
db.Erres.Add(err);
await db.SaveChangesAsync();
return true;
}catch{    return false;}

}



        ////تمثل قاعدة البيانات
        //public static List<Store> MyStore = new();

        //// البيانات الإفتراضية
        //public static Store GetDefultStore()
        //{

        //    return new Store
        //    {
        //        Id = 20,
        //        Name = "معاذ",
        //        FamilyName = "عبدالرحمن",
        //        Address = "مكة",
        //        Age = 25,
        //        CountryOfOrigin = "السعودية",
        //        EMailAdress = "a@a.com",
        //        Hired = false,
        //    };
        //}

        ////كل البيانات 
        //public static List<Store> GetList()
        //{
        //    return MyStore;
        //}

        ////إضافة
        //public static async Task<Store?> Create_Sort(Store obj,MyDB db)
        //{
        //    try
        //    {
        //        MyStore.Add(obj);
        //        return obj;
        //    }
        //   catch (Exception ex)            {await Reg.CreateErr("Reg.Create_Sort",db,ex);            }
        //    return null;
        //}
        ////تعديل
        //public static async Task<Store?> Update_Sort(int id, Store Up,MyDB db)
        //{
        //    try
        //    {

        //        var store_Org = Detalis_Sort(id);
        //        if (store_Org != null)
        //        {
        //            Console.WriteLine("1------");
        //            // store_Org.Name = Up.Name;
        //            // store_Org.FamilyName = Up.FamilyName;
        //            Delete_Sort(id);
        //            Console.WriteLine("2------");

        //           //await Create_Sort(Up,new MyDB());
        //            Console.WriteLine("3------");
        //            return Up;
        //        }
        //    }
        //              catch (Exception ex)            {await Reg.CreateErr("Reg.Update_Sort",db,ex);            }

        //    return null;
        //}

        ////عرض 
        //public static Store? Detalis_Sort(int id)
        //{
        //    try
        //    {
        //        var store = MyStore.FirstOrDefault(w => w.Id == id);
        //        return store;

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
        //    return null;
        //}
        ////حذف
        //public static bool Delete_Sort(int id)
        //{
        //    try
        //    {
        //        var store = Detalis_Sort(id);
        //        if (store != null)
        //        {
        //            MyStore.Remove(store);
        //            return true;
        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
        //    return false;
        //}



    }
}