/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[USP_GetProducto]
@Nombre VARCHAR(50)='',
@Estado BIT=NULL
AS
BEGIN
SELECT IdProducto, Nombre, Precio, FechaCreacion,Estado
FROM Producto
WHERE (Nombre Like '%'+@Nombre+'%' OR @Nombre='')
AND (Estado=@Estado OR @Estado IS NULL)
END

ALTER PROC [dbo].[USP_InsProducto]
@IdProducto int=0,
@Nombre VARCHAR(50)='',
@Precio DECIMAL(10,2) = 0.00,
@FechaCreacion Date='20221220',
@Estado BIT=NULL
AS
BEGIN
INSERT INTO Producto(IdProducto,Nombre,Precio,FechaCreacion,Estado)
VALUES (@IdProducto,@Nombre,@Precio,@FechaCreacion,@Estado)
END

ALTER PROC [dbo].[USP_UpdProducto]
@IdProducto int=0,
@Nombre VARCHAR(50)='',
@Precio DECIMAL(10,2) = 0.00,
@FechaCreacion Date='20221220',
@Estado BIT=NULL
AS
BEGIN
UPDATE Producto
SET Nombre = @Nombre, Precio = @Precio,FechaCreacion = @FechaCreacion, Estado = @Estado
WHERE IdProducto = @IdProducto
END

CREATE PROC [dbo].[USP_DelProducto]
@IdProducto int=0,
@Estado BIT=NULL
AS
BEGIN
UPDATE Producto
SET Estado = @Estado
WHERE IdProducto = @IdProducto
END


[USP_GetProducto] ''
[USP_InsProducto] 3, LaptopLG, 2300.99, '20220322',1
[USP_UpdProducto] 3, LaptopLenovo, 2030.12, '20220225',1
[USP_UpdProducto] 4, ParlanteXL, 95.99, '20220526',0
[USP_DelProducto] 3, 0