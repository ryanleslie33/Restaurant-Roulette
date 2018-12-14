## Spec Layout
##### Project Name: Dice


##
### Goals Wed - Thurs

* Create model class Restaurant (CRUD), tied to table/database.
* Create model class Roll (Logic to randomly select from DB).
* Create model User class (CRUD).
* Create model Search class (Logic to link API).
* Build database to hold information.
* Build table for Favorite Restaurants. (name, location, price).
* Build table for User Information. (name, image, bio)
* Create Landing page/Splash page (link Roll, link Search, link Profile)
* Create view for User to input, and save, User Information. (name, image, bio)
* Create view to display user information. (link Favorite Restaurants, link splash page)
* Write logic to randomly select Favorite Restaurant from database(when user clicks Roll, on splash page)
* Create view to display randomly selected restaurant from database, and information pertaining to restaurant drawn from database.


| Return Type        | Test Purpose           
| ------------- |:-------------:|
| View("Route")      | Check If ReturnsCorrectView |
|      | Check If HasCorrectModelType      |   
| View() | Check If ReturnsCorrectView      |
| RedirectToAction("Route")      | Check If ReturnsCorrectView |
|      | Check If ReturnsCorrectActionName      |  
| View("Route", object)      | Check If ReturnsCorrectView |
|      | HasCorrectViewName      |  
|       | Check If HasCorrectModelType |



| Method Name        | Test Purpose |  Method Type|
|: ------------- :|:-------------:|:-------------:|
|     Parent Constructor             |        Check If Creates Instance Of Parent      |       Parent Instance Constructor        |
|  GetName()      | Check If Returns Parent Name |   Getter Method  |
|  GetId()   | Check If Returns Parent Id     | Getter Method   |
| Equals() | Check If Returns True If 2 Parent Objects with Identical Properties Are The Same     |   Maintenance Method    |
| ClearAll()      | No Test |  Maintenance Method   |
|   GetHashCode()   |  No Test     | Maintenance Method |
| GetAll()     | Test 1: Check If Returned Parent's Instance List is Empty At First|Database Manipulation|
|  GetAll()    | Test 2: Check If Returned List Contains All Parent's Instances      |  Database Manipulation  |
|  Save()     | Check If It Saves Parent Instance To Database |Database Manipulation|
|  Find()     |  Check If It Returns Parent Instance In Database   | Database Manipulation|
|   GetClients()    | Check If It Retrieves All Child Instances Associated With Parent Instance|Database Manipulation|
|  Edit()     | Check If It Updates Parent Instance In Database|Database Manipulation|
|  Delete()  | Check If It Deletes Parent Instance From Database|Database Manipulation|
