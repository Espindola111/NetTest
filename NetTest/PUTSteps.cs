using System;
using TechTalk.SpecFlow;
using MongoUtils;
using Newtonsoft.Json;

namespace NetTest
{
    [Binding]
    public class PUTSteps
    {
        private MongoConnection conn = new MongoConnection();
        private ApiConnection api = new ApiConnection();
        String statusCodeRetrieved = "", idRetrieved = "";
        [Given(@"I have a user First Name")]
        public void GivenIHaveAUserFirstName()
        {
            Console.WriteLine("Hola");

        }

        [Given(@"I Prepare the resource")]
        public void GivenIPrepareTheResource()
        {
            Console.WriteLine("Hola");
        }

        [When(@"I send the data to the API")]
        public void WhenISendTheDataToTheAPI()
        {
            Console.WriteLine("Hola");
        }

        [Then(@"The status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int p0)
        {
            Console.WriteLine("Hola");
        }

        [Then(@"I verify the data on the MongoDB")]
        public void ThenIVerifyTheDataOnTheMongoDB()
        {
            conn.ConnectionToMongo();
            string parameter = "";
            parameter = conn.getRandomKeyAsync("users", "firstName");
            Console.WriteLine(parameter);
            //string json = "{\"firstName\": \"" +  + "\",\"lastName\": \"" + lastName + "\",\"phone\": \"" + phone + "\"}";
            dynamic retrieved = api.Get(ApiPaths.INTERN_API_JAVA_ENDPOINT + ApiPaths.INTERN_API_JAVA + "?firstName=" + parameter);
            statusCodeRetrieved = JsonConvert.SerializeObject(retrieved.StatusCode);
            idRetrieved = JsonConvert.SerializeObject(retrieved.Content);
            Console.WriteLine("Status coderetrieved : " + statusCodeRetrieved);
            Console.WriteLine("ID retrieved: " + idRetrieved);
        }
    }
}
