// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace blaze_ex1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using blaze_ex1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\conor\source\repos\blazorca\blaze-ex1\_Imports.razor"
using blaze_ex1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\conor\source\repos\blazorca\blaze-ex1\Pages\TvSearch.razor"
using System.Runtime.Serialization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/TvShows")]
    public partial class TvSearch : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "C:\Users\conor\source\repos\blazorca\blaze-ex1\Pages\TvSearch.razor"
      
    private String show = "breaking bad";
    private bool found;

    private Root data;
    private String errormessage;

    private async Task GetShowAsync()
    {
        try
        {
            string uri = "https://api.themoviedb.org/3/search/tv?api_key=ca42a258b7f32fa28593ca9289a55adb&query=" + show;
            data = await Http.GetFromJsonAsync<Root>(uri);
            found = true;
            errormessage = String.Empty;

        }
        catch (Exception e)
        {
            found = false;
            errormessage = e.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await GetShowAsync();
    }

    //lookup
    public async void Lookup()
    {
        await GetShowAsync();
        StateHasChanged();
    }

    public class Result
    {
        public string backdrop_path { get; set; }
        public string first_air_date { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<string> origin_country { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Root
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
