create schema task1;

use task1;

create table teachers(
	id int unsigned primary key,
    second_name varchar(40),
    position varchar(40),
    department varchar(40),
    specialization varchar(40),
    number varchar(10)
);

create table subjects(
	id int unsigned primary key,
    name varchar(40),
    hours int unsigned,
    specialization varchar(40),
    term int unsigned
);

create table stud_groups(
	id int unsigned primary key,
    name varchar(40),
    size int unsigned,
    specialization varchar(40),
	chief varchar(40)
);

create table group_subject_teacher(
	groupId int unsigned,
    subjectId int unsigned,
    teacherId int unsigned,
    roomNumber int unsigned,
	foreign key (groupId) references stud_groups(id) on delete cascade on update cascade,
	foreign key (subjectId) references subjects(id) on delete cascade on update cascade,
	foreign key (teacherId) references teachers(id) on delete cascade on update cascade
);

insert teachers values 
	(221, "Фролов", "Доцент", "ЭВМ", "АСОИ, ЭВМ", 487),
    (222, "Костин", "Доцент", "ЭВМ", "ЭВМ", 543),
    (225, "Бойко", "Профессор", "АСУ", "АСОИ, ЭВМ", 112),
    (430, "Глазов", "Ассистент", "ТФ", "СД", 421),
    (110, "Петров", "Ассистент", "Экономики", "Международная экономика", 324);

insert subjects values
	(12, "Мини ЭВМ", 36, "ЭВМ", 1),
    (14, "ПЭВМ", 72, "ЭВМ", 2),
    (17, "СУБД ПК", 48, "АСОИ", 4),
    (18, "ВКСС", 52, "АСОИ", 6),
    (34, "Физика", 30, "СД", 6),
    (22, "Аудит", 24, "Бухучет", 3);
    
insert stud_groups values
	(8, "Э-12", 18, "ЭВМ", "Иванова"),
    (7, "Э-15", 22, "ЭВМ", "Сеткин"),
    (4, "АС-9", 24, "АСОИ", "Балабанов"),
    (3, "АС-8", 20, "АСОИ", "Чижов"),
    (17, "С-14", 29, "СД", "Амросов"),
    (12, "М-6", 16, "Международная экономика", "Трубин"),
    (10, "Б-4", 21, "Бухучёт", "Зязюткин");
    
insert group_subject_teacher values
	(8, 12, 222, 112),
    (8, 14, 221, 220),
    (8, 17, 222, 112),
    (7, 14, 221, 220),
    (7, 17, 222, 241),
    (7, 18, 225, 210),
    (4, 12, 222, 112),
    (4, 18, 225, 210),
    (3, 12, 222, 112),
    (3, 17, 221, 241),
    (3, 18, 225, 210),
    (17, 12, 222, 112),
    (17, 22, 110, 220),
    (17, 34, 430, 118),
    (12, 12, 222, 112),
    (12, 22, 110, 210),
    (10, 12, 222, 210),
    (10, 22, 110, 210);