using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Share.Entities;

namespace Orders.Frontend.Components.Pages.Countries
{
    public partial class ContriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;

        private List<Country>? countries;

        protected override async Task OnInitializedAsync()
        {
            var httpResult = await Repository.GetAsync<List<Country>>("/api/countries");
            Thread.Sleep(3000);
            countries = httpResult.Response;
        }
    }
}