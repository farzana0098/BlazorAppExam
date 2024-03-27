using BlazorAppExam.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppExam.Client.Services
{
    public class StudentsMarksService
    {

        private readonly HttpClient http;

        private string apiLink = "/api/Students";

        public StudentsMarksService(HttpClient http, NavigationManager nav)
        {
            http.BaseAddress = new Uri(nav.BaseUri);
            this.http = http;
        }

        public async Task<IList<Students>?> GetAll()
        {
            var data = await this.http.GetFromJsonAsync<IList<Students>>(apiLink);
            return data;
        }
        public async Task<Students?> GetById(int id)
        {
            return await this.http.GetFromJsonAsync<Students>(apiLink + $"/{id}");
        }
        public async Task<HttpResponseMessage?> Save(Students data)
        {
            return await this.http.PostAsJsonAsync<Students>(apiLink, data);
        }
        public async Task<HttpResponseMessage?> Update(Students data)
        {
            return await this.http.PutAsJsonAsync<Students>(apiLink + $"/{data.StudentId}", data);
        }

        public async Task<HttpResponseMessage?> Delete(int id)
        {
            return await this.http.DeleteAsync(apiLink + $"/{id}");
        }
    }
}
