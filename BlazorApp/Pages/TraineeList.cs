using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class TraineeList
    {

        [Inject]
        ITraineeService TraineeService { get; set; }

        List<Trainee> Trainees { get; set; } 
        protected async override Task OnInitializedAsync()
        {

            Trainees = ((await TraineeService.GetAllAsync())?? new List<Trainee>()).ToList();
            await base.OnInitializedAsync();
        }

    }
}
