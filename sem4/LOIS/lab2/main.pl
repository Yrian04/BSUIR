% Выполнил студент группы 221701 БГУИР Глёза Егор Дмитриевич
% 
% Предикаты для решения судоку
% 27.05.2024
%
% Источники:
% - https://www.swi-prolog.org/pldoc/man?predicate=%5C%2B/1
% - https://www.swi-prolog.org/pldoc/man?predicate=between/3
% - https://www.swi-prolog.org/pldoc/man?predicate=member/2
% - https://habr.com/ru/articles/552318/
%

sudoku(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16):-
    is_num_list([X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16]),
    check_rows(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16),
    check_columns(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16),
    check_squares(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16).

check_rows(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16):-
    neq([X1, X2, X3, X4]),
    neq([X5, X6, X7, X8]),
    neq([X9, X10, X11, X12]),
    neq([X13, X14, X15, X16]).

check_columns(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16):-
    neq([X1, X5, X9, X13]),
    neq([X2, X6, X10, X14]),
    neq([X3, X7, X11, X15]),
    neq([X4, X8, X12, X16]).

check_squares(X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16):-
    neq([X1, X2, X5, X6]),
    neq([X3, X4, X7, X8]),
    neq([X9, X10, X13, X14]),
    neq([X11, X12, X15, X16]).

neq([H | T]):-
    \+ member(H, T),
    neq(T).

neq([]).

is_num_list([H | T]):-
    between(1, 4, H),
    is_num_list(T).

is_num_list([]).
