# Randomuser.me-Dotnetcore

### About
This is the source code that mimic randomuser.me User Generator.

Our goal is to have a very diverse database that consists of data unique to different nationalities.
While some places might have an SSN or their phone number might be formatted a certain way, other places usually follow a completely different set of rules.

### Requirements

dotnetcore2.1 (my macbook is too old :)

### How to use

Run the aplication. 

Next,to create some sample datasets, send an empty post request 

Create a POST with the following to http://localhost/user

(json / body content)
{
  
}

To Retrieve records, fire a GET request to http://localhost/user
{
  "TotalRecordRequested" : 4
}

Or your can use to run name based query.

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

http://localhost/suser/##UserValidNumber##

