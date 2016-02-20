namespace AcademyGrandPrix.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using AcademyGrandPrix.Services.Web.Contracts;
    using AcademyGrandPrix.Web.Infrastructure.Mappings;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}