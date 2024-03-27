using BlazorAppExam.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient());

builder.Services.AddScoped<StudentsMarksService>();

await builder.Build().RunAsync();
