using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //dependency injection
        //Ïí İßÑÊåÇ Çä ÇáÇæÈÌíßÊ ãÚÊãÏ Úáì ÇáßáÇÓ ÈÊÇÚæ ÈäÓÈå ÇÏ Çí
        //2 types :
        //1-Loosly Coupled :
        //ÏÇ İßÑÊæ Çä ÇáÇæÈÌíßÊ ÈíÚÊãÏ ÇÚÊãÇÏ ÌÒÆí Úáì ÇáßáÇÓ ÈÊÇÚæ 
        //åäÇ áæ ÎÏÊ ãäæ ÇæÈÌíßÊ Úáì Øæá æÈÚÏíä DepartmentRepíÚäí ãËáÇ áæ ÚäÏì åäÇ Çá
        //ÇáÇæÈÌíßÊ ÏÇ åíÊÃËÑ æíÍÕá ÇíÑæÑÒ DepartmentRepÚãáÊ ÊÚÏíá Úáì ÇáßáÇÓ äİÓæ Çáì åæÇ
        //impelement íÚãáæ  DepartmentRep æÇÎáí Çá interface ÈÚãáæ  DepartmentRepİ ÇäÇ áæ ÚÇíÒ ÇÓÊÎÏã
        //DepartmentRepÚáì Øæá ÈÍíË Çì ÊÚÏíá İ Çá interface æÇäÇ áãÇ ÇÎÏ ÇæÈÌíßÊ åÇÎÏæ ãä Çá
        //instance ãíÃËÑÔ İ Çá 

        //2-Tightly Coupled
        //ÏÇ ÇáÇæÈÌíßÊ ÈíÚÊãÏ Úáì ÇáßáÇÓ ÇÚÊãÇÏ ßáì ...Çáì åæÇ ÇáÚÇÏì Çáí ÈäÚãáæ
        //Çáì åæÇ ÈÚãá ßáÇÓ æÈÇÎÏ ãäæ ÇæÈÌíßÊ Úáì Øæá

        //startup=>ConfigureServices, DepartmentController ,DepartmentRep ÈÕ Úáì İÇíáÇÊ
        //ConfigureServices=> Loosly CoupledÏì ÇáİÇäßÔä Çáì åÇÎÏ İíåÇ Çì ÇæÈÌíßÊ ÈÚÏ ßÏÇ ÈØÑíŞå Çá

        //Loosly Coupled types:
        //1- Transient (One Instance For Every Operation)
        //Operation ÏÇ Çáì åæÇ ÈÇÎÏ ÇæÈÌíßÊ áßá 
        //services.AddTransient<IDepartmentRep,DepartmentRep>();

        //2- Scoped (One Intance For Each User For All Operations)
        //Operationsæáßá Çá UserÏÇ Çáì åæÇ ÈÇÎÏ ÇæÌíßÊ áßá 
        //services.AddScoped<IDepartmentRep, DepartmentRep>();

        //3-SingleTone  (One Instance For All Users)
        //Users ÏÇ Çáì åæÇ ÈÇÎÏ ÇæÈÌíßÊ áßá Çá 
        //services.AddSingleton<IDepartmentRep, DepartmentRep>();

        //Çáì ÇäÇ ÔÛÇá İíå businessÈÓÊÎÏã Çì ØÑíŞå ãäåã ÈäÇÆÇ Úáì Çá

        //----------------------------------------------------------------------

        //Enhancement connection string
        //Çáì åíÇ ÈÈäí ÈíåÇ ÇáÏÇÊÇÈíÒ connection string áãÇ ßäÊ ÇÚæÒ ÇÚãá Çá
        //æÍæÇÑ ßÏÇ dbcontextÇáì ÈíæÑË ãä  demoContext İßäÊ ÈßÊÈåÇ İ ßáÇÓ Çá 
        //æÏì ÍÇÌå ãíäİÚÔ ÇÚÏá ÚáíåÇ dllÏÇ ÈíÊÍæá á  demo.DALİÇíá Çá publishÈÓ ÏÇ áì ãÔßáå ...Çä ÇäÇ æÇäÇ æÈÚãá 
        //İ connection string İáæ ÌÈíÊ ÇÛíÑ ÇÓã ÇáÓíÑİíÑ ãËáÇ ãÔ åíäİÚ ..İŞÇáß ÇßÊÈ Çá
        //demo.DAL,demo.BL  æßÏÇ áãÇ ÇÍÈ ÇÚÏá åÚÏá İíå åÚÑİ ÇÚÏá áÇä Çá demoåæÇ ÇäÇ ÈäÒáæ ÌæÇ Çá  appsettingİÇíá Çá
        //class liberary äİÓæ ãÔ ÈíÊÍæá áÇäåã ãä äæÚ  demoÇäãÇÇá  dllÏæá ÈíÊÍæáæ á
    }
}
