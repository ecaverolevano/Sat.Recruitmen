using AutoBogus;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Entities;

namespace UniTests.Shared
{
    public static class AppEntityFaker
    {
        public static AutoFaker<DbSet<User>> GetDbSetCreditCard()
        {
            return new AutoFaker<DbSet<User>>();
        }


    }
}
