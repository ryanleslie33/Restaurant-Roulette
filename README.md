# _Roll The Dice_

#### By _**Tavish OKeefe, Ryan Leslie, **_

## Description

_Dice description._

## Specifications
* _**Create database to store information, and test database to test information.**_
* _**Create table to hold stylist name and id.**_
* _**Create table to hold client name, id, and stylist key id.**_
* _**Create class, constructor, and properties for stylist.**_
* _**create class, constructor, and properties for client.**_
* _**Write method to get stylist name.**_
* _**Write test for get stylist name method.**_
* _**Write method to get stylist id.**_
* _**Write test for get stylist id.**_
* _**Write method to save stylist name, and assign id.**_
* _**Write method to get stylist name, and id.**_
* _**Write test to check that stylist GetAll method returns an empty list.**_
* _**Write test to check that stylist GetAll method returns inputed new objects.**_
* _**Write test to test stylist save method is operational.**_
* _**Write stylist Equals method so as to separate primary data table and test data table. (Result in stylist GetAll and Save method tests passing).**_
* _**Write method to get client name.**_
* _**Write test for get client name method.**_
* _**Write method to get client id.**_
* _**Write test for get client id.**_
* _**Write method to save client name, and assign id.**_
* _**Write method to get client name, and id.**_
* _**Write test to check that client GetAll method returns an empty list.**_
* _**Write test to check that client GetAll method returns inputed new objects.**_
* _**Write test to test client save method is operational.**_
* _**Write client Equals method so as to separate primary data table and test data table. (Result in client GetAll and Save method tests passing).**_
* _**Write Find method to locate individual stylists based on their unique Id's.**_
* _**Write test for Find method to assert that input and result AreEqual based on the use of the Find Method using a unique Id.**_
* _**Write a method to return a list of the objects (Clients), associated with Stylists specified unique Id's.**_
* _**Write test for Get Method, and see that it returns an empty array if no Client is associated with a particular Stylist Id.**_
* _**Write test for Get Method, and see that it returns Client object list associated with Stylist, based on the Id of stylist, and the id_stylist of client.**_



## _Setup/Installation Requirements_

* _Clone repository to your desktop_
* _Open in Atom, or text and source code editor of your choosing._
* _CREATE Database Dice._
* _CREATE TABLE `Dice`.`User` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) NOT NULL , `distance` INT NOT NULL , `price` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;_
* _CREATE TABLE `Dice`.`Restaurants` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) NOT NULL , `longitude` INT NOT NULL , `latitude` INT NOT NULL , `menu` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;_
* _CREATE TABLE `Dice`.`User_Restaurants` ( `id` INT NOT NULL AUTO_INCREMENT , `user_id` INT NOT NULL , `restaurant_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;_



## Known Bugs

_There are no known bugs at this time._

## Support and contact details

_Tavish OKeefe: okeefe.tavish@gmail.com_

## Technologies Used

* _CSharp_
* _JavaScript_
* _PHPMyAdmin_

### License

Copyright (c) 2018, _Tavish O'Keefe_  

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:  

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE._
