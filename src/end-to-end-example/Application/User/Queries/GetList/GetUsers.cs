using MediatR;

namespace Application.User.Queries.GetList
{
    public class GetUsers : IRequest<UserListModel>
    {
    }
}