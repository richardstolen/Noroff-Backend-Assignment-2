Backend Development Assignment 2


Appendix B: Reading data with SQL Client
1) Introduction and overview
Some hotshot media mogul has heard of your newly acquired skills in C#. They have contracted you and a friend to
stride on the edge of copyright glory and start re-making iTunes, but under a different name. They have spoken to
lawyers and are certain a working prototype should not cause any problems and ensured that you will be safe. The
lawyer they use is the same that Epic has been using, so they are familiar with Apple.
The second part of the assignment deals with manipulating SQL Server data in Visual Studio using a library called SQL
Client. For this part of the assignment, you are given a database to work with. It is called Chinook.
Chinook models the iTunes database of customers purchasing songs. You are to create a C# console application, install
the SQL Client library, and create a repository to interact with the database.
NOTE: These requirements are separate from Appendix A.
2) Customer requirements
For customers in the database, the following functionality should be catered for:
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
