using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.infrastructure;
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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Allow requests from the specified origin (e.g., Angular development server)
        //.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//FluentValidations
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Build the application, creating a WebApplication instance that will be used to configure and run
// the web application. This step finalizes the setup of the application's services and middleware
// based on the configurations specified in the builder.

// Add API explorer services(29)
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services for API documentation(29)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Request pipeline configuration
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

app.UseSwagger(); //29
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1")
); //29
app.UseCors(); // Enable CORS for all origins, methods, and headers. This allows the API to be accessed from any domain, which is useful for development and testing purposes. In production, you may want to configure CORS more restrictively to enhance security by specifying allowed origins, methods, and headers based on your application's requirements.

// Authentication and Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

// Controller Routing
app.MapControllers();

app.Run();
