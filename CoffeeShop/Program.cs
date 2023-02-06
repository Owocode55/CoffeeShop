using CoffeeShop.CommonUtilities;
using CoffeeShop.Repository;
using CoffeeShop.Repository.IRepository;
using CoffeeShop.Repository.Repository;
using CoffeeShop.Service.IService;
using CoffeeShop.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddRazorPages();

//Repository
builder.Services.AddScoped<IDapper, Dapperr>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();


//Services
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderHistoryService, OrderHistoryService>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
