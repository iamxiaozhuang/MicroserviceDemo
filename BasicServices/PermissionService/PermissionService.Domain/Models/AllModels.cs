using AutoMapper;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionService.Domain.Models
{


    public class RoleAssignmentModel : BaseModel
    {
        public string PrincipalCode { get; set; }
        public string PrincipalName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string ScopeCode { get; set; }
        public string ScopeName { get; set; }
        public int SortNO { get; set; }

    }


    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleAssignment, RoleAssignmentModel>().ForMember(dest => dest.PrincipalCode, opt => opt.MapFrom(src => src.Principal.PrincipalCode))
                                               .ForMember(dest => dest.PrincipalCode, opt => opt.MapFrom(src => src.Principal.PrincipalCode))
                                               .ForMember(dest => dest.PrincipalName, opt => opt.MapFrom(src => src.Principal.PrincipalName))
                                               .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.Role.RoleCode))
                                               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                                               .ForMember(dest => dest.ScopeCode, opt => opt.MapFrom(src => src.Scope.ScopeCode))
                                               .ForMember(dest => dest.ScopeName, opt => opt.MapFrom(src => src.Scope.ScopeName))
                                               .ForMember(dest => dest.SortNO, opt => opt.MapFrom(src => src.Role.SortNO));
        }
    }
}
