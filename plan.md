# Plan
## Define:
1. build data objects:
  - User
  - Cursa
  - Rezervare
2. Research: 
 - Data object to json
 - Data object from json
 - Note: prefer existing libraries in the dotnet standard library
 
 
## Implement 
1. Create basic gluecode:
 - IService
 - IObserver. 
 - Create small design text including a dummy server (on the service side) and a dummy client (in the client app)
 - Write a small driver in the client app sending a login, getting a list of transport schedules and adding a reservation.
2. Write Networking code building a session, sending and receiving an int
3. Extend Networking solution with a login
4. Add getting a list of transports.
5. Add a reservation
6. Implement notification
