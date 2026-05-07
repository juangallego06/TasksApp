DECLARE @UserId INT = 1;
DECLARE @Status NVARCHAR(20) = 'Pending';

SELECT
	T.Id,
	T.Title,
	T.Description,
	T.Status,
	U.UserName,
	U.Email,
	T.CreatedAt
FROM Task T
INNER JOIN [User] U ON U.Id = T.UserId
WHERE
	(@UserId IS NULL OR T.UserId = @UserId)
	AND
	(@Status IS NULL OR T.Status = @Status)
ORDER BY T.CreatedAt DESC