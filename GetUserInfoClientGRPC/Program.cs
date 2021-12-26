using GetUserInfoService;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:7111");
            var client = new UserInfo.UserInfoClient(channel);          
            var creditRequest = new GetUserByIDRequest { Id = 1001 };
            var reply = await client.GetUserNameByIDAsync(creditRequest);

            if(reply.Name == String.Empty)
            {
                Console.WriteLine("User not exist!!");
            }
            else
            {
                Console.WriteLine($"User exist, User name {reply.Name} ");

            }          
            Console.ReadKey();
        }
    }
}
