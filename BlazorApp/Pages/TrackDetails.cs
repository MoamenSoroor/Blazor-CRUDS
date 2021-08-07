using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TrackDetails
    {

        [Parameter]
        public int TrackId { get; set; }




        [Inject]
        public ITrackService TrackService { get; set; }

        [Inject]
        public ITraineeService TraineeService { get; set; }



        public bool IsValid { get; set; }

        public Track Current { get; set; }

        public List<Trainee> Trainees { get; set; }



        protected async override Task OnInitializedAsync()
        {

            Current = await TrackService.GetAsync(TrackId);
            Trainees = Current.Trainees.ToList();
            await base.OnInitializedAsync();
        }


    }
}
