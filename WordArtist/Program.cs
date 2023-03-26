using Python.Runtime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Set the Python.Runtime.PythonDLL property | Change the path to your python3x.dll file
Runtime.PythonDLL = @"C:\Users\MSI\AppData\Local\Programs\Python\Python310\python310.dll"; 

app.Run();