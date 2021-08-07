using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TrackDelete
    {

        [Parameter]
        public int TrackId { get; set; }

        public bool IsValid { get; set; }

        public Track Current { get; set; }


        [Inject]
        public ITrackService TrackService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Current = await TrackService.GetAsync(TrackId);

            await base.OnInitializedAsync();
        }

        protected void HandleValidSubmit()
        {
            if (Current != null)
            {
                TrackService.DeleteAsync(Current.ID);
                navigator.NavigateTo("/alltracks", forceLoad: true);
            }
            else
                navigator.NavigateTo("/error/NotValid Track to Delete");

        }
        protected void HandleInvalidSubmit()
        {
            navigator.NavigateTo("/Error/not valid track id");
        }


    }
}
