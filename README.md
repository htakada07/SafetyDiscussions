# SafetyDiscussions

## Description

This POC is a simple application that is made using ASP.NET Core Web API and Angular. Placeholder data were used instad of creating an actual database. The application has no login feature and lets user add a record of their Safety Discussion.
Service Repository Pattern has been used for the backend. I have decided to apply this pattern because it is simple and multilayered. This is also a pattern that I am already used to.

The following are the fields that a user can enter in the application


1. The Observer 
2. Date of discussion
3. Location of discussion
4. Colleague the discussion was with
5. Subject of discussion
6. Outcomes

## Running the Angular 

Make sure the following are installed to be able to run the Angular App
**-Nodejs** (https://nodejs.org/dist/v18.16.0/node-v18.16.0-x64.msi)

Step 1

```bash
cd SafetyDiscussions.Frontend
npm install
npm start
```

npm start will run a live server for Angular. Use **localhost:4200** to access the Angular App.

## Running the Web API

Step 2.

Run the backend. 
Open the solution (SafetyDiscussions.API.sln) the build the project. 
Start the backend. Once the backend server has started, you will be redirected to **https://localhost:7113/swagger/index.html**

## Libraries used

### Angular

MatCardModule

MatFormFieldModule

MatInputModule

MatSortModule

MatPaginatorModule

MatPaginatorModule

MatTableModule

HttpClientModule

MatButtonModule

MatIconModule

MatDialogModule

FormsModule

MatDatepickerModule

MatInputModule

MatFormFieldModule

MatNativeDateModule

### ASP.NET Core

AutoMapper

