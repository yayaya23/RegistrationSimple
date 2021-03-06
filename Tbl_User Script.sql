USE [WebPage]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 3/14/2020 7:53:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
