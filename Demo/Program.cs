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
        //�� ������ �� ��������� ����� ��� ������ ����� ����� �� ��
        //2 types :
        //1-Loosly Coupled :
        //�� ����� �� ��������� ������ ������ ���� ��� ������ ����� 
        //��� �� ��� ��� ������� ��� ��� ������ DepartmentRep���� ���� �� ���� ��� ��
        //��������� �� ������ ����� ������ DepartmentRep���� ����� ��� ������ ���� ��� ���
        //impelement �����  DepartmentRep ����� �� interface �����  DepartmentRep� ��� �� ���� ������
        //DepartmentRep��� ��� ���� �� ����� � �� interface ���� ��� ��� ������� ����� �� ��
        //instance ������ � �� 

        //2-Tightly Coupled
        //�� ��������� ������ ��� ������ ������ ��� ...��� ��� ������ ��� ������
        //��� ��� ���� ���� ����� ��� ������� ��� ���

        //startup=>ConfigureServices, DepartmentController ,DepartmentRep �� ��� ������
        //ConfigureServices=> Loosly Coupled�� �������� ��� ���� ���� �� ������� ��� ��� ������ ��

        //Loosly Coupled types:
        //1- Transient (One Instance For Every Operation)
        //Operation �� ��� ��� ���� ������� ��� 
        //services.AddTransient<IDepartmentRep,DepartmentRep>();

        //2- Scoped (One Intance For Each User For All Operations)
        //Operations���� �� User�� ��� ��� ���� ������ ��� 
        //services.AddScoped<IDepartmentRep, DepartmentRep>();

        //3-SingleTone  (One Instance For All Users)
        //Users �� ��� ��� ���� ������� ��� �� 
        //services.AddSingleton<IDepartmentRep, DepartmentRep>();

        //��� ��� ���� ��� business������ �� ����� ���� ����� ��� ��

        //----------------------------------------------------------------------

        //Enhancement connection string
        //��� ��� ���� ���� ��������� connection string ��� ��� ���� ���� ��
        //����� ��� dbcontext��� ����� ��  demoContext ���� ������ � ���� �� 
        //��� ���� ������ ���� ����� dll�� ������ �  demo.DAL���� �� publish�� �� �� ����� ...�� ��� ���� ����� 
        //� connection string ��� ���� ���� ��� �������� ���� �� ����� ..����� ���� ��
        //demo.DAL,demo.BL  ���� ��� ��� ���� ���� ��� ���� ���� ��� �� demo��� ��� ����� ��� ��  appsetting���� ��
        //class liberary ���� �� ������ ����� �� ���  demo������  dll��� ������� �
    }
}
