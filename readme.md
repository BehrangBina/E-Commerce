# Ecommerce .Net core Help

## Drop DB

> dotnet ef database drop -p .\Infrastructure\ -s .\API\

## Remove Migration

> dotnet ef migrations remove  -p .\Infrastructure\ -s .\API\

## Generate New Migration

> dotnet ef migrations add InitialCreate -p .\Infrastructure\ -s .\API\ -o Data/Migrations

## API Documentation
* Swashbuckle.AspNetCore
* https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerUI/
* washbuckle.AspNetCore.SwaggerGen 

## Enable Bootstrap in Angular
 ng add ngx-bootstrap > client app

## Install fontAwesome
* npm install font-awesome
* adding css   "./node_modules/font-awesome/css/font-awesome.min.css",

Create module:          ng g m shop
Create component:       ng g c shop

Bootstrap Theme : npm i bootswatch