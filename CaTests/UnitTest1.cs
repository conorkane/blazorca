using NUnit.Framework;
using Bunit;
using blaze_ex1.Pages;
using Microsoft.Extensions.DependencyInjection;
using RichardSzalay.MockHttp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;


namespace CaTests
{
    public static class MockHttpClientBunitHelpers
    {
        public static MockHttpMessageHandler AddMockHttpClient(this TestServiceProvider services)
        {
            var mockHttpHandler = new MockHttpMessageHandler();
            var httpClient = mockHttpHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri("http://localhost");
            services.AddSingleton<HttpClient>(httpClient);
            return mockHttpHandler;
        }

        public static MockedRequest RespondJson<T>(this MockedRequest request, T content)
        {
            request.Respond(req =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonSerializer.Serialize(content));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            });
            return request;
        }

        public static MockedRequest RespondJson<T>(this MockedRequest request, Func<T> contentProvider)
        {
            request.Respond(req =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonSerializer.Serialize(contentProvider()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            });
            return request;
        }
    }

    public class Tests
    {

        [Test]
        public void Test1()
        {
            MovieSearch acc = new MovieSearch();
            Assert.AreEqual(acc.movie, "fight club");
            acc.movie = "Thor";
            acc.Lookup();
            Assert.AreEqual(acc.movie,"Thor");
        }

        [Test]
        public void Test2()
        {
            using var context = new Bunit.TestContext();
            var mock = context.Services.AddMockHttpClient();            

            var cut = context.RenderComponent<MovieSearch>();

            mock.When("https://localhost:44331/").Respond("application/json", "{'name' : 'Test McGee'}");

            var client = new HttpClient(mock);
            

            //var response = client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=ca42a258b7f32fa28593ca9289a55adb&amp;query=fight%20club");

            //assert
            //cut.MarkupMatches("<h5 class='card-title'>Movie name: @data.results[0].original_title</h5>");
        }


        [Test]
        public void Bunit()
        {
            using var context = new Bunit.TestContext();

            var cut = context.RenderComponent<MovieSearch>();
            


            var paraElm = cut.Find("h5");

            //act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            //assert
            paraElmText.MarkupMatches("Movie name: Fight Club");
        }


    }
}