using Azure.Identity;
using AzureADAuthentication.API.DataTransferObjects.Users;
using AzureADAuthentication.API.Entities;
using AzureADAuthentication.API.Interfaces.Mappers;
using AzureADAuthentication.API.Interfaces.Repositories;
using AzureADAuthentication.API.Interfaces.Services;
using AzureADAuthentication.API.Interfaces.Settings;
using FluentValidation;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace AzureADAuthentication.API.Services;

public sealed class UserService(
    IUserRepository userRepository,
    IUserMapper userMapper,
    IJwtService jwtService,
    IValidator<Entities.User> userValidator,
    INotificationHandler notificationHandler)
    : IUserService
{
    public async Task CreateAsync(CreateUserRequest createUser, CancellationToken cancellationToken)
    {
        if (await userRepository.UserNameExistsAsync(createUser.Email, cancellationToken))
        {
            notificationHandler.AddNotification("Exists", "User Name already exists");

            return;
        }

        var user = userMapper.CreateRequestToDomain(createUser);

        if (!await IsValidAsync(user, cancellationToken))
        {
            return;
        }

        var scopes = new[] { "https://graph.microsoft.com/.default" };

        var tenantId = "";

        var clientId = "";

        var clientSecret = "";

        var options = new ClientSecretCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);

        //var options = new DeviceCodeCredentialOptions
        //{
            //AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            //ClientId = clientId,
            //TenantId = tenantId,
            //DeviceCodeCallback = (code, cancellation) =>
            //{
                //Console.WriteLine(code.Message);
                //return Task.FromResult(0);
            //},
        //};

        //var deviceCodeCredential = new DeviceCodeCredential(options);

        var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

        var requestBody = new Microsoft.Graph.Models.User
        {
            AccountEnabled = true,
            DisplayName = "Adele Vance",
            MailNickname = "AdeleV",
            //UserPrincipalName = "AdeleV@contoso.com",
            UserPrincipalName = "AdeleV@joaoasouza982gmail.onmicrosoft.com",
            PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = "xWwvJ]6NMw+bWH-d"
            }
            
        };

        try
        {
            var result = await graphClient.Users.PostAsync(requestBody);
        }
        catch (Exception exception)
        {
            throw;
        }

        await userRepository.CreateAsync(user);
    }

    public async Task<GetUserByIdResponse?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByPredicateAsync(u => u.Id == id, cancellationToken);

        if (user is null)
        {
            return null;
        }

        return userMapper.DomainToGetByIdResponse(user);
    }

    public async Task<BearerResponse?> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var loginArgument = userMapper.LoginRequestToDomain(loginRequest);

        if (!await userRepository.LoginAsync(loginArgument))
        {
            notificationHandler.AddNotification("Login Failed", "Invalid Credentials.");

            return null;
        }

        var user = await userRepository.GetByPredicateAsync(u => u.UserName == loginArgument.Email, cancellationToken);

        var token = jwtService.GenerateToken(user!);

        return new(token);
    }

    private async Task<bool> IsValidAsync(Entities.User user, CancellationToken cancellationToken)
    {
        var validationResult = await userValidator.ValidateAsync(user, cancellationToken);

        if (validationResult.IsValid)
        {
            return true;
        }

        foreach (var error in validationResult.Errors)
        {
            notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);
        }

        return false;
    }
}
