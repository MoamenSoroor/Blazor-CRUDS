using BlazorApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;

namespace BlazorApp.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly HttpClient httpClient;
        public TraineeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddAsync(Trainee entity)
        {
            //await httpClient.PostJsonAsync<Trainee>("api/Trainees", entity);
            var entityjson = new StringContent(JsonSerializer.Serialize(entity),
                    Encoding.UTF8, "application/json");

            await httpClient.PostAsync("/api/Trainees/", entityjson);
        }

        public async Task DeleteAsync(int id)
        {

            await httpClient.DeleteAsync($"api/Trainees/{id}");

        }

        public async Task<Trainee> GetAsync(int id)
        {
            return await httpClient.GetJsonAsync<Trainee>($"/api/Trainees/{id}");
        }

        public async Task<IEnumerable<Trainee>> GetAllAsync()
        {
            return await httpClient.GetJsonAsync<IEnumerable<Trainee>>("api/Trainees");
        }

        public async Task UpdateAsync(Trainee entity)
        {
            //await httpClient.PutJsonAsync<Trainee>($"api/Trainees/{entity.ID}",entity); 
            var obj = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");

            await httpClient.PutAsync("/api/Trainees/" + entity.ID, obj);
        }
    }
}
