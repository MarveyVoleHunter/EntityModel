SET NOCOUNT ON

DECLARE @CRLF char(1) = CHAR(13) + CHAR(10)

SELECT cm.ColumnMapID, ColumnName, cm.Required, ISNULL(ep.DisplayOrder, 0) AS DisplayOrder, CONVERT(sql_variant, null) AS Value,
    CASE DataType WHEN 'entity' THEN 'Guid?'
        WHEN 'string' then 'string'
        WHEN 'boolean' then 'bool?'
        WHEN 'date' then 'DateTime?'
        WHEN 'datetime' then 'DateTime?'
        WHEN 'float' then 'decimal?'
        WHEN 'price' then 'decimal?'
        ELSE DataType + '?'
    END AS DataType
INTO #Props
FROM PNColumnmap cm
JOIN PNEntityProperty ep ON ep.ColumnMapID = cm.ColumnMapID
LEFT JOIN PNEntityPropertyGroup epg On epg.EntityPropertyGroupUID = ep.EntityPropertyGroupUID
WHERE cm.EntityTypeID = 'OWNPRODUCT'
ORDER BY epg.DisplayOrder, ep.DisplayOrder

DECLARE @SQL nvarchar(max) = ''
SELECT @SQL += 'UPDATE #Props SET Value = (SELECT TOP 1 ' + ColumnName + ' FROM pnownproduct ORDER BY 1) WHERE ColumnName = ''' + ColumnName + ''''
FROM #Props
EXEC (@SQL)

SELECT
    'new EntityProperty<' + DataType + '>' + @CRLF +
    '{' + @CRLF +
    '    Id = ' + CONVERT(varchar(10), ColumnMapID) + ',' + @CRLF +
    '    Name = "' + ColumnName + '",' + @CRLF +
    '    DisplayOrder = ' + CONVERT(varchar(10), DisplayOrder) + ',' + @CRLF +
    '    Required = ' + CASE WHEN Required = 1 THEN 'true' ELSE 'false' END + ',' + @CRLF +
    '    TxId = ' + CONVERT(varchar(10), DisplayOrder) + ',' + @CRLF +
    CASE
        WHEN Value IS NULL THEN ''
        WHEN DataType IN ('bool?') THEN '    Value = ' + CASE WHEN Value = 1 THEN 'true' ELSE 'false' END + @CRLF
        WHEN DataType IN ('decimal?') THEN '    Value = ' + FORMAT(CONVERT(decimal(18,9), Value), 'N') + 'm' + @CRLF
        WHEN DataType IN ('int?') THEN '    Value = ' + CONVERT(varchar(50), Value) + @CRLF
        WHEN DataType IN ('DateTime?', 'int?') THEN '    Value = DateTime.Parse("' + CONVERT(varchar(50), Value, 120) + '")' + @CRLF
        WHEN DataType IN ('Guid?') THEN '    Value = new Guid("' + CONVERT(varchar(50), Value) + '")' + @CRLF
        ELSE ' Value = "' + CONVERT(varchar(50), Value) + '"' + @CRLF
    END +
    '},'
FROM #Props
--select * from #Props
drop table #Props