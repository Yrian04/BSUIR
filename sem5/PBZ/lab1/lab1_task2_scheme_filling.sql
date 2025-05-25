Create table suppliers
	(id int unsigned primary key not null auto_increment unique,
	name varchar(45) not null,
    status varchar(45) not null,
    location varchar(45) not null
);

Create table parts
	(id int unsigned primary key not null auto_increment unique,
	name varchar(45) not null,
    color varchar(45) not null,
    size int unsigned not null,
    location varchar(45) not null
);

Create table projects
	(id int unsigned primary key not null auto_increment unique,
	name varchar(45) not null,
    location varchar(45) not null
);

Create table suppliers_parts_projects
	(supplierId int unsigned,
    partId int unsigned,
    projectId int unsigned,
    number int unsigned,
    foreign key (supplierId) references suppliers (id),
    foreign key (partId) references parts (id),
    foreign key (projectId) references projects (id)
);




Insert suppliers (name, status, location) values
('Петров', 20, 'Москва'),
('Синицин', 10, 'Таллин'),
('Федоров', 30, 'Таллин'),
('Чаянов', 20, 'Минск'),
('Крюков', 30, 'Киев');

Insert parts (name, color, size, location) values
('Болт', 'Красный', 12, 'Москва'),
('Гайка', 'Зеленая', 17, 'Минск'),
('Диск', 'Черный', 17, 'Вильнюс'),
('Диск', 'Черный', 14, 'Москва'),
('Корпус', 'Красный', 12, 'Минск'),
('Крышки', 'Красный', 19, 'Москва');

Insert projects (name, location) values
('ИПР1', 'Минск'),
('ИПР2', 'Таллин'),
('ИПР3', 'Псков'),
('ИПР4', 'Псков'),
('ИПР5', 'Москва'),
('ИПР6', 'Саратов'),
('ИПР7', 'Москва');

Insert suppliers_parts_projects values
(1, 1, 1, 200),
(1, 1, 2, 700),
(2, 3, 1, 400),
(2, 2, 2, 200),
(2, 3, 3, 200),
(2, 3, 4, 500),
(2, 3, 5, 600),
(2, 3, 6, 400),
(2, 3, 7, 800),
(2, 5, 2, 100),
(3, 3, 1, 200),
(3, 4, 2, 500),
(4, 6, 3, 300),
(4, 6, 7, 300),
(5, 2, 2, 200),
(5, 2, 4, 100),
(5, 5, 5, 500),
(5, 5, 7, 100),
(5, 6, 2, 200),
(5, 1, 2, 100),
(5, 3, 4, 200),
(5, 4, 4, 800),
(5, 5, 4, 400),
(5, 6, 4, 500);