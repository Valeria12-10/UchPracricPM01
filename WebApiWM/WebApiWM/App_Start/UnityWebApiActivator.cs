using System.Web.Http;

using Unity.AspNet.WebApi;
using WebApiWM.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApiWM.UnityWebApiActivator), nameof(WebApiWM.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApiWM.UnityWebApiActivator), nameof(WebApiWM.UnityWebApiActivator.Shutdown))]

namespace WebApiWM
{
    
    public static class UnityWebApiActivator
    {
       
        public static void Start() 
        {
           
            var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}