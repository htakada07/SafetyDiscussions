# SafetyDiscussions

## Description

This POC is a simple application that is made using ASP.NET Core Web API and Angular. Placeholder data were used instad of creating an actual database. The application has no login feature and let users add a record of their Safety Discussion.

## Approach

Service Repository Pattern has been used for the backend. I have decided to apply this pattern because it is simple and multilayered. This is also a pattern that I am already used to.
For the frontend, I have decided to use Angular because this is the framework that I have been using since I have started working in this industry. The data type that I have used mostly is string because my assumption is this is an appllication for saving a copy of what have been discussed (Just like a minutes-of-the-meeting). I have also added Id (emulating an actual database), CreatedDate, ModifiedDate, IsDeleted (bool) (I have adapted a soft delete approach instead of hard because for easy recovery in case it is needed. The CreatedDate and ModifiedDate have been added as well so that we have a reference when are they created and last modified. 

I started working on the backend because this is my comfort zone and it is easier to test as well compared if I start in frontend (in my opinion only) since I have swagger which I can use to test the endpoints or Postman. After I am done with the backend, I proceeded with working on the Frontend. To be honest I found it hard to make it responsive on phones since I only used an empty Angular project and the requirement said that the target users are Desktop and Tablet users. The UI is very simple as well. I used a color palette that is adapted in Angular Material to match the tools that I have used. I have also made every input as REQUIRED since I don't think any of those can be left blank if a discussion was conducted. For the DatePicker, I have also set a maxDate (Based from the current date) since I assume it is impossible to record a discussion that didn't happen yet.

## Data

The following are the fields that a user can enter in the application

1. Observer (string)
2. Date of discussion (DateTime)
3. Location of discussion (string)
4. Colleague the discussion was with (string)
5. Subject of discussion (string)
6. Outcomes (string)

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

Angular Material 

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

