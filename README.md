# Randomuser.me-Dotnetcore

### About
This is the source code that powers the randomuser.me User Generator.

Our goal is to have a very diverse database that consists of data unique to different nationalities.
While some places might have an SSN or their phone number might be formatted a certain way, other places usually follow a completely different set of rules.

Help us make the Random User Generator better by contributing to our database and teaching us the proper way of formatting data for different nationalities.

### Guidelines

Run the aplication. Next create some sample datasets, send an empty post request 

Create a POST with the following to http://localhost/user
{
  
}

To Retrieve records, create a GET request to http://localhost/user
{
  "TotalRecordRequested" : 4
}

Or your can use 

{
  "firstname" : "", 
  "lastname" : "",
  "TotalRecordRequested" : 4
}

Send a HTTP PUT command

To Update, create a PUT request to http://localhost/user
{

}

Send a HTTP PUT command

http://localhost/suser/UserValidNumber


### How to use
