ALTER TABLE [dbo].[inspections] DROP CONSTRAINT [FK_inspections_inspectors]
GO
ALTER TABLE [dbo].[inspections] DROP CONSTRAINT [FK_inspections_inspection_codes2]
GO
ALTER TABLE [dbo].[inspections] DROP CONSTRAINT [FK_inspections_inspection_codes1]
GO
ALTER TABLE [dbo].[inspections] DROP CONSTRAINT [FK_inspections_inspection_codes]
GO
ALTER TABLE [dbo].[inspections] DROP CONSTRAINT [FK_inspections_bridge_inventory]
GO
ALTER TABLE [dbo].[bridge_inventory] DROP CONSTRAINT [FK_bridge_inventory_status_codes]
GO
ALTER TABLE [dbo].[bridge_inventory] DROP CONSTRAINT [FK_bridge_inventory_material_designs]
GO
ALTER TABLE [dbo].[bridge_inventory] DROP CONSTRAINT [FK_bridge_inventory_functional_classes]
GO
ALTER TABLE [dbo].[bridge_inventory] DROP CONSTRAINT [FK_bridge_inventory_counties]
GO
ALTER TABLE [dbo].[bridge_inventory] DROP CONSTRAINT [FK_bridge_inventory_construction_designs]
GO
/****** Object:  Table [dbo].[status_codes]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[status_codes]
GO
/****** Object:  Table [dbo].[material_designs]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[material_designs]
GO
/****** Object:  Table [dbo].[maintenance_actions]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[maintenance_actions]
GO
/****** Object:  Table [dbo].[maintenace]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[maintenace]
GO
/****** Object:  Table [dbo].[inspectors]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[inspectors]
GO
/****** Object:  Table [dbo].[inspections]    Script Date: 1/29/2017 8:54:34 PM ******/
DROP TABLE [dbo].[inspections]
GO
/****** Object:  Table [dbo].[inspection_codes]    Script Date: 1/29/2017 8:54:35 PM ******/
DROP TABLE [dbo].[inspection_codes]
GO
/****** Object:  Table [dbo].[functional_classes]    Script Date: 1/29/2017 8:54:35 PM ******/
DROP TABLE [dbo].[functional_classes]
GO
/****** Object:  Table [dbo].[counties]    Script Date: 1/29/2017 8:54:35 PM ******/
DROP TABLE [dbo].[counties]
GO
/****** Object:  Table [dbo].[construction_designs]    Script Date: 1/29/2017 8:54:35 PM ******/
DROP TABLE [dbo].[construction_designs]
GO
/****** Object:  Table [dbo].[bridge_inventory]    Script Date: 1/29/2017 8:54:35 PM ******/
DROP TABLE [dbo].[bridge_inventory]
GO
