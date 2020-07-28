# Charcoal Companion

## Table of Contents
* [Description](#description)
* [Installation](#installation)
* [Usage](#usage)
* [Contributing](#contributing)
* [Technologies](#technologies)
* [Credits](#credits)
* [License](#license)

## Description
#### Plan your grilling session!
Charcoal Companion is a web application to help you plan your next grilling session.  Use the grill planning section to put together your next meal, take a closer look at each step, or even submit your own entries.  With the Charcoal Companion, each and every new addition to your grilling repertoire can be added to our system, and then used to make countless new creations, or help allow people to see new ideas for themselves!

## Installation
To check it out, there are two primary options.  The first and more simple option is to visit the deployed site at https://charcoalcompanionmvc.azurewebsites.net.  In the event that the deployed website is no longer available, then follow these directions to run it locally:
1. Clone or download the zip of the project
2. Open up the project in Visual Studio, right-click on the solution in the solution explorer, and click 'Restore NuGet Packages'
3. Run and enjoy!

## Usage
Basic CRUD is available on all three main object types: Steps, Plans, and Recipes.  You can add more Steps by providing a Name and Step Type, alongside the option to add a Description, Image Link, and an input for information that would be useful at a glance.  Plans are comprised of one of each Step Type, and are connected through navigation properties.  Finally, Recipes are more customizable, with fields for a Name, Directions, Ingredients, a simple block of steps, or even optionally linking an existing plan.  While creation, alteration, and deletion of objects is only allowed based on user authentication, you are free to look and see what entries have already been made regardless of being signed in or not.

## Contributing
Submit new data as new Steps directly on the deployed website, send a message over GitHub.  Alternatively, you can add new data to the Seed method, located at CharcoalCompanion.Data/Migrations/Configuration.cs.  

## Technologies
- ASP.NET MVC 5.2.7
- HTML 5
- CSS 3
- Bootstrap 4
- JQuery 3.5.1

## Credits
- Abram Pithey

## License
MIT License

Copyright (c) 2020 Abram Pithey

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
