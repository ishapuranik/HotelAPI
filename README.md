1. How long did you spend on the coding test and how would you improve your solution if you had more time? (If you were unable to spend as much time as you would have liked on the coding test, use your answer as an opportunity to explain what you would add). 

#Explaination: I have spent 3h 30m in implementing the API and Angular UI code. Having more time, I would have done below things:

		#On API:
			a. Move json file path to appSettings.json file than hardcoded at the moment in class
			b. Implement Error Handling middleware - which will make sure logs are created at least in a log file if not in db exception
			c. Fetch data from database - by implementing EF Core features
		#Angular UI: 
			####a. I am new to Angular and lack of hands-on, but I am willing to learn and adapt quickly. For me, it will take more time to implement Rating component. Whatever I could do in given time I did my best. I am going to take this as a challenge and will continue adding new feature and implement solution.
			####b. Given the chance, I can walkthrough more of my experience.

2. Describe the tooling / libraries / packages you chose to use for your development process and the 
reasons why. 

#Explaination:
		API: 
			All the packages which are used are related to 
					#Dependency Injection, MediatR, Fluent Assertions which will allow to write unit tests in more readable format. 
					#Swagger (Swashbuckle.AspNetCore) -> which will allow to test the endpoints quickly 
					#FluentValidations -> used for writing Validators that helps to verify if request model is in valid state
					
		#Angular: I have used latest Angular version 14.0
			
3. Describe how this solution would be deployed and run in your chosen cloud provider and any impact 
this may have on its development.

Explaination:
		Both solution can be deployed via Teamcity and Octopus to AWS environment (similarly on Azure as well). Once, Teamcity built the package successfully, using Octopus we can deploy to AWS EC2 instances. We just need to make sure
		
4. If the application was enhanced to contain business sensitive data what considerations and possible 
solutions would you consider for securing it? 

Explaination: 
			a. Use of Authentication on login and that can be added with further step by having two-factor authentication
			b. Use of firewall, Gateway implementation to access to APIs 
			c. JwtBearerToken authentication to authenticate request sent to API
			d. In most cases, users should not be allowed to copy or store/take screenshots of sensitive data locally; instead, they should be forced to manipulate the data remotely. All systems should require a login of some kind, and should have conditions set to lock the system if questionable usage occurs.

5. How would you track down a performance issue in production and what was your last experience of 
this?

Explaination: 
			a. Run small load test on the server and verify the memory / CPU utilization. If projects are hosted on AWS EC2 instance then we can monitor the performance on a particular time to check what was the CPU utilization and what different resources were running. 
			b. Check if we can use lazy loading in Angular Application / local storage feature like caching for most frequently requested data. 
			c. Use pagination if data is huge
			d. Try to make transactions smaller and independent of each other so that it can run multiple requests asynchronously
			e. To get reliable information from production, like how much time some method runs on average, or how long a database query took, you can use simple stopwatches and log the elapsed time
			f. Application Performance Monitoring tools give an inside-the-hood view of your application’s performance and health in production. 
			g. BenchmarkDotNet is a .NET library that allows you to measure execution times and create benchmarks. This is useful when you want to optimize some method locally and you’re trying to figure out what implementation works best
			
			
