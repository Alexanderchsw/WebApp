using Microsoft.EntityFrameworkCore;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// ��������� ApplicationDbContext � �������������� ������ ����������� �� appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ������, ����������� ��� ������ � Razor Pages.
builder.Services.AddRazorPages();

var app = builder.Build();

// ������������ ��������� ��������� HTTP-��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // �������� HSTS �� ��������� � 30 ����. �� ������ �������� ��� �������� ��� ��������� � ������������.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
