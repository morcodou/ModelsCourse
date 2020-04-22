using AutoMapper;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurisTempus.Profiles
{
  public class JurisProfiles:Profile
  {
    public JurisProfiles()
    {
      CreateMap<Client, ClientViewModel>()
        .ForMember(vm => vm.ContactName, map => map.MapFrom(client => client.Contact))
        .ReverseMap();
    }
  }
}
