using AutoMapper;
using News.Business.Components.Managers;
using News.Business.Models;

namespace News.App_Start
{
    public class AutomapperConfig
    {
        public static void RegisterMaps()
        {
            RegisterToViewModel();
            RegisterFromViewModel();
            Mapper.AssertConfigurationIsValid();
        }

        private static void RegisterToViewModel()
        {
        }

        private static void RegisterFromViewModel()
        {
        }
    }
}