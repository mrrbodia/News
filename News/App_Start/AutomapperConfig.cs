using AutoMapper;
using News.Business.Components.Managers;
using News.Business.Models;
using News.Business.ViewModels;

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
            Mapper
             .CreateMap<Tidings, TidingsViewModel>()
             .IncludeBase<BaseModel, BaseViewModel>();

            Mapper
             .CreateMap<Comment, CommentViewModel>()
             .IncludeBase<BaseModel, BaseViewModel>();

        }

        private static void RegisterFromViewModel()
        {
            Mapper
             .CreateMap<TidingsViewModel, Tidings>()
             .IncludeBase<BaseViewModel, BaseModel>();
             //.ForMember(s => s.AuthorId, otp => otp.Ignore());

            Mapper
             .CreateMap<CommentViewModel, Comment>()
             .IncludeBase<BaseViewModel, BaseModel>();
        }
    }
}