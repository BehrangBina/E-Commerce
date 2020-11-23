# Ecommerce .Net core Help

## Drop DB

> dotnet ef database drop -p .\Infrastructure\ -s .\API\

## Remove Migration

> dotnet ef migrations remove  -p .\Infrastructure\ -s .\API\

## Generate New Migration

> dotnet ef migrations add InitialCreate -p .\Infrastructure\ -s .\API\ -o Data/Migrations