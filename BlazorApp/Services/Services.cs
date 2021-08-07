using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;

namespace BlazorApp.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


    }

    public interface ITraineeService : IService<Trainee>
    { 

    }

    public interface ITrackService : IService<Track>
    {

    }

    class TraineeService : ITraineeService
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


    class TrackService : ITrackService
    {
        private readonly HttpClient httpClient;
        public TrackService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task AddAsync(Track entity)
        {
            //await httpClient.PostJsonAsync<Track>("api/Tracks", entity);



            var entityjson = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");

            await httpClient.PostAsync("/api/Tracks/", entityjson);

        }

        public async Task DeleteAsync(int id)
        {

            await httpClient.DeleteAsync($"api/Tracks/{id}");

        }

        public async Task<Track> GetAsync(int id)
        {
            return await httpClient.GetJsonAsync<Track>($"api/Tracks/{id}");
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await httpClient.GetJsonAsync<IEnumerable<Track>>("api/Tracks");
        }

        public async Task UpdateAsync(Track entity)
        {
            //await httpClient.PutJsonAsync<Track>($"api/Tracks/{entity.ID}", entity);

            var obj = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");

            await httpClient.PutAsync("/api/Tracks/" + entity.ID, obj);

        }
    }
}
