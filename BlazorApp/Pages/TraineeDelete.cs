using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TraineeDelete
    {

        [Parameter]
        public int TraineeId { get; set; }

        public Trainee Current { get; set; }



        [Inject]
        ITraineeService TraineeService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Current = await TraineeService.GetAsync(TraineeId); 

            await base.OnInitializedAsync();
        }


        public async Task DeleteTraineeClicked()
        {
            await TraineeService.DeleteAsync(Current.ID);
            navigator.NavigateTo("/alltrainees", forceLoad: true);
        }

    }
}
