using Bogus;
using Bogus.DataSets;
using Domain.Ports.Repositories;
using FluentAssertions;
using Moq;
using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Application.CQRS.Users.Commands.CreateUser;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;
using UniTests.Shared;
using Xunit;

namespace Api.UnitTest.CQRS.Users.Commands;

public class CreateUserCommandTests
{
    [Fact]
    public void Create_Command_Succeded()
    {
        var random = new Randomizer();
        var name = random.String(20);
        var email = "ecaverolevano@gmail.com";
        var address = random.AlphaNumeric(30);
        var phone = random.String(20);
        var userType = "Normal";
        var money = random.Number(3);

        var command = new CreateUserCommand(name, email, address, phone, userType, money);

        command.name.Should().Be(name);
        command.email.Should().Be(email);
        command.phone.Should().Be(phone);
        command.userType.Should().Be(userType);
        command.money.Should().Be(money);
    }


    [Fact]
    public async Task Command_Handle_Succeded()
    {
        var random = new Randomizer();



        var name = random.String(20);
        var email = "ecaverolevano@gmail.com";
        var address = random.AlphaNumeric(30);
        var phone = random.String(20);
        var userType = "Normal";
        var money = random.Number(3);

        var user = new User { Name = name, Email = email, Address = address, Phone = phone, UserType = userType, Money = money };


        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.Add(user)).Equals(AppEntityFaker.GetDbSetCreditCard().Generate());
        var command = new CreateUserCommand(name, email, address, phone, userType, money);
        var handler = new CreateUserCommandHandler(userRepositoryMock.Object);

        var result = await handler.Handle(command, default);

        result.Should().BeOfType(typeof(int));
        userRepositoryMock.Verify(x => x.Save(It.IsAny<CancellationToken>()), Times.Once());
    }
}
