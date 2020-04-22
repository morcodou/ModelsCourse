using AutoMapper;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurisTempus.Profiles
{
  public class JurisProfiles : Profile
  {
    public JurisProfiles()
    {
      CreateMap<Client, ClientViewModel>()
        .ForMember(vm => vm.ContactName, map => map.MapFrom(client => client.Contact))
        .ForMember(vm => vm.Address1, map => map.MapFrom(client => client.Address.Address1))
        .ForMember(vm => vm.Address2, map => map.MapFrom(client => client.Address.Address2))
        .ForMember(vm => vm.Address2, map => map.MapFrom(client => client.Address.Address2))
        .ForMember(vm => vm.CityTown, map => map.MapFrom(client => client.Address.CityTown))
        .ForMember(vm => vm.PostalCode, map => map.MapFrom(client => client.Address.PostalCode))
        .ForMember(vm => vm.Country, map => map.MapFrom(client => client.Address.Country))
        .ForMember(vm => vm.StateProvince, map => map.MapFrom(client => client.Address.StateProvince))
        .ReverseMap();

      CreateMap<Case, CaseViewModel>()
        .ReverseMap();

      CreateMap<TimeBill, TimeBillViewModel>()
        .ForMember(d=> d.CaseId, opt => opt.MapFrom(s => s.Case.Id))
        .ForMember(d=> d.EmployeeId, opt => opt.MapFrom(s => s.Employee.Id))
        .ReverseMap();
    }
  }
}
