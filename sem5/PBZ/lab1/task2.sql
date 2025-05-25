--- 31. Получить номера поставщиков, поставляющих одну и ту же деталь для всех проектов.

Select supplierId from suppliers_parts_projects
group by supplierId
having count(distinct partId) = 1;

--- 12. Получить номера деталей, поставляемых для всех проектов, обеспечиваемых поставщиком из
--- того же города, где размещен проект.

select partId from	suppliers_parts_projects
join suppliers on supplierId = suppliers.id
join projects on projectId = projects.id
where suppliers.location = projects.location
group by partId;

--- 20. Получить цвета деталей, поставляемых поставщиком П1.

select color from parts
join suppliers_parts_projects on suppliers_parts_projects.partId = id
where suppliers_parts_projects.supplierId = 1
group by color;

--- 13. Получить номера проектов, обеспечиваемых по крайней мере одним поставщиком не из того же города.

select projectId from suppliers_parts_projects
join suppliers on suppliers.id = supplierId
join projects on projects.id = projectId
where suppliers.location != projects.location
group by projectId;

--- 24. Получить номера поставщиков со статусом, меньшим чем у поставщика П1.

select id from suppliers
where status < (select status from suppliers as sub where sub.id = 1);

--- 2. Получить полную информацию обо всех проектах в Лондоне.

select * from projects
where location = "Лондон";

--- 6. Получить все такие тройки "номера поставщиков-номера деталей-номера проектов", для которых
--- выводимые поставщик, деталь и проект размещены в одном городе.

select supplierId, partId, projectId from suppliers_parts_projects
join suppliers on suppliers.id = supplierId
join parts on parts.id = partId
join projects on projects.id = projectId
where suppliers.location = parts.location and parts.location = projects.location;

--- 11. Получить все пары названий городов, для которых поставщик из первого города обеспечивает
--- проект во втором городе.

select suppliers.location, projects.location from suppliers_parts_projects
join suppliers on suppliers.id = supplierId
join projects on projects.id = projectId
group by suppliers.location, projects.location;

--- 8. Получить все такие тройки "номера поставщиков-номера деталей-номера проектов", для которых
--- никакие из двух выводимых поставщиков, деталей и проектов не размещены в одном городе.

select supplierId, partId, projectId from suppliers_parts_projects
join suppliers on suppliers.id = supplierId
join parts on parts.id = partId
join projects on projects.id = projectId
where not (suppliers.location = parts.location or parts.location = projects.location or suppliers.location = projects.location);

--- 26. Получить номера проектов, для которых среднее количество поставляемых деталей Д1 больше,
--- чем наибольшее количество любых деталей, поставляемых для проекта ПР1.

select id from projects
join suppliers_parts_projects on suppliers_parts_projects.projectId = id
where suppliers_parts_projects.partId = 1
group by id
having avg(number) > (select max(a.part_num) from (
	select sum(sub.number) as part_num from suppliers_parts_projects as sub
    where sub.projectId = 1
    group by sub.partId) as a
    );