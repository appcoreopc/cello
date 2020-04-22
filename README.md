# Randomuser.me-Dotnetcore

### About
This is the source code that powers the randomuser.me User Generator.

Our goal is to have a very diverse database that consists of data unique to different nationalities.
While some places might have an SSN or their phone number might be formatted a certain way, other places usually follow a completely different set of rules.

Help us make the Random User Generator better by contributing to our database and teaching us the proper way of formatting data for different nationalities.

### Guidelines

Run the aplication. Next creat some sample datasets

Create a POST with the following to http://localhost/user
{
  "id" : 14862,
  "firstName" : "TheDude",
  "lastName" : "Thedude",
  "TotalRecordRequested" : 4
}

To Retrieve records, create a GET request to http://localhost/user
{
  "TotalRecordRequested" : 4
}


To Update, create a PUT request to http://localhost/suser
{

}

### How to use
