using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.CQRS.Users.Queries.GetUserById;

public class GetUserByIdDto
{
    public UserSummary User {  get; set; }
}


public class UserSummary : IMapFrom<User>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}


