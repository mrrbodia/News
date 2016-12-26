CREATE TABLE [dbo].[Role] (
    [Id]   NVARCHAR (45) NOT NULL,
    [Name] NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
				
CREATE TABLE [dbo].[User] (
	[Id]           NVARCHAR (45)  NOT NULL,
	[Email]        NVARCHAR (50)  NULL,
	[Password]     NVARCHAR (255) NULL,
	[PasswordSalt] NVARCHAR (255) NULL,
	[Role_id]     NVARCHAR (45)  NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_User_Role] FOREIGN KEY ([Roles_id]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Comment](
	[Id] [nvarchar](255) NOT NULL,
	[AuthorId] [nvarchar](255) NULL,
	[AuthorName] [nvarchar](255) NULL,
	[PostingTime] [datetime] NULL,
	[Text] [nvarchar](255) NULL,
	[TidingId] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ContentBlock](
	[Id] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Type] [nvarchar](255) NULL,
	[Content] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[Page](
	[Id] [nvarchar](255) NOT NULL,
	[ContentBlocks] [xml] NULL,
	[Title] [nvarchar](300) NULL,
	[Url] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[Tidings](
	[Id] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Discription] [nvarchar](255) NULL,
	[AuthorId] [nvarchar](255) NULL,
	[PublishData] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]