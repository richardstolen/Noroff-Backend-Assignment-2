# Backend Development Assignment 2

## Appendix A: SQL scripts to create database

1. [x] Create a script that contains a statement for creating a database. The database should be called SuperheroesDB. (01_dbCreate.sql)
2. [x] Create a script that contains a statement for creating the tables (Superhero, Assistant, Power). (02_tableCreate.sql)
3. [x] Create a script that contains a statement for creating the relationship between Superhero and Assistant
4. [x] Return a page of customers from the database. This should take in limit and offset as parameters and make use
of the SQL limit and offset keywords to get a subset of the customer data. The customer model from above
should be reused.
5. [ ] Add a new customer to the database. You also need to add only the fields listed above (our customer object)
6. [ ] Update an existing customer.
7. [ ] Return the number of customers in each country, ordered descending (high to low). i.e. USA: 13, ...
8. [ ] Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
9. [ ] For a given customer, their most popular genre (in the case of a tie, display both). Most popular in this context
means the genre that corresponds to the most tracks from invoices associated to that customer.


## Appendix B: Reading data with SQL Client

1) Introduction and overview
For this part of the assignment, you are given a database to work with. It is called Chinook.
Chinook models the iTunes database of customers purchasing songs. You are to create a C# console application, install
the SQL Client library, and create a repository to interact with the database.
NOTE: These requirements are separate from Appendix A.

2) Customer requirements

1. [x] Read all the customers in the database, this should display their: Id, first name, last name, country, postalcode, phone number and email.
2. [x] Read a specific customer from the database (by Id), should display everything listed in the above point.
3. [x] Read a specific customer by name. HINT: LIKE keyword can help for partial matches.
4. [x] Return a page of customers from the database. This should take in limit and offset as parameters and make use
of the SQL limit and offset keywords to get a subset of the customer data. The customer model from above
should be reused.
5. [ ] Add a new customer to the database. You also need to add only the fields listed above (our customer object)
6. [ ] Update an existing customer.
7. [ ] Return the number of customers in each country, ordered descending (high to low). i.e. USA: 13, ...
8. [ ] Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
9. [ ] For a given customer, their most popular genre (in the case of a tie, display both). Most popular in this context
means the genre that corresponds to the most tracks from invoices associated to that customer.
