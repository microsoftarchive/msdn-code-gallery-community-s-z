using AutoMapper;
using CSdotnetWebTesty.Data;
using CSdotnetWebTestyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSdotnetWebTesty.BLL
{
    public class DomainToViewModelMap : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<doctor, doctorVM>();
            Mapper.CreateMap<user, userVM>();
        }

    }
    public class ViewModelToDomainMap : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<doctorVM, doctor>();
            Mapper.CreateMap<userVM, user>();

        }
    }
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMap>();
                x.AddProfile<ViewModelToDomainMap>();
            });
        }
    }
}
