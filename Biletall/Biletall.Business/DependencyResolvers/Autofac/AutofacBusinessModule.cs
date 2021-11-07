using Autofac;
using Autofac.Extras.DynamicProxy;
using Biletall.Business.Abstract;
using Biletall.Business.Concrete;
using Castle.DynamicProxy;
using Biletall.DataAccess.Abstract;
using Biletall.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletall.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfTodoDal>().As<ITodoDal>();
            builder.RegisterType<TodoManager>().As<ITodoService>();


            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                //.EnableInterfaceInterceptors(new ProxyGenerationOptions()
                //{
                //    Selector = new AspectInterceptorSelector()
                //})
                .SingleInstance();


        }
    }
}
