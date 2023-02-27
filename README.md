# Restaurant

## Lerning

Learn Microservices architecture with .NET Core MVC(.NET 6) and Identity Server Integration with Azure Service Bus

- Product Microservice
- Identity Server Microservice
- Coupon Microservice
- Shopping Cart Microservice
- Order Microservice
- Email Microservice
- Payment Microservice
- Ocelot Gateway Project
- MVC Web Application

### Requirements

1. .NET Core CRUD experience
2. .NET API CRUD experience
3. Entity Framework Core CRUD experience
4. Visual Studio 2022 (using .NET 6)
5. SQL Server Management Studio 2019

### NuGet Frontend

#### Restaurant.Web

1. Microsoft.AspNetCore.Authentication 2.2.0
2. Microsoft.AspNetCore.Authentication.OpenIdConnect 6.0.13
3. Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.13
4. Newtonsoft.Json 13.0.2
5. System.IdentityModel.Tokens.Jwt 6.26.0

### NuGet Gateway

#### Restaurant.GatewaySolution

1. IdentityModel 6.0.0
2. Microsoft.AspNetCore.Authentication.JwtBearer 6.0.13
3. Ocelot 18.0.0

### NuGet Integration

#### Restaurant.MessageBus

1. Azure.Messaging.ServiceBus 7.12.0
2. Newtonsoft.Json 13.0.2

### NuGet Payments

#### PaymentProcessor

### NuGet Services

#### Restaurant.Services.CouponAPI

1. AutoMapper 12.0.1
2. AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
3. Microsoft.AspNetCore.Authentication.JwtBearer 6.0.13
4. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
5. Microsoft.EntityFrameworkCore.Tools 6.0.13
6. Swashbuckle.AspNetCore 6.5.0
7. Swashbuckle.AspNetCore.Annotations 6.5.0
8. Swashbuckle.AspNetCore.SwaggerUI 6.5.0

#### Restaurant.Services.Email

1. Azure.Messaging.ServiceBus 7.12.0
2. Microsoft.EntityFrameworkCore.Design 6.0.13
3. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
4. Newtonsoft.Json 13.0.2
5. Swashbuckle.AspNetCore 6.2.3

#### Restaurant.Services.Identity

1. Duende.IdentityServer.AspNetIdentity 5.2.4
2. Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.13
3. Microsoft.AspNetCore.Identity.UI 6.0.13
4. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 6.0.13
5. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
6. Microsoft.EntityFrameworkCore.Tools 6.0.13

#### Restaurant.Services.OrderAPI

1. AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
2. Azure.Messaging.ServiceBus 7.12.0
3. Microsoft.AspNetCore.Authentication.JwtBearer 6.0.13
4. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
5. Microsoft.EntityFrameworkCore.Tools 6.0.13
6. Newtonsoft.Json 13.0.2
7. Swashbuckle.AspNetCore 6.2.3

#### Restaurant.Services.PaymentAPI

1. Swashbuckle.AspNetCore 6.5.0

#### Restaurant.Services.ProductAPI

1. AutoMapper 12.0.1
2. AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
3. Microsoft.AspNetCore.Authentication.JwtBearer 6.0.13
4. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
5. Microsoft.EntityFrameworkCore.Tools 6.0.13
6. Swashbuckle.AspNetCore 6.5.0
7. Swashbuckle.AspNetCore.Annotations 6.5.0
8. Swashbuckle.AspNetCore.SwaggerUI 6.5.0

#### Restaurant.Services.ShoppingCartAPI

1. AutoMapper 12.0.1
2. AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0
3. Microsoft.AspNetCore.Authentication.JwtBearer 6.0.13
4. Microsoft.EntityFrameworkCore.Design 6.0.13
5. Microsoft.EntityFrameworkCore.SqlServer 6.0.13
6. Newtonsoft.Json 13.0.2
7. Swashbuckle.AspNetCore 6.5.0
8. Swashbuckle.AspNetCore.Annotations 6.5.0
9. Swashbuckle.AspNetCore.SwaggerUI 6.5.0
