*********************
Developer Notes 
*********************

-----------
04-08-2014
-----------

1. Oracle Sql Developer - GUI tool for interacting with Oracle database

2. SID - Is name of the database to which your oracle connection string connects. Need to specify same in tnsnames.ora. Details at - http://stackoverflow.com/questions/43866/how-sid-is-different-from-service-name-in-oracle-tnsnames-ora

3. Tips from http://itbloggertips.com/2013/06/resolved-ora-12541-tns-no-listener-error/. Use commands in cmd (without hypehn)

Check listener status - lsnrctl status
Start listener if not running - lsnrctl start
Stop the listener, if listener is running - lsnrctl stop
Restart the listener - lsnrctl reload
See all available listener commands - lsnrctl help

-----------
05-08-2014
-----------

1. Oracle Select query is case sensitive for table names. And table names are in upper case in Oracle database.

2. Right click on Oracle database. Select 'Open SQL Worksheet' for testing queries.

3. Check existence of table - 

   (a) SELECT COUNT(1) FROM all_objects WHERE object_type IN ('TABLE','VIEW') AND object_name = 'tableName';

   (b) SELECT COUNT(1) FROM USER_TABLES WHERE TABLE_NAME = 'tableName';

   (c) SELECT TABLE_NAME FROM DBA_TABLES WHERE TABLE_NAME='VIKRAMTEST';