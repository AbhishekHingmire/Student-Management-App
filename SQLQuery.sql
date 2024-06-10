create database CRUD;
use crud;
drop table tbl_Departments;
truncate table tbl_Student;

create table tbl_Student(Id int primary key identity, Name varchar(20), Fname varchar(20), Email varchar(50), Mobile varchar(10), 
Description varchar(100), DeptID int);

create table tbl_Departments (Id int primary key identity, Department varchar(50));

INSERT INTO tbl_Student (Id, Name, Fname, Email, Mobile, Description, DeptID) VALUES
(1, 'John Doe', 'Michael Doe', 'john.doe@example.com', '1234567890', 'Computer Science major', 1),
(2, 'Jane Smith', 'David Smith', 'jane.smith@example.com', '9876543210', 'Electrical Engineering major', 2),
(3, 'Alice Johnson', 'Robert Johnson', 'alice.johnson@example.com', '4567890123', 'Business Administration major', 3);

INSERT INTO tbl_Departments(Department) VALUES
('Computer Science'),
('Electrical Engineering'),
('Business Administration');

select * from tbl_Student;
select * from tbl_Departments;