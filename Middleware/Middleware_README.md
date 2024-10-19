# Features

## 1. Using the Use, Map, Run extension method
### Branch Name: Pipeline_Flow
- Create Middleware Pipeline by using Use,Run extensions
- Understanding Pipeline flow
- Create the sub-pipeline or new branch pipeline with Map() extension when handling specific Url

## 2. Create Custom Middleware and using with Map() extenstion. 
### Branch Name: Pipeline_Flow
- Create Custom Middleware : HandleMapTest1, HandleMapTest2
- Use Map() and pass the delegate: IApplicationBuilder => { }

## 3. Create Injector Activation Middleware( using IMiddleware Interface) & Pass data between Middlewares 
### Branch Name: middleware_activation
- Create Injector Activation Middleware : FirstSimpleActivatedMiddleware , SecondSimpleActivatedMiddleware
- Pass data between Middleware:  using context.Items.Add() method

## 3. Using Staic Middleware && Use the UseRouting() + UseEndpoints() middleware 
### Branch Name: static_middleware
- Use static middleware : UseStatic() that will use the html file in wwwroot folder
- Use UseRouting + UseEndpoints ( is also terminate Middleware) to work with specific endpoint