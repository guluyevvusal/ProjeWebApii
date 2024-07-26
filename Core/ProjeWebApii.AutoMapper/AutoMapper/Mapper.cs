﻿using AutoMapper;
using AutoMapper.Internal;
using ProjeWebApi.Application.Interface.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IMapper = AutoMapper.IMapper;

namespace ProjeWebApii.Mapper.AutoMapper
{
    public class Mapper : ProjeWebApi.Application.Interface.AutoMapper.IMapper

    {
        public static List<TypePair> typePairs = new();

        private IMapper MapperContainer;



        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);

            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);

            return (IList<TDestination>)MapperContainer.Map<IList<TDestination>>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            throw new NotImplementedException();
        }

        protected void Config<TDestionation, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestionation));


            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)

                return;

            typePairs.Add(typePair);


            var config = new MapperConfiguration(cfg =>

            {
                foreach (var item in typePairs)
                {
                    if(ignore is not null)

                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x=>x.Ignore()).ReverseMap();
                
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();


                }

            });

            MapperContainer = config.CreateMapper();
        }
    }
}