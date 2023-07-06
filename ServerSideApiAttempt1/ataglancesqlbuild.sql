-- Create the database
CREATE DATABASE AtAGlance;

-- Switch to the newly created database
USE AtAGlance;

-- Create the UserProfile table
CREATE TABLE [UserProfile] (
  [Id] INT PRIMARY KEY IDENTITY NOT NULL,
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [Name] NVARCHAR(255) NOT NULL,
  [Email] NVARCHAR(255) NOT NULL,
  [ImageUrl] NVARCHAR(255) NULL,
  [DateCreated] DATETIME NOT NULL,

  CONSTRAINT UQ_FirebaseUserId UNIQUE (FirebaseUserId)
);

-- Create the TodoList table
CREATE TABLE TodoList (
  id INT PRIMARY KEY IDENTITY,
  title VARCHAR(255) NOT NULL,
  description VARCHAR(255),
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  user_id INT NOT NULL,
  FOREIGN KEY (user_id) REFERENCES [UserProfile] (Id)
);

-- Create the Task table
CREATE TABLE Task (
  id INT PRIMARY KEY IDENTITY,
  title VARCHAR(255) NOT NULL,
  description VARCHAR(255),
  due_date DATE,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  todo_list_id INT NOT NULL,
  FOREIGN KEY (todo_list_id) REFERENCES TodoList (id)
);
