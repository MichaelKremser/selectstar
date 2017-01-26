# selectstar

This program checks if "select * from..." works correctly on a table whose definition changes while the program is running. It is not intended for usage by a user but for an interested developer.

# History

I noticed that problems occur when changing the definition of a table after that table has been selected with "select * from..." when using ODP.net with Oracle 12.1. The following steps are necessary to reproduce the problem:

- Perform "select * " on a table
- Drop the table
- Create the table with another definition
- Perform "select * " on that table again --> Oracle throws interesting ORA-exceptions

After that, I was curious if this problems also happens with other DBMSs.

See this Stackoverflow question for for information: http://stackoverflow.com/questions/41803868/how-to-let-select-work-accordingly-after-table-was-modified?sgp=2

# Conclusion

I tried the steps above with Postgresql 9.3 and MySql 5.5 on Ubuntu 14.04 with a program written in C#. Both DBMSs behave correctly and return the correct columns in my setup. YMMV!
