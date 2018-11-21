# Dependency Injection Proof of concept
This project is a simple proof of concept for using Dependency Injection with an Azure Function, .net core console app, class library, with MS unit test.

# Getting started
Clone or download the source code

Open ..\DIProofOfConcept\DIProofOfConcept\DiProofOfConcept.sln in Visual Studio (I have only tested this in VS 2017 and make no promises for backward compatibility)

Open the Package Manager Console and run the dotnet restore command


# Running the project
There are three ways to run this project:
1. Via Azure Function
2. Via console app
3. Via unit tests

# To run via the Azure function:
Change the context to FunctionApp and hit the play button.

I test my functions in Postman: https://www.getpostman.com/

Launch Postman

Enter this for the post url: http://localhost:7071/api/Function1

In the body tab, enter the following json text:

{
	"name": "Kathy"
}

Click the send button.

Return body should display as:

Hello, You sent me hello kathy. Thank you for calling me! Have a nice day!


# To run via console app:
Change the context to ConsoleApp and hit the play button. 

The console app should run and display the text:

Hello, You sent me test class. Thank you for calling me! Have a nice day!


# To run via unit test:
Open test explorer, click Run All. Tests should all run and pass.


# Notes on implementation
I created this proof of concept because I was working on an application that had two entry points: azure function and console app.

We also needed unit tests.

We wanted the console app and azure function to read appSettings and then call a class library that would be doing the heavy lifting.

This would be pretty straight forward but for the fact that Azure Functions do not support Dependency Injection out of the box (yet - coming in 3.0 or so I'm told)

To achieve this, I used the following nuget packages:

Microsoft.Extensions.DependencyInjection

Moq

Willezone.Azure.WebJobs.Extensions.DependencyInjection

For more information on the last nuget package, see the following two links:

https://blog.wille-zone.de/post/dependency-injection-for-azure-functions/

https://github.com/BorisWilhelms/azure-function-dependency-injection


