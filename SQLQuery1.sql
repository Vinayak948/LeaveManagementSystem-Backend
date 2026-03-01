-- Insert Employee Users
INSERT INTO [dbo].[Users] ([Name], [Email], [Password], [Role])
VALUES ('John Doe', 'john@example.com', 'password123', 'Employee');

INSERT INTO [dbo].[Users] ([Name], [Email], [Password], [Role])
VALUES ('Jane Smith', 'jane@example.com', 'password123', 'Employee');

INSERT INTO [dbo].[Users] ([Name], [Email], [Password], [Role])
VALUES ('Mike Johnson', 'mike@example.com', 'password123', 'Employee');

-- Insert Admin User
INSERT INTO [dbo].[Users] ([Name], [Email], [Password], [Role])
VALUES ('Admin User', 'admin@example.com', 'admin123', 'Admin');

-- Verify the data was inserted
SELECT * FROM [dbo].[Users];