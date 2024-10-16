using AzureADAuthentication.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzureADAuthentication.API.Data.DatabaseContexts;

public sealed class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options);
