
using MTOGO.Configurations;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;
using Prometheus;

namespace MTOGO;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Register Facades
        builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

        // UserFacade
        builder.Services.AddHttpClient<UserFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:UserUrl"]);
        });
        builder.Services.AddSingleton<IUserInterface, UserFacade>();

        // OrderFacade
        builder.Services.AddHttpClient<OrderFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:OrderUrl"]);
        });
        builder.Services.AddSingleton<IOrderInterface, OrderFacade>();
        
        // FeedbackFacade
        builder.Services.AddHttpClient<FeedbackFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:FeedbackUrl"]);
        });
        builder.Services.AddSingleton<IFeedbackInterface, FeedbackFacade>();
        
        // PaymentFacade
        builder.Services.AddHttpClient<PaymentFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:PaymentUrl"]);
        });
        builder.Services.AddSingleton<IPaymentInterface, PaymentFacade>();
        
        // AgentFacade
        builder.Services.AddHttpClient<AgentFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:AgentUrl"]);
        });
        builder.Services.AddSingleton<IAgentInterface, AgentFacade>();
        
        // CustomerFacade
        builder.Services.AddHttpClient<CustomerFacade>(client =>
        {
            var baseAddress = builder.Configuration["ApiSettings:CustomerUrl"];
            Console.WriteLine($"CustomerFacade BaseAddress: {baseAddress}");
            client.BaseAddress = new Uri(baseAddress);
        });

        builder.Services.AddSingleton<ICustomerInterface>(sp =>
        {
            // This ensures we get the CustomerFacade instance that HttpClientFactory created and configured
            return sp.GetRequiredService<CustomerFacade>();
        });


        
        // ResFacade
        builder.Services.AddHttpClient<RestaurantFacade>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ApiSettings:ResUrl"]);
        });
        builder.Services.AddSingleton<IRestaurantInterface, RestaurantFacade>();

        // Register FacadeFactory
        builder.Services.AddSingleton<IFacadeFactory, FacadeFactory>();
        
        // Add services to the container.
        builder.Services.AddControllers();

        // Enable Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Configure CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
        }
        app.UseRouting();
        app.UseMetricServer(); // Default /metrics endpoint
        app.UseHttpMetrics(); // Enable HttpMetrics
        
        app.UseCors("AllowAll");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}