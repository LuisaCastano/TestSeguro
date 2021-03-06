USE [EnsurancePolicy]
GO
SET IDENTITY_INSERT [dbo].[CoverageKind] ON 

INSERT [dbo].[CoverageKind] ([Id], [Name], [Description]) VALUES (1, N'Terremoto', NULL)
INSERT [dbo].[CoverageKind] ([Id], [Name], [Description]) VALUES (2, N'Incendio', NULL)
INSERT [dbo].[CoverageKind] ([Id], [Name], [Description]) VALUES (3, N'Robo', NULL)
INSERT [dbo].[CoverageKind] ([Id], [Name], [Description]) VALUES (4, N'Perdida', NULL)
SET IDENTITY_INSERT [dbo].[CoverageKind] OFF
SET IDENTITY_INSERT [dbo].[RiskKind] ON 

INSERT [dbo].[RiskKind] ([Id], [Name], [Description]) VALUES (1, N'Bajo', NULL)
INSERT [dbo].[RiskKind] ([Id], [Name], [Description]) VALUES (2, N'Medio', NULL)
INSERT [dbo].[RiskKind] ([Id], [Name], [Description]) VALUES (3, N'Medio-Alto', NULL)
INSERT [dbo].[RiskKind] ([Id], [Name], [Description]) VALUES (4, N'Alto', NULL)
SET IDENTITY_INSERT [dbo].[RiskKind] OFF
