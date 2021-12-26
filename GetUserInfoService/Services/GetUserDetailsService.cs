using Grpc.Core;
using GetUserInfoService;

namespace GetUserInfoService.Services;

public class GetUserDetailsService : UserInfo.UserInfoBase
{
    private readonly ILogger<GetUserDetailsService> _logger;
    private static readonly Dictionary<Int32,string> userInfoDictioanary = new Dictionary<Int32, string>()
        {
            {1001, "jiten"},
            {1002, "ashish"},
            {1003, "ankit"}
        };
    public GetUserDetailsService(ILogger<GetUserDetailsService> logger)
    {
        _logger = logger;
    }

    public override Task<GetUserByIDReply> GetUserNameByID(GetUserByIDRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetUserByIDReply
        {
            Name = GetUserName(request.Id)
        }) ;
    }

    private string GetUserName(int id)
    {
        string uname = String.Empty;

        if (userInfoDictioanary.TryGetValue(id, out string name))
        {
           uname = name;
        }
        return uname;
    }
}
