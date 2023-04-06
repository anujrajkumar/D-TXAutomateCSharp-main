using APIAutomationFramework.Helper;
using GenericFrameworkComponent.Utilities;
using GenericFrameworkComponent.APIFrameworkUtilities;
using TechTalk.SpecFlow;
using APIAutomationFramework.Endpoints;

namespace APIAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            LogUtil.infoLog(ResponseUtil.ResponseGetAsync(RestClientUtil.Client(ExcelUtil.getTestDataUsingDataAndColumn(ExcelUtil.getTestDataFromSheet("Login"), "TestData1", "URL")), 
                RequestUtil.Request(TestEndpoints.userList(number))));
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            string response = ResponseUtil.ResponsePostAsync(RestClientUtil.Client("https://testingxpert.atlassian.net"),
                RequestUtil.RequestWithPayloadAndBasicAuthorization(JIRAEndpoints.createIssueURI(), "testaccount1@testingxperts.com", "3OeJZ6R0CHYBcViAaaan5E48", "CreateIssue"));
            LogUtil.infoLog(response);
            JSONUtil.createJson("CreatedIssue", response);
            Console.WriteLine(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Console.WriteLine(result);
        }
    }
}