# Randomuser.me-Dotnetcore

### About
This is the source code that powers the randomuser.me User Generator.

Our goal is to have a very diverse database that consists of data unique to different nationalities.
While some places might have an SSN or their phone number might be formatted a certain way, other places usually follow a completely different set of rules.

Help us make the Random User Generator better by contributing to our database and teaching us the proper way of formatting data for different nationalities.

### Guidelines
If you would like to help contribute data specific to a region, please keep these few rules in mind:

1. Only add new nat data to the `api/.nextRelease` directory...

2. Please keep all of the data organized.
    - Keep US data in the US directory, AU in the AU directory, etc.

3. No duplicates. Make sure that the data you are adding isn't already on the list.
    - An easy way to remove duplicates from your file and sort: 
```sh
sort -u <file> -o <file>
```

4\. Please don't submit requests that say "make this nationality". We will accept helpful contributions, but not orders :)

### Requirements

dotnet core +2 and above.
MongoDB

### How to use
