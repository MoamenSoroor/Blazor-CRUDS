using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TraineeDetails
    {

        [Parameter]
        public int TraineeId { get; set; }

        public bool IsValid { get; set; }

        public Trainee Current { get; set; }

        [Inject]
        public ITraineeService TraineeService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Current = await TraineeService.GetAsync(TraineeId);

            await base.OnInitializedAsync();
        }


    }
}
