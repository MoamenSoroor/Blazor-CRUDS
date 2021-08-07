using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TrackInsert
    {

        [Parameter]
        public int TrackId { get; set; }

        public bool IsValid { get; set; }
        
        public Track Current { get; set; }


        [Inject]
        public ITrackService TrackService { get; set; }



        protected override Task OnInitializedAsync()
        {
            Current = new Track();

            return base.OnInitializedAsync();
        }

        protected async Task HandleValidSubmit()
        {
            if (Current != null)
            {
                await TrackService.AddAsync(Current);
                navigator.NavigateTo("/alltracks", forceLoad: true);
            }
            else
                navigator.NavigateTo("/error/NotValid Track to insert");

        }
        protected void HandleInvalidSubmit()
        {
            navigator.NavigateTo("/Error/not valid track id");
        }


    }
}
