CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

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

CREATE TABLE
    houses(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
        bedrooms INT UNSIGNED NOT NULL COMMENT 'Number of bedrooms',
        bathrooms DECIMAL UNSIGNED NOT NULL COMMENT 'Number of bathrooms',
        year INT UNSIGNED NOT NULL COMMENT 'Year built',
        price DECIMAL UNSIGNED NOT NULL COMMENT 'Price of house',
        description VARCHAR(255) COMMENT 'Description of house',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) default charset utf8 COMMENT '';

DROP TABLE houses;

INSERT INTO
    houses(
        bedrooms,
        bathrooms,
        year,
        price,
        description
    )
VALUES (
        2,
        1.5,
        2001,
        1000,
        "This is a house"
    );

CREATE Table
    jobs(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
        position VARCHAR(255) NOT NULL COMMENT 'Job Position',
        salary INT UNSIGNED NOT NULL COMMENT 'Job salary',
        isFullTime BOOLEAN DEFAULT true COMMENT 'Is job full time',
        schedule ENUM (
            'Weekdays',
            'Weekends',
            'Flexible',
            'OnCall'
        ) NOT NULL COMMENT 'Job schedule',
        description VARCHAR(255) NOT NULL COMMENT 'Job description'
    ) default charset utf8 COMMENT '';

INSERT INTO
    jobs(
        position,
        salary,
        isFullTime,
        schedule,
        description
    )
VALUES
(
        'Something',
        5,
        true,
        'Weekdays',
        'No of your business'
    );