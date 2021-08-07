using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TraineeInsert
    {
        //NavigationManager navigation;


        public bool IsValid { get; set; }

        public Trainee Current { get; set; }

        public int TrackId { get; set; }

        public List<Track> Tracks { get; set; }


        [Inject]
        ITrackService TrackService { get; set; }


        [Inject]
        ITraineeService TraineeService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Current = new Trainee();
            Tracks = (await TrackService.GetAllAsync()??new List<Track>()).ToList();
            Current.Track = Tracks.FirstOrDefault();
            TrackId = Current.Track.ID;
            await base.OnInitializedAsync();
        }


        public async Task HandleValidSubmit()
        {
            Current.Track = Tracks.FirstOrDefault(tr => tr.ID == TrackId);
            await TraineeService.AddAsync(Current);
            navigator.NavigateTo("/alltrainees", forceLoad: true);
        }


        public void HandleInvalidSubmit()
        {
            
        }

        public void TrackChangeHandler()
        {
            //Current.Track = Tracks.FirstOrDefault(t => t.ID == TrackId);
        }



    }
}
