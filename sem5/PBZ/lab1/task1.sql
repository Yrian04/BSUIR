--- 1.1. Получить полную информацию обо всех преподавателях. ---
select * from teachers;

--- 1.2. Получить полную информацию обо всех студенческих группах на специальности ЭВМ. ---
select * from stud_groups where specialization = "ЭВМ";

--- 1.3. Получить личный номер преподавателя и номера аудиторий, в которых они преподают предмет с кодовым номером 18П. ---
select teacherId, roomNumber from group_subject_teacher where subjectId = 18;

--- 1.4. Получить номера предметов и названия предметов, которые ведет преподаватель Костин. ---
select subjectId, subjects.name from group_subject_teacher
join subjects on subjects.id = subjectId
join teachers on teachers.id = teacherId
where teachers.second_name = "Костин";

--- 1.5. Получить номер группы, в которой ведутся предметы преподавателем Фроловым. ---
select groupId from group_subject_teacher
join teachers on teachers.id = teacherId
where teachers.second_name = "Фролов"
group by groupId;

--- 1.6. Получить информацию о предметах, которые ведутся на специальности АСОИ. ---
select * from subjects where specialization = "АСОИ";

--- 1.7. Получить информацию о преподавателях, которые ведут предметы на специальности АСОИ. ---
select * from teachers where specialization like '%АСОИ%';

--- 1.8. Получить фамилии преподавателей, которые ведут предметы в 210 аудитории. ---
select teachers.second_name from group_subject_teacher
join teachers on teachers.id = teacherId
where roomNumber = 210
group by teachers.second_name;

--- 1.9. Получить названия предметов и названия групп, которые ведут занятия в аудиториях с 100 по 200. ---
select subjects.name, stud_groups.name from group_subject_teacher
join subjects on subjects.id = subjectId
join stud_groups on stud_groups.id = groupId
where roomNumber between 100 and 200
group by subjects.name, stud_groups.name;

--- 1.10. Получить пары номеров групп с одной специальности. ---
select first.id, second.id from stud_groups as first
join stud_groups as second on second.specialization = first.specialization;

--- 1.11. Получить общее количество студентов, обучающихся на специальности ЭВМ. ---
select sum(size) from stud_groups where specialization = "ЭВМ";

--- 1.12. Получить номера преподавателей, обучающих студентов по специальности ЭВМ. ---
select teacherId from group_subject_teacher
join stud_groups on stud_groups.id = groupId
where stud_groups.specialization = "ЭВМ"
group by teacherId;

--- 1.13. Получить номера предметов, изучаемых всеми студенческими группами. ---
insert group_subject_teacher value (7, 12, 222, 234);

select id from subjects as s
where not exists (
	select g.id from stud_groups as g
    where g.id not in (
		select sb.groupId from group_subject_teacher as sb where sb.subjectId = s.id
    ) 
);

delete from group_subject_teacher 
where groupId = 7 and subjectId = 12 and teacherId = 222;

--- 1.14. Получить фамилии преподавателей, преподающих те же предметы, что и преподаватель преподающий предмет с номером 14П. ---
select second_name from teachers as t
where not exists (
	select gst.subjectId from group_subject_teacher as gst 
    where teacherId in (
		select gst1.teacherId from group_subject_teacher as gst1 
        where gst1.subjectId = 14
	) and st.subjectId not in (
		select gst2.subjectId from group_subject_teacher as gst2 
		where gst2.teacherId = t.id
    ) 
);

--- 1.15. Получить информацию о предметах, которые не ведет преподаватель с личным номером 221П. ---
select * from subjects
join group_subject_teacher on group_subject_teacher.subjectId = id
where not group_subject_teacher.teacherId = 221;

--- 1.16. Получить информацию о предметах, которые не изучаются в группе М-6. ---
select * from subjects
join group_subject_teacher on group_subject_teacher.subjectId = id
join stud_groups on stud_groups.id = group_subject_teacher.groupId
where not stud_groups.name = "M-6";

--- 1.17. Получить информацию о доцентах, преподающих в группах 3Г и 8Г. ---
select * from teachers
join group_subject_teacher on group_subject_teacher.teacherId = id
where group_subject_teacher.groupId in (3, 8) and position = "Доцент";

--- 1.18. Получить номера предметов, номера преподавателей, номера групп, в которых ведут занятия преподаватели с кафедры ЭВМ, имеющих специальность АСОИ. ---
select subjectId, teacherId, groupId from group_subject_teacher
join teachers on teachers.id = teacherId
where teachers.department = "ЭВМ" and specialization like '%АСОИ%';

--- 1.19. Получить номера групп с такой же специальностью, что и специальность преподавателей. ---
select groupId from group_subject_teacher
join stud_groups on stud_groups.id = groupId
join teachers on teachers.id = teacherId
where not locate(stud_groups.specialization, teachers.specialization) = 0
group by groupId;

--- 1.20. Получить номера преподавателей с кафедры ЭВМ, преподающих предметы по специальности, совпадающей со специальностью студенческой группы. ---
select t.id from (select * from teachers where department = "ЭВМ") as t
join group_subject_teacher on group_subject_teacher.teacherId = t.id
join stud_groups on stud_groups.id = group_subject_teacher.groupId
where not locate(stud_groups.specialization, t.specialization) = 0;

--- 1.21. Получить специальности студенческой группы, на которых работают преподаватели кафедры АСУ. ---
select stud_groups.specialization from stud_groups
join group_subject_teacher on group_subject_teacher.groupId = stud_groups.id
join teachers on teachers.id = group_subject_teacher.teacherId
where teachers.department = "АСУ";

--- 1.22. Получить номера предметов, изучаемых группой АС-8. ---
select subjects.id from subjects
join group_subject_teacher on group_subject_teacher.subjectId = subjects.id
join stud_groups on stud_groups.id = group_subject_teacher.groupId
where stud_groups.name = "АС-8";

--- 1.23. Получить номера студенческих групп, которые изучают те же предметы, что и студенческая группа АС-8. ---
select g.id from stud_groups as g
where not exists (
	select s1.id from subjects as s1
	join group_subject_teacher as gst1 on gst1.subjectId = s1.id
	join stud_groups as g1 on g1.id = gst1.groupId
	where g1.name = "АС-8" and s1.id not in (
		select s2.id from subjects as s2
		join group_subject_teacher as gst2 on gst2.subjectId = s2.id
		join stud_groups as g2 on g2.id = gst2.groupId
		where g2.id = g.id
	)
);

--- 1.24. Получить номера студенческих групп, которые не изучают предметы, преподаваемых в студенческой группе АС-8. ---
delete from group_subject_teacher 
where groupId = 3 and subjectId = 12;

select distinct gst.groupId from group_subject_teacher as gst
where not exists (
	select gst1.subjectId from group_subject_teacher as gst1
    where gst1.groupId = gst.groupId and gst1.subjectId in (
		select gst2.subjectId from group_subject_teacher as gst2
        join stud_groups as g2 on g2.id = gst2.groupId
        where g2.name = "АС-8"
    )
);

insert group_subject_teacher value (3, 12, 222, 112);

--- 1.25. Получить номера студенческих групп, которые не изучают предметы, преподаваемых преподавателем 430Л. ---
select distinct gst.groupId from group_subject_teacher as gst
where not exists (
	select gst1.subjectId from group_subject_teacher as gst1
    where gst1.groupId = gst.groupId and gst1.subjectId in (
		select gst2.subjectId from group_subject_teacher as gst2
        where gst2.teacherId = 430
    )
);

--- 1.26. Получить номера преподавателей, работающих с группой Э-15, но не преподающих предмет 12П. ---
select gst.teacherId from group_subject_teacher as gst
join stud_groups as g on g.id = gst.groupId
where g.name = "Э-15" and 12 not in (
	select gst1.subjectId from group_subject_teacher as gst1
    where gst1.teacherId = gst.teacherId
)