using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TraineeEdit
    {

        [Parameter]
        public int TraineeId { get; set; }

        public bool IsValid { get; set; }

        public Trainee Current { get; set; }

        public List<Track> Tracks { get; set; }

        public int TrackId { get; set; }



        [Inject]
        ITrackService TrackService { get; set; }


        [Inject]
        ITraineeService TraineeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Current = await TraineeService.GetAsync(TraineeId);
            TrackId = Current.Track.ID;
            Tracks = (await TrackService.GetAllAsync()??new List<Track>()).ToList();
            await base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            var track = Tracks.FirstOrDefault(tr => tr.ID == TrackId);
            if(track == null)
            {
                navigator.NavigateTo("/Error");
                return;
            }

            Current.Track = track;
            Current.TrackId = track.ID;
            await TraineeService.UpdateAsync(Current);
            navigator.NavigateTo("/alltrainees", forceLoad: true);

            // handle end edit
        }
        public void HandleInvalidSubmit()
        {

        }


        public void TrackChangeHandler()
        {
            //Current.Track = Tracks.FirstOrDefault(t => t.ID == TrackId);
            //Console.WriteLine(Current.Track.Name);
        }


    }
}
