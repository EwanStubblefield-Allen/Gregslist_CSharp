CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- FIXME maybe we need to change something

CREATE TABLE
    capybaras(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(10) NOT NULL COMMENT 'The name of our cute little dudes',
        ownedByGrandma BOOLEAN DEFAULT true COMMENT 'Keeps track of if this cute little dude was owned by a cute little grandma',
        birthday DATE NOT NULL,
        applesEaten SMALLINT UNSIGNED DEFAULT 0,
        livesAtFarm BOOLEAN NOT NULL DEFAULT FALSE
    ) default charset utf8 COMMENT '';

DROP TABLE capybaras;

ALTER TABLE capybaras
ADD
    livesAtFarm BOOLEAN NOT NULL DEFAULT FALSE;

INSERT INTO
    capybaras (
        name,
        ownedByGrandma,
        birthday,
        applesEaten
    )
VALUES (
        'Cappy',
        true,
        '1990-12-24',
        5000
    ), (
        'Tippy Toes',
        false,
        '2012-01-01',
        3
    );

SELECT name FROM capybaras;

SELECT name, applesEaten FROM capybaras;

SELECT * FROM capybaras;

SELECT * FROM capybaras WHERE name = 'Cappy';

SELECT * FROM capybaras WHERE name LIKE '%cap%';

SELECT * FROM capybaras WHERE id = 3;

SELECT * FROM capybaras LIMIT 1 OFFSET 1;

DELETE FROM capybaras WHERE id = 2 LIMIT 1 ;

UPDATE capybaras SET applesEaten = 9999 WHERE id = 3 LIMIT 1 ;

CREATE TABLE
    cars(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(300) NOT NULL,
        color VARCHAR(100) DEFAULT 'blue',
        year SMALLINT UNSIGNED DEFAULT 1990,
        price DECIMAL NOT NULL,
        ownedByGrandma BOOLEAN DEFAULT FALSE,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) default charset utf8 COMMENT '';

DROP TABLE cars;

INSERT INTO
    cars (
        make,
        model,
        color,
        year,
        ownedByGrandma,
        price
    )
VALUES (
        'mazda',
        'miata',
        'red',
        1996,
        true,
        6000
    );

SELECT LAST_INSERT_ID();