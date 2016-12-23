using AutoMapper;
using News.Business.Components.Managers;
using News.Business.Models;
using News.Business.Models.Admin;
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
             .ForMember(t => t.Comments, opt => opt.Ignore())
             .IncludeBase<BaseModel, BaseViewModel>();

            Mapper
             .CreateMap<Comment, CommentViewModel>()
             .IncludeBase<BaseModel, BaseViewModel>();

            Mapper
            .CreateMap<Page, PageDesignModel>()
            .ForMember(s => s.ContentBlocksVariants, otp => otp.Ignore());

            Mapper
             .CreateMap<ContentBlock, ContentBlockDesignModel>();

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

            Mapper
             .CreateMap<PageDesignModel, Page>()
             .ForMember(x => x.ContentBlocks, otp => otp.Ignore());

            Mapper
             .CreateMap<ContentBlockDesignModel, ContentBlock>();
        }
    }
}