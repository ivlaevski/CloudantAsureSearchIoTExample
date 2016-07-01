# Cloudant Asure Search IoT Example
This code is part of a post about Cloudant Search indexes.
The code is in two parts

# Sensor emulator
Console application designed to submit sensor data to Cloudant DBaaS
Requires Cloudant account and database.
Execution parameters:
- username
- password
- database name

# Azure Web Site
Web site designed to be hosted in Azure, but to visualize data from Cloudant DBaaS.
Requires Cloudant account and database and Google Maps API key.

To build apply username and password into web.config file and add Google Maps API key to index.html 