using DependencyInjectionExample.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SingletonRequest>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", (
        SingletonRequest primaryObject) =>
    new
    {
        Id = Guid.NewGuid(),
        PrimaryObject = primaryObject.Id,
    });


var singletonInstance = Singleton.GetInstance();
var singletonText = singletonInstance.someBusinessLogic();
//var singletonText2 = new Singleton();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

