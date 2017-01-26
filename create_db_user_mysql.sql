create database playground;
create user 'testuser'@'localhost' identified by 'TestUser#';
GRANT ALL PRIVILEGES ON playground.* to 'testuser'@'localhost' with grant option;
