using Sat.Recruitment.Application.Common.Interfaces;
using MediatR;
using Sat.Recruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Common.Exceptions;
using Sat.Recruitment.Domain.Ports.Repositories._Common;
using Domain.Ports.Repositories;

namespace Sat.Recruitment.Application.CQRS.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>{
    public CreateUserCommand(string name, string email, string address, string phone, string userType, decimal money)
    {
        this.name = name;
        this.email = email;
        this.address = address;
        this.phone = phone;
        this.userType = userType;
        this.money = money;
    }

    public string name { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string userType { get; set; }
    public decimal money { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    //private readonly IApplicationDbContext _context;

    //public CreateUserCommandHandler(IApplicationDbContext context)
    //{
    //    _context = context;
    //}

    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = UserFactory.CreateNewUser(request);
       _repository.Add(entity);
        await _repository.Save(cancellationToken);
        return entity.Id;
    }
}


public class UserFactory
{
    public static User CreateNewUser(CreateUserCommand request)
    {
        decimal giftAmount = CalculateGiftAmount(request.userType, request.money);
        request.money += giftAmount;

        var newUser = new User
        {
            Name = request.name,
            Email = request.email,
            Address = request.address,
            Phone = request.phone,
            UserType = request.userType,
            Money = request.money
        };

        return newUser;
    }

    private static decimal CalculateGiftAmount(string userType, decimal money)
    {
        decimal giftAmount = 0;

        if (money > 100)
        {
            switch (userType)
            {
                case "Normal":
                    giftAmount = money * 0.12m;
                    break;
                case "SuperUser":
                    giftAmount = money * 0.20m;
                    break;
                case "Premium":
                    giftAmount = money * 2;
                    break;
            }
        }
        else if (money > 10 && userType == "Normal")
        {
            giftAmount = money * 0.8m;
        }

        return giftAmount;
    }
}
