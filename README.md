# Contacts Database: A Full Stack Developer Test

## Business Requirements
* As a user, I want to be able to login using Microsoft or Google account before using the application.
* As a user, I want to create and modify contact record
    * Contact record should have the following fields:
        * Name
            * First name
            * Last name
            * Middle name
        * Phone number
            * can be many (mobile, work, home, etc)
        * Email
        * Address
            * Address Line 1
            * Address Line 2
            * City
            * State
            * Zip
            * Country
        * Notes
        * Website
* As a user, I want to list all the contacts. (Contacts dashboard)
    * Add filters (name, phone, email)
    * Add pagination
* As a user, I want to create a group for my selected contacts.
    * Group record should have the following fields:
        * Name
        * Description
        * Contact list []
* As a user, I want to add and remove members from a group
* As a user, I want to remove lists.

## Technical Requirements
* Use containerization (Docker).
* Use Postgresql for data storage
* Use ASP.NET Identity for the OIDC flow
* Use dotnet 6 (C#) for the REST API
* Use Angular >= 13 for the frontend.

## Developer notes
### Solution References
* https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-6.0
* https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=netcore-cli
* https://docs.microsoft.com/en-us/aspnet/core/security/gdpr?view=aspnetcore-3.1