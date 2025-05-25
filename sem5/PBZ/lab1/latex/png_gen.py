import pandas as pd
import matplotlib.pyplot as plt
from sqlalchemy import create_engine

# Настройки подключения к базе данных
DATABASE_TYPE = 'mysql'  # Или другой тип базы данных (например, 'postgresql')
DBAPI = 'pymysql'  # Или другой драйвер для подключения
ENDPOINT = 'localhost'  # Адрес сервера базы данных
USER = 'root'  # Имя пользователя
PASSWORD = 'new_password'  # Пароль
PORT = 3306  # Порт (по умолчанию для MySQL)
DATABASE = 'lab 1'  # Имя базы данных
FILE_TYPE = 'tex'

# Создание подключения к базе данных
engine = create_engine(f'{DATABASE_TYPE}+{DBAPI}://{USER}:{PASSWORD}@{ENDPOINT}:{PORT}/{DATABASE}')

# Список SQL-запросов и имен файлов

queries = [
    # (Описание запроса, SQL-запрос, Имя файла изображения)
    # ("1.1. Получить полную информацию обо всех преподавателях",
    #  "select * from teachers",
    #  "task1_1"),
    #
    # ("1.2. Получить полную информацию обо всех студенческих группах на специальности ЭВМ",
    #  "select * from stud_groups where specialization = 'ЭВМ'",
    #  "task1_2"),
    #
    # ("1.3. Получить личный номер преподавателя и номера аудиторий, в которых они преподают предмет с кодовым номером 18П",
    #  "select teacherId, roomNumber from group_subject_teacher where subjectId = 18",
    #  "task1_3"),
    #
    # ("1.4. Получить номера предметов и названия предметов, которые ведет преподаватель Костин",
    #  "select subjectId, subjects.name from group_subject_teacher "
    #  "join subjects on subjects.id = subjectId "
    #  "join teachers on teachers.id = teacherId "
    #  "where teachers.second_name = 'Костин'",
    #  "task1_4"),
    #
    # ("1.5. Получить номер группы, в которой ведутся предметы преподавателем Фроловым",
    #  "select groupId from group_subject_teacher "
    #  "join teachers on teachers.id = teacherId "
    #  "where teachers.second_name = 'Фролов' "
    #  "group by groupId",
    #  "task1_5"),
    #
    # ("1.6. Получить информацию о предметах, которые ведутся на специальности АСОИ",
    #  "select * from subjects where specialization = 'АСОИ'",
    #  "task1_6"),
    #
    # ("1.7. Получить информацию о преподавателях, которые ведут предметы на специальности АСОИ",
    #  "select * from teachers where specialization regexp '.*АСОИ.*'",
    #  "task1_7"),
    #
    # ("1.8. Получить фамилии преподавателей, которые ведут предметы в 210 аудитории",
    #  "select teachers.second_name from group_subject_teacher "
    #  "join teachers on teachers.id = teacherId "
    #  "where roomNumber = 210 "
    #  "group by teachers.second_name",
    #  "task1_8"),
    #
    # ("1.9. Получить названия предметов и названия групп, которые ведут занятия в аудиториях с 100 по 200",
    #  "select subjects.name, stud_groups.name from group_subject_teacher "
    #  "join subjects on subjects.id = subjectId "
    #  "join stud_groups on stud_groups.id = groupId "
    #  "where roomNumber between 100 and 200 "
    #  "group by subjects.name, stud_groups.name",
    #  "task1_9"),
    #
    # ("1.10. Получить пары номеров групп с одной специальности",
    #  "select first.id, second.id from stud_groups as first "
    #  "join stud_groups as second on second.specialization = first.specialization",
    #  "task1_10"),
    #
    # ("1.11. Получить общее количество студентов, обучающихся на специальности ЭВМ",
    #  "select sum(size) from stud_groups where specialization = 'ЭВМ'",
    #  "task1_11"),
    #
    # ("1.12. Получить номера преподавателей, обучающих студентов по специальности ЭВМ",
    #  "select teacherId from group_subject_teacher "
    #  "join stud_groups on stud_groups.id = groupId "
    #  "where stud_groups.specialization = 'ЭВМ' "
    #  "group by teacherId",
    #  "task1_12"),
    #
    # ("1.13. Получить номера предметов, изучаемых всеми студенческими группами",
    #  "select id from subjects as s "
	#  "where not exists ( "
	#  "select g.id from stud_groups as g "
	#  "where g.id not in ( "
	#  "select sb.groupId from group_subject_teacher as sb where sb.subjectId = s.id "
	#  ") "
	#  ");",
    #  "task1_13"),
    #
    # ("1.14. Получить фамилии преподавателей, преподающих те же предметы, что и преподаватель преподающий предмет с номером 14П",
    #  "select second_name from teachers as t "
	#  "where not exists ( "
	#  "select gst.subjectId from group_subject_teacher as gst "
	#  "where teacherId in ( "
	#  "select gst1.teacherId from group_subject_teacher as gst1 "
	#  "where gst1.subjectId = 14 "
	#  ") and gst.subjectId not in ( "
	#  "select gst2.subjectId from group_subject_teacher as gst2 "
	#  "where gst2.teacherId = t.id "
	#  ") "
	#  ");",
    #  "task1_14"),
    #
    # ("1.15. Получить информацию о предметах, которые не ведет преподаватель с личным номером 221П",
    #  "select * from subjects "
    #  "join group_subject_teacher on group_subject_teacher.subjectId = id "
    #  "where not group_subject_teacher.teacherId = 221",
    #  "task1_15"),
    #
    # ("1.16. Получить информацию о предметах, которые не изучаются в группе М-6",
    #  "select * from subjects "
    #  "join group_subject_teacher on group_subject_teacher.subjectId = id "
    #  "join stud_groups on stud_groups.id = group_subject_teacher.groupId "
    #  "where not stud_groups.name = 'M-6'",
    #  "task1_16"),
    #
    # ("1.17. Получить информацию о доцентах, преподающих в группах 3Г и 8Г",
    #  "select * from teachers "
    #  "join group_subject_teacher on group_subject_teacher.teacherId = id "
    #  "where group_subject_teacher.groupId in (3, 8) and position = 'Доцент'",
    #  "task1_17"),
    #
    # ("1.18. Получить номера предметов, номера преподавателей, номера групп, в которых ведут занятия преподаватели с кафедры ЭВМ, имеющих специальность АСОИ",
    #  "select subjectId, teacherId, groupId from group_subject_teacher "
    #  "join teachers on teachers.id = teacherId "
    #  "where teachers.department = 'ЭВМ' and specialization regexp '.*АСОИ.*'",
    #  "task1_18"),
    #
    # ("1.19. Получить номера групп с такой же специальностью, что и специальность преподавателей",
    #  "select groupId from group_subject_teacher "
    #  "join stud_groups on stud_groups.id = groupId "
    #  "join teachers on teachers.id = teacherId "
    #  "where not locate(stud_groups.specialization, teachers.specialization) = 0 "
    #  "group by groupId",
    #  "task1_19"),
    #
    # ("1.20. Получить номера преподавателей с кафедры ЭВМ, преподающих предметы по специальности, совпадающей со специальностью студенческой группы",
    #  "select t.id from (select * from teachers where department = 'ЭВМ') as t "
    #  "join group_subject_teacher on group_subject_teacher.teacherId = t.id "
    #  "join stud_groups on stud_groups.id = group_subject_teacher.groupId "
    #  "where not locate(stud_groups.specialization, t.specialization) = 0",
    #  "task1_20"),
    #
    # ("1.21. Получить специальности студенческой группы, на которых работают преподаватели кафедры АСУ",
    #  "select stud_groups.specialization from stud_groups "
    #  "join group_subject_teacher on group_subject_teacher.groupId = stud_groups.id "
    #  "join teachers on teachers.id = group_subject_teacher.teacherId "
    #  "where teachers.department = 'АСУ'",
    #  "task1_21"),
    #
    # ("1.22. Получить номера предметов, изучаемых группой АС-8",
    #  "select subjects.id from subjects "
    #  "join group_subject_teacher on group_subject_teacher.subjectId = subjects.id "
    #  "join stud_groups on stud_groups.id = group_subject_teacher.groupId "
    #  "where stud_groups.name = 'АС-8'",
    #  "task1_22"),
    #
    # ("1.23. Получить номера студенческих групп, которые изучают те же предметы, что и студенческая группа АС-8",
    #  "select g.id from stud_groups as g "
	#  "where not exists ( "
	#  "select s1.id from subjects as s1 "
	#  "join group_subject_teacher as gst1 on gst1.subjectId = s1.id "
	#  "join stud_groups as g1 on g1.id = gst1.groupId "
	#  "where g1.name = 'АС-8' and s1.id not in ( "
	#  "select s2.id from subjects as s2 "
	#  "join group_subject_teacher as gst2 on gst2.subjectId = s2.id "
	#  "join stud_groups as g2 on g2.id = gst2.groupId "
	#  "where g2.id = g.id "
	#  ") "
	#  ");",
    #  "task1_23"),
    #
    # ("1.24. Получить номера студенческих групп, которые не изучают предметы, преподаваемых в студенческой группе АС-8",
    #  "select distinct gst.groupId from group_subject_teacher as gst "
    #  "where not exists ( "
    #  "  select gst1.subjectId from group_subject_teacher as gst1 "
    #  "  where gst1.groupId = gst.groupId and gst1.subjectId in ( "
    #  "    select gst2.subjectId from group_subject_teacher as gst2 "
    #  "    join stud_groups as g2 on g2.id = gst2.groupId "
    #  "    where g2.name = 'АС-8' "
    #  "  ) "
    #  ");",
    #  "task1_24"),
    #
    # ("1.25. Получить номера студенческих групп, которые не изучают предметы, преподаваемых преподавателем 430Л",
    #  "select distinct gst.groupId from group_subject_teacher as gst "
    #  "where not exists ( "
    #  "  select gst1.subjectId from group_subject_teacher as gst1 "
    #  "  where gst1.groupId = gst.groupId and gst1.subjectId in ( "
    #  "    select gst2.subjectId from group_subject_teacher as gst2 "
    #  "    where gst2.teacherId = 430 "
    #  "  ) "
    #  ")",
    #  "task1_25"),
    #
    # ("1.26. Получить номера преподавателей, работающих с группой Э-15, но не преподающих предмет 12П",
    #  "select gst.teacherId from group_subject_teacher as gst "
    #  "join stud_groups as g on g.id = gst.groupId "
    #  "where g.name = 'Э-15' and 12 not in ( "
    #  "  select gst1.subjectId from group_subject_teacher as gst1 "
    #  "  where gst1.teacherId = gst.teacherId "
    #  ")",
    #  "task1_26"),
     
     ("31. Получить номера поставщиков, поставляющих одну и ту же деталь для всех проектов",
     "SELECT supplierId FROM suppliers_parts_projects "
     "GROUP BY supplierId "
     "HAVING COUNT(DISTINCT partId) = 1",
     "task2_31"),

    ("12. Получить номера деталей, поставляемых для всех проектов, обеспечиваемых поставщиком из того же города, где размещен проект",
     "SELECT partId FROM suppliers_parts_projects "
     "JOIN suppliers ON supplierId = suppliers.id "
     "JOIN projects ON projectId = projects.id "
     "WHERE suppliers.location = projects.location "
     "GROUP BY partId",
     "task2_12"),

    ("20. Получить цвета деталей, поставляемых поставщиком П1",
     "SELECT color FROM parts "
     "JOIN suppliers_parts_projects ON suppliers_parts_projects.partId = parts.id "
     "WHERE suppliers_parts_projects.supplierId = 1 "
     "GROUP BY color",
     "task2_20"),

    ("13. Получить номера проектов, обеспечиваемых по крайней мере одним поставщиком не из того же города",
     "SELECT projectId FROM suppliers_parts_projects "
     "JOIN suppliers ON suppliers.id = supplierId "
     "JOIN projects ON projects.id = projectId "
     "WHERE suppliers.location != projects.location "
     "GROUP BY projectId",
     "task2_13"),

    ("24. Получить номера поставщиков со статусом, меньшим чем у поставщика П1",
     "SELECT id FROM suppliers "
     "WHERE status < (SELECT status FROM suppliers AS sub WHERE sub.id = 1)",
     "task2_24"),

    ("2. Получить полную информацию обо всех проектах в Лондоне",
     "SELECT * FROM projects "
     "WHERE location = 'Лондон'",
     "task2_2"),

    ("6. Получить все такие тройки 'номера поставщиков-номера деталей-номера проектов', для которых поставщик, деталь и проект размещены в одном городе",
     "SELECT supplierId, partId, projectId FROM suppliers_parts_projects "
     "JOIN suppliers ON suppliers.id = supplierId "
     "JOIN parts ON parts.id = partId "
     "JOIN projects ON projects.id = projectId "
     "WHERE suppliers.location = parts.location AND parts.location = projects.location",
     "task2_6"),

    ("11. Получить все пары названий городов, для которых поставщик из первого города обеспечивает проект во втором городе",
     "SELECT suppliers.location, projects.location FROM suppliers_parts_projects "
     "JOIN suppliers ON suppliers.id = supplierId "
     "JOIN projects ON projects.id = projectId "
     "GROUP BY suppliers.location, projects.location",
     "task2_11"),

    ("8. Получить все такие тройки 'номера поставщиков-номера деталей-номера проектов', для которых никакие из двух выводимых поставщиков, деталей и проектов не размещены в одном городе",
     "SELECT supplierId, partId, projectId FROM suppliers_parts_projects "
     "JOIN suppliers ON suppliers.id = supplierId "
     "JOIN parts ON parts.id = partId "
     "JOIN projects ON projects.id = projectId "
     "WHERE NOT (suppliers.location = parts.location OR parts.location = projects.location OR suppliers.location = projects.location)",
     "task2_8"),

    ("26. Получить номера проектов, для которых среднее количество поставляемых деталей Д1 больше, чем наибольшее количество любых деталей, поставляемых для проекта ПР1",
     "SELECT id FROM projects "
     "JOIN suppliers_parts_projects ON suppliers_parts_projects.projectId = id "
     "WHERE suppliers_parts_projects.partId = 1 "
     "GROUP BY id "
     "HAVING AVG(number) > (SELECT MAX(a.part_num) FROM ( "
     "SELECT SUM(sub.number) AS part_num FROM suppliers_parts_projects AS sub "
     "WHERE sub.projectId = 1 "
     "GROUP BY sub.partId) AS a)",
     "task2_26"),
]

for description, query, filename in queries:
    # Выполнение запроса и получение результата в DataFrame
    df = pd.read_sql_query(query, engine)
    
    # Проверка, если DataFrame пустой
    if df.empty:
        print(f"Результат запроса '{description}' пуст. Файл {filename}.{FILE_TYPE}.")
        latex_table = "Здесь ничего нет"
    else:
        # Конвертация DataFrame в LaTeX формат
        latex_table = df.to_latex(index=False)

    # Сохранение LaTeX-таблицы в файл
    with open(f"{filename}.{FILE_TYPE}", 'w', encoding='utf-8') as f:
        f.write(latex_table)

    print(f"Сохранен результат запроса '{description}' в файл {filename}.{FILE_TYPE}")

