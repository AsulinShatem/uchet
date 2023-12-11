UPDATE userloggs
SET password = CONVERT(varchar(64),
HASHBYTES('MD5',password),2)