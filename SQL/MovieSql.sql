use testdb;
CREATE TABLE[dbo].[Movie](
ID[int]NOT NULL,
Title[nvarchar](20)NOT NULL,
MLanguage[nvarchar](20)NOT NULL,
Hero[nvarchar](20)NOT NULL,
Director[nvarchar](20)NOT NULL,
MusicDirector[nvarchar](20)NOT NULL,
ReleaseDate[Date]NOT NULL,
Cost[numeric](18,0)NOT NULL,
MCollection[NUMERIC](18,0)NOT NULL,
Review[nvarchar](40)NOT NULL,

CONSTRAINT [PK_Movie]PRIMARY KEY CLUSTERED (ID ASC));
---ALTER TABLE[dbo].[Movie] WITH CHECK ADD CONSTRAINT
---[CK_Movie_ MLanguage] CHECK(([MLanguage]='Tamil' OR [MLanguage]='English'))