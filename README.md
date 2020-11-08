Example diagnostics test library

This was a project I did for an automated troubleshooting app for technicians to use when the production systems weren’t working for some reason. It goes through a series of tests of different possible causes of system failures, such as pinging servers, pinging databases, trying to reach our ERP system, accessing our database, seeing if the network is alive and well, and a few others. It was mean to be extensible and configurable. This is source for an executable that reads an XML file (app.config) to see the actual names of the classes that have extended a base ‘diagnostic test’ class. The actual test classes, and the base classes, are defined in another assembly and dynamically invocated based on the information provided in the app.config XML file. This allows the tests to be dynamically configured, and also allows multiple people to contribute to the assembly, or provide their own. That assembly also has a app.config file that contains parameters specific to whatever diagnostic tests are defined within it. The source for this can be found in the diagnostics repository under my account. I’ve also included a UML diagram that describes some of the diagnostic classes and their structures. I don’t have the tool but a screen shot of this UML structure is in the classdiagram3.png file.

About
Example diagnostics test librarhy

Topics
Resources
 Readme
Releases
No releases published
Create a new release
Packages
No packages published
Publish your first package
© 2020 GitHub, Inc.
Terms
Privacy
Security
Status
Help
Contact GitHub
Pricing
API
Training
Blog
