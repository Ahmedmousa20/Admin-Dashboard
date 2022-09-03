using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string LocalPath  ,IFormFile File )
        {

            try
            {
                // 1 ) Get Directory
                string FilePath = Directory.GetCurrentDirectory() + LocalPath;
                //GetCurrentDirectory() ==> بتجيب المسار بتاع البروجيكت بتاعيى الى انا واقف فيه
                //LocalPath ف بضيف المسار بتاعو الى هوا هنا wwwrootف انا كدا عايز احفظ الملف ف ال

                //2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
                //الخطوه دى بتضيف للملف رقم مميز لان ممكن اضيف ملف يبقا اسمو موجود عندى قبل كدا
                //على الملف الى موجود ف دا غلط...عشان كدا بضيف رقم مميز عشان  override فهيروح يعمل
                //دا override اتجنب موضوع ال
                //Guid.NewGuid()==>بتجيب رقم مميز عشوائي

                // 3) Merge Path with File Name
                string FinalPath = Path.Combine(FilePath, FileName);
                //هنا بجمع المسار الى هحط فيه الملف مع اسم الملف 
                //Path.Combine ==> /دى بتعمل دمج بين المسارات وبتشيل ال, وتحط

                //4) Save File As Streams "Data Overtime"
                //دى الخطوه الى بحفط فيها الملف ف المسار النهائي بتاعى
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }
                return FileName;
            }catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public static string RemoveFile(string LocalPath , string FileName)
        {
            try
            {
                string DeletedPath = Directory.GetCurrentDirectory() + LocalPath + FileName;
                if (System.IO.File.Exists(DeletedPath))
                {
                    System.IO.File.Delete(DeletedPath);
                }
                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
