using AutoMapper;
using System.Data;

namespace BilleteraVirtualSofttekBack.Helpers
{
    /// <summary>
    /// This class provides a mean to configure mappings between classes.
    /// </summary>
    public class MapperHelper : Profile
    {
        /// <summary>
        /// This constructor contains the logic for Entity-DTO mappings using the AutoMapper library and its methods.
        /// </summary>
        public MapperHelper()
        {

            /*
            #region Rol mapping to their Dto class
            CreateMap<Role, RoleDto>().ReverseMap();
            #endregion

            #region Project mapping to their Dto class
            CreateMap<Project, ProjectGetDto>().ReverseMap();
            CreateMap<Project, ProjectUpdateDto>().ReverseMap();
            CreateMap<Project, ProjectCreateDto>().ReverseMap();
            CreateMap<Project, ProjectGetMinDto>().ReverseMap();
            #endregion

            #region Service mapping to their Dto class
            CreateMap<Service, ServiceGetDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();
            CreateMap<Service, ServiceCreateDto>().ReverseMap();
            CreateMap<Service, ServiceGetMinDto>().ReverseMap();
            #endregion

            #region Work mapping to their Dto class
            CreateMap<Work, WorkGetDto>().ReverseMap();
            CreateMap<Work, WorkGetMinDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            #endregion

            #region User mapping to their Dto class
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserGetDto>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            #endregion
            */

        }

    }
}
