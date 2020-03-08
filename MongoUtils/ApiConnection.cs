using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MongoUtils
{
    public class ApiConnection
    {
        static HttpClient client = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        public dynamic Get(string url, string authorization = null)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("content-typye", "application/json");
                request.AddParameter("application/json", ParameterType.RequestBody);
                if (authorization != null)
                {
                    request.AddHeader("Authorizarion", authorization);
                }
                IRestResponse response = client.Execute(request);
                dynamic datos = response;
                Console.WriteLine(datos);
                return datos;
            }
            catch
            {
                Console.WriteLine("error exeption catch");
                return null;
            }
        }
        //static async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client.BaseAddress = new Uri(ApiPaths.INTERN_API_JAVA_ENDPOINT + ApiPaths.INTERN_API_JAVA);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        // Create a new product


        //        // Get the product
        //        user = await GetProductAsync(client.BaseAddress.PathAndQuery);
        //        ShowUser(user);

        //        // Update the product
        //        Console.WriteLine("Updating phone");
        //        user.Phone = "1231312313";
        //        await UpdateProductAsync(user);

        //        // Get the updated product
        //        user = await GetProductAsync(client.BaseAddress.PathAndQuery);
        //        ShowUser(user);

        //        //// Delete the product
        //        //var statusCode = await DeleteProductAsync(product.Id);
        //        //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    Console.ReadLine();
        //}
        //static void ShowUser(User user)
        //{
        //    Console.WriteLine($"Name: {user.FirstName}\tLast Name: " +
        //        $"{user.LastName}\tPhone: {user.Phone}");
        //}
        //static async Task<User> GetProductAsync(string path)
        //{
        //    User user = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        user = await response.Content.ReadAsAsync<User>();
        //    }
        //    return user;
        //}

        //static async Task<User> UpdateProductAsync(User user)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync(
        //        $"api/products/{user.ID}", user);
        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    user = await response.Content.ReadAsAsync<User>();
        //    return user;
        //}
    }
}
