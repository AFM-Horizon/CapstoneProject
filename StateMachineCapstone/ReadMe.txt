I designed the state machine to allow it to be called by different roles.  

Each of the roles (CourseAdmin and Teacher) has their own Context Class (IContext) 
and I designed this with the idea in mind that each of the Roles would have their own model which
would hold a reference to their unique context.  

The cool thing about the two different context classes is that each role will only have the actions/methods 
available to them show up in intellisense so it will be easier to work with the front end knowing what methods are available to each Role.  

I also designed the state machine to be reasonably extensible so that we can adhere to the open closed principle if future additions to either the
actions available to each role or further Roles should be added for some reason.  