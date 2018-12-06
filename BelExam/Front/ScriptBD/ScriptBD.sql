IF EXISTS (SELECT * FROM SYS.procedures WHERE name = 'SP_PRODUCTO_SEARCH')
BEGIN
 DROP PROCEDURE SP_PRODUCTO_SEARCH;
END

GO

CREATE PROCEDURE SP_PRODUCTO_SEARCH(
@pAnioCampania INT = 0,
@pProductoNombre VARCHAR(30) = NULL
)
AS
BEGIN
 SET NOCOUNT ON;

 SELECT 
    PRO.AnioCampania,
	PRO.Cuv,PRO.MarcaID,
	MAR.Descripcion,
	PRO.Descripcion,
	PRO.CodigoTipoOferta,
	PRO.CodigoSAP,
	PRO.EstadoActivo
  FROM 
    dbo.Producto PRO INNER JOIN dbo.Marca MAR ON PRO.MarcaID = PRO.MarcaID
	AND PRO.AnioCampania = @pAnioCampania
	AND UPPER(PRO.Descripcion) LIKE '%'+ ISNULL(@pProductoNombre,'') +'%'
END
GO

