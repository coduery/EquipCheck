/****** Create app_users table ******/

USE [equipment_checklist]
GO

/****** Object:  Table [dbo].[app_users]    Script Date: 10/24/2013 3:27:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[app_users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_app_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Create equipment_lists table ******/


USE [equipment_checklist]
GO

/****** Object:  Table [dbo].[equipment_lists]    Script Date: 10/24/2013 3:27:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[equipment_lists](
	[list_id] [int] IDENTITY(1,1) NOT NULL,
	[list_name] [nvarchar](50) NOT NULL,
	[list_description] [nvarchar](250) NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_equipment_lists] PRIMARY KEY CLUSTERED 
(
	[list_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[equipment_lists]  WITH CHECK ADD  CONSTRAINT [FK_equipment_lists_app_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[app_users] ([user_id])
GO

ALTER TABLE [dbo].[equipment_lists] CHECK CONSTRAINT [FK_equipment_lists_app_users]
GO





/****** Create equipment_items table ******/


USE [equipment_checklist]
GO

/****** Object:  Table [dbo].[equipment_items]    Script Date: 11/10/2013 10:02:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[equipment_items](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_name] [nvarchar](50) NOT NULL,
	[item_description] [nvarchar](250) NOT NULL,
	[list_id] [int] NOT NULL,
 CONSTRAINT [PK_equipment_items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[equipment_items]  WITH CHECK ADD  CONSTRAINT [FK_equipment_items_equipment_lists] FOREIGN KEY([list_id])
REFERENCES [dbo].[equipment_lists] ([list_id])
GO

ALTER TABLE [dbo].[equipment_items] CHECK CONSTRAINT [FK_equipment_items_equipment_lists]
GO



/****** Create checklists table ******/


USE [equipment_checklist]
GO

/****** Object:  Table [dbo].[checklists]    Script Date: 11/10/2013 10:03:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[checklists](
	[checklist_id] [int] IDENTITY(1,1) NOT NULL,
	[checklist_name] [nvarchar](50) NOT NULL,
	[checklist_description] [nvarchar](250) NOT NULL,
	[trip_name] [nvarchar](50) NULL,
	[trip_description] [nvarchar](250) NULL,
	[trip_date] [nvarchar](20) NULL,
	[checklist_summary] [ntext] NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_checklists] PRIMARY KEY CLUSTERED 
(
	[checklist_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[checklists]  WITH CHECK ADD  CONSTRAINT [FK_checklists_app_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[app_users] ([user_id])
GO

ALTER TABLE [dbo].[checklists] CHECK CONSTRAINT [FK_checklists_app_users]
GO




