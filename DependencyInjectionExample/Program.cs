using DependencyInjectionExample;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PrimaryObject>();
builder.Services.AddScoped<SecondaryObject>();
builder.Services.AddTransient<TertiaryObject>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", (
        PrimaryObject primaryObject,
        SecondaryObject secondaryObject,
        TertiaryObject tertiaryObject) =>
    new
    {
        Id = Guid.NewGuid(),
        PrimaryObjectId = primaryObject.Id,
        SecondaryObject = new
        {
            Id = secondaryObject.Id,
            PrimaryObjectId = secondaryObject.PrimaryObjectId
        },

        TertiaryObject = new
        {
            Id = secondaryObject.Id,
            PrimaryObjectId = tertiaryObject.PrimaryObjectId,
            SecondaryObjectId = tertiaryObject.SecondaryObjectId,
            SecondaryObjectNewInstanceId = tertiaryObject.SecondaryObjectId,
        }
    });

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
