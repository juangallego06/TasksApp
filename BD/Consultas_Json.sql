SELECT *
FROM Task
WHERE ISJSON(MetadataJson) = 1

GO

SELECT
  Title,
  JSON_VALUE(MetadataJson, '$.priority') AS Priority
FROM Task

GO

SELECT *
FROM Task
WHERE JSON_VALUE(MetadataJson, '$.priority') = 'High'

GO

SELECT *
FROM OPENJSON(
  '{"tags":["backend","urgent"]}'
)

GO

SELECT
	T.Title,
	JSON_QUERY(T.MetadataJson, '$.tags') AS Tags
FROM Task T
WHERE ISJSON(T.MetadataJson) = 1