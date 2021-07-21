CREATE TABLE tasks(  
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    creatorId VARCHAR(255) NOT NULL COMMENT 'creator id',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    taskName VARCHAR(255) COMMENT 'task name',
    listId INT NOT NULL COMMENT'foreign key'
) DEFAULT CHARSET utf8 COMMENT '';

CREATE TABLE lists(  
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
    creatorId VARCHAR(255) NOT NULL COMMENT 'creator id',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    listName VARCHAR(255) COMMENT 'list name'
) DEFAULT CHARSET utf8 COMMENT '';

SELECT l.*, a.* FROM lists l JOIN accounts a ON l.creatorId = a.id WHERE '{creatorId}' = creatorId;

INSERT INTO lists (creatorId, listName)
VALUES('60f86cd6eec732743d536248', 'test')
