using ProjeWebApi.Application.Feature.Products.Command.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Interface.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
        //Burada verilerin menbe nesnesini Hedef nesneye dönüştüren bir yapıdır.
        //ignore ise nullable olaraq ayarlanmışdır, çünki bize lazım olmayan veriler burada saxlanılır.
        //ve Opsiyonel olaraq tanımlanan bir parametredir.

        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null);
        //Bu metod, bir liste içindeki her verini tanımlanan hedef tipine dönüştürmek üçün istifade edilir.. 
        // Nümune olaraq: List<Person> tipindeki ve  bir liste içindeki
        // her Person verisini PersonDto tipine dönüştürmek üçün istifade edilir.


        TDestination Map<TDestination>(object source, string? ignore = null);
        // Nümune: Bir Person nesnesini PersonDto adlı bir veri transfer nesnesine dönüştürmek üçün istifade edilir

        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);
        TDestination Map<TSource, TDestination>(TSource source);
        object Map<T1, T2>(CreateProductCommandRequest request);
        //Nümune: List<Person> türündeki bir liste içindeki her Person verisini PersonDto tipine dönüştürmek üçün istifade edilir. 


    }
}
