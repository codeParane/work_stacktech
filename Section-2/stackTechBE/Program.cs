var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAllOrigins",
      builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
