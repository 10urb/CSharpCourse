﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 4));

            var type = typeof(DortIslem);
            //DortIslem dortIslem = (DortIslem)  Activator.CreateInstance(type, 6,7);
            //Console.WriteLine( dortIslem.Topla(4, 5));
            // Console.WriteLine(dortIslem.Topla2());


            var instance = Activator.CreateInstance(type, 6, 7);
           MethodInfo methodInfo= instance.GetType().GetMethod("Topla2");
            
            Console.WriteLine(methodInfo.Invoke(instance,null));
            Console.WriteLine("---------");
           
            var metodlar = type.GetMethods();
            foreach (var info in metodlar)
            {
                Console.WriteLine("Metod adı : {0}", info.Name);
                foreach (var parameterInfo   in info.GetParameters())
                {
                    Console.WriteLine("Parametre  : {0}", parameterInfo);
                }
                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute name  : {0}", attribute.GetType().Name);
                }
            }

            Console.ReadLine();
        }
    }
    public class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {

        }
        public int Topla(int sayi1 = 1, int sayi2 = 2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1 = 1, int sayi2 = 2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }

    }
    public class MethodNameAttribute : Attribute
    {
        public MethodNameAttribute(string name)
        {

        }
    }
}
