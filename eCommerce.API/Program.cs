using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using eCommerce.infrastructure;
using FluentValidation;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services to the dependency injection container
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection, enabling support for API controllers in the application
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters
.Add(new JsonStringEnumConverter()));

//builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg => {}, typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(RegisterRequestMappingProfile).Assembly);

//FluentValidations
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Build the application, creating a WebApplication instance that will be used to configure and run
// the web application. This step finalizes the setup of the application's services and middleware
// based on the configurations specified in the builder.
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Authentication and Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

// Controller Routing
app.MapControllers();

app.Run();
