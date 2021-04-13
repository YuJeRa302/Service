using AutoMapper;
using BankServer.Dtos;
using BankServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.MapperProfiles
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
