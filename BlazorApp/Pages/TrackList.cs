using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TrackList
    {

        [Inject]
        public ITrackService TrackService { get; set; }
        

        List<Track> Tracks { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Tracks = (await TrackService.GetAllAsync()).ToList();
            await base.OnInitializedAsync();
        }

    }
}
