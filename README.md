
Problem 1.Database First 

In **company** , information about different **employees** and **projects** is held. Each employee has **first** and **last name** (both between 5 and 20 letters, inclusive), **year salary** , **manager** and **department**. Each **department** has **unique name** between 10 and 50 letters, inclusive. Each employee works on many projects. Each **project** has **name** between 5 and 50 letters, inclusive, and **employees** working on it. Each employee also has **starting** and **ending**** date **for each of his/her** projects **. Every single piece of information is** mandatory **, except** manager **– some employees do not have one. Additionally, every employee has to report every day when he/she got to work. Each** report **has** time** of reporting.

Design a database schema &quot; **Company**&quot; in SQL Server to keep the information about **employees** , **departments** , **projects** and **reports**. Ensure data integrity is fulfilled.

Provide a **SQL script for your database schema** (without the data), a backup (.bak file) from the database and a **simple documentation of the relationships** between the tables. Additionally, provide a **picture of the design diagram** describing your created database.

Problem 2.Sample Data 

Use C# to implement an application for generating random sample data in the company. Create at least:

- **100 departments**
- **5 000 employees** – each employee has department, 95% of them have managers and their salary is between $50 000 and $200 000, inclusive. There must be no cycles in the management tree –example for a cycle is Pesho&#39;s manager is Gosho, Gosho&#39;s manager is Ivan and Ivan&#39;s manager is Pesho.
- **1 000 projects** – on each project there are working between 2 and 20 employees, inclusive – average of 5. Ending date is always after starting date (you don&#39;t say) and ending date may be in the future.
- **250 000 reports** – add average of 50 reports per employee.

\* You are free to use an ORM framework by choice or plain ADO.NET.

\* Adding a lot of data may be slow, depending on your implementation, so be patient. Consider turning off the automatic change tracking in Entity Framework, if you use it.

\* All text can be random string with valid length depending on the field.

Problem 3.SQL Queries (18 points)

Write three queries in native SQL:

1. Get the full name (first name + &quot; &quot; + last name) of every employee and its salary, for each employee with salary between $100 000 and $150 000, inclusive. Sort the results by salary in ascending order.
2. Get all departments and how many employees there are in each one. Sort the result by the number of employees in descending order.
3. Get each employee&#39;s full name (first name + &quot; &quot; + last name), project&#39;s name, department&#39;s name, starting and ending date for each employee in project. Additionally get the number of all reports, which time of reporting is between the start and end date. Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)

Provide three .sql files with the three queries in them.

Problem 4.Performance Tuning (7 points)

Create a &quot;cache&quot; table for the third query from problem 3 and save all the results there for future querying. Provide the .sql file, containing the stored procedures which creates the table and inserts the data. You should write two stored procedures – one for creating the table and one for updating the data.

Problem 5.Code First (15 points)

In different **cities** , **cars** from different **manufacturers and dealers** are sold. Each **manufacturer** has name (mandatory with maximum of 10 symbols). Each **car** has manufacturer, model (maximum of 11 symbols), transmission type, year, price and dealer. All fields are mandatory. **Transmission type** can be manual or automatic. **Dealers** have name (mandatory with maximum of 50 symbols) and cities, in which they sold cars. Each **city** has name (mandatory with maximum of 10 symbols). Each city and each manufacturer is unique by their name.

Design a database schema &quot; **Cars**&quot; using Code First approach with Entity Framework.

Problem 6.Import from JSON File (15 points)

Write a **C# program** to **parse a number of JSON files** with name format &quot;data._number_.json&quot; holding a set of cars&#39; information in the format given below and **insert them into the database** :

| **data.0.json** |
| --- |
| [   {      &quot;Year&quot;:2014,      &quot;TransmissionType&quot;:0,      &quot;ManufacturerName&quot;:&quot;Mazda&quot;,      &quot;Model&quot;:&quot;6 Skyactiv&quot;,      &quot;Price&quot;:60000.0,      &quot;Dealer&quot;:{         &quot;Name&quot;:&quot;Star Motors&quot;,         &quot;City&quot;:&quot;Sofia&quot;      }   },   {      &quot;Year&quot;:2008,      &quot;TransmissionType&quot;:1,      &quot;ManufacturerName&quot;:&quot;BMW&quot;,      &quot;Model&quot;:&quot;320i Cabrio&quot;,      &quot;Price&quot;:30000.0,      &quot;Dealer&quot;:{         &quot;Name&quot;:&quot;MM Auto&quot;,         &quot;City&quot;:&quot;Sofia&quot;      }   },   {      &quot;Year&quot;:2003,      &quot;TransmissionType&quot;:0,      &quot;ManufacturerName&quot;:&quot;Renaut&quot;,      &quot;Model&quot;:&quot;Clio 1.4&quot;,      &quot;Price&quot;:5500.0,      &quot;Dealer&quot;:{         &quot;Name&quot;:&quot;T Моторс&quot;,         &quot;City&quot;:&quot;Sofia&quot;      }   },   {      &quot;Year&quot;:1997,      &quot;TransmissionType&quot;:0,      &quot;ManufacturerName&quot;:&quot;Opel&quot;,      &quot;Model&quot;:&quot;Tigra&quot;,      &quot;Price&quot;:5000.0,      &quot;Dealer&quot;:{         &quot;Name&quot;:&quot;TA Моторс&quot;,         &quot;City&quot;:&quot;Sofia&quot;      }   }] |

\* You are free to use a JSON parser by choice (or to parse the JSON without using a parser).

You should correctly **import the cars, manufacturers, dealers and cities into the DB**. Keep in mind that the cities and manufacturers are unique. If some city or manufacturer already exists in the database, it should be reused (no duplicates are allowed).

\* You are free to use an ORM framework by choice (in code first).

Problem 7.Application Queries (20 points)

Implement a **C# program** for **searching for cars**** by given conditions **. It should be able to process a sequence of queries from the XML file** queries.xml** in the following format:

| **queries.xml** |
| --- |
| &lt;?xml version=&quot;1.0&quot;?&gt;&lt;Queries xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;  &lt;Query OutputFileName=&quot;Result0.xml&quot;&gt;    &lt;OrderBy&gt;Id&lt;/OrderBy&gt;    &lt;WhereClauses&gt;      &lt;WhereClause PropertyName=&quot;City&quot; Type=&quot;Equals&quot;&gt;Sofia&lt;/WhereClause&gt;      &lt;WhereClause PropertyName=&quot;Year&quot; Type=&quot;GreaterThan&quot;&gt;1999&lt;/WhereClause&gt;    &lt;/WhereClauses&gt;  &lt;/Query&gt;&lt;/Queries&gt; |

Each query has different output file, provided in the &quot;OutputFileName&quot; attribute.

The queries can have two types of parameters - ordering and where clauses.

Ordering the results can be done by the following fields: Id, Year, Model, Price, Manufacturer (its name) and Dealer (its name).

Where clauses can be one or many. If many where clauses are provided, use &quot;and&quot; as logical operator between them. Where clauses have two attributes for defining the query – &quot;PropertyName&quot; and &quot;Type&quot;. &quot;PropertyName&quot; defines by which car property the search should be done. &quot;Type&quot; defines the type of comparer to use in the search. The following list gives you the available property types and comparers for each of them:

- Id (number) -&gt; Equals, GreaterThan, LessThan
- Year (number) -&gt; Equals, GreaterThan, LessThan
- Price (floating point number) -&gt; Equals, GreaterThan, LessThan
- Model (text) -&gt; Equals, Contains
- Manufacturer (its name, text) -&gt; Equals, Contains
- Dealer (its name, text) -&gt; Equals, Contains
- City (its name) -&gt; Equals

&quot;GreaterThan&quot; and &quot;LessThan&quot; does not include equal elements.

Write the results in the corresponding XML files in the following format:

| &lt;?xml version=&quot;1.0&quot;?&gt;&lt;Cars xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;  &lt;Car Manufacturer=&quot;Mazda&quot; Model=&quot;6 Skyactiv&quot; Year=&quot;2014&quot; Price=&quot;60000.00&quot;&gt;    &lt;TransmissionType&gt;manual&lt;/TransmissionType&gt;    &lt;Dealer Name=&quot;Star Motors&quot;&gt;      &lt;Cities&gt;        &lt;City&gt;Sofia&lt;/City&gt;      &lt;/Cities&gt;    &lt;/Dealer&gt;  &lt;/Car&gt;  &lt;Car Manufacturer=&quot;BMW&quot; Model=&quot;320i Cabrio&quot; Year=&quot;2008&quot; Price=&quot;30000.00&quot;&gt;    &lt;TransmissionType&gt;automatic&lt;/TransmissionType&gt;    &lt;Dealer Name=&quot;MM Auto&quot;&gt;      &lt;Cities&gt;        &lt;City&gt;Sofia&lt;/City&gt;      &lt;/Cities&gt;    &lt;/Dealer&gt;  &lt;/Car&gt;  &lt;Car Manufacturer=&quot;Renaut&quot; Model=&quot;Clio 1.4&quot; Year=&quot;2003&quot; Price=&quot;5500.00&quot;&gt;    &lt;TransmissionType&gt;manual&lt;/TransmissionType&gt;    &lt;Dealer Name=&quot;TA Моторс&quot;&gt;      &lt;Cities&gt;        &lt;City&gt;Sofia&lt;/City&gt;        &lt;City&gt;Kyustendil&lt;/City&gt;      &lt;/Cities&gt;    &lt;/Dealer&gt;  &lt;/Car&gt;&lt;/Cars&gt; |
| --- |
