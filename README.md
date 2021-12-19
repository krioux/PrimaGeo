# PrimaGeo
Test application Getting 10 Cities close to Montreal

The solution is composed of 3 projects. 

The console project was there mainly for debugging purposes.

The PrimaGeo backend is containing classes to serialize results comming from  

https://rapidapi.com/wirefreethought/api/geodb-cities/

The purpose of the application was to get and store the list of cities recovered to a sqlite database through EntityFramework 6. However due to compatibility issues between SQLite and EF, I was not able to deliver in this first commit.

The next steps for this project would be to get EF working, comment everything that is public and use a datagrid to display the result.

I'll continue working on it until I get a prototype ready. However I guess my skills won't give you a great impression.


