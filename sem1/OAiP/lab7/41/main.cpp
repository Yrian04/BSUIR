#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <io.h>
#include <string.h>

struct Student
{
    char Surname[20];
    char Number[7];
    int Physics;
    int Math;
    int Informatics;
};

void Create(char*);
void Show(char*);
void Add(char*);
void Solve(char*);
void Edit(char*);
void Delete(char*);
void Sort(char*);

int main()
{
    char c, file[20];
    printf("Choose file or create new?(1/2)");
    while (true)
    {
        rewind(stdin);
        scanf("%c", &c);
        switch (c)
        {
        case '1':
            printf("Choose file: ");
            scanf("%s", file);
            break;
        case '2':
            Create(file);
            break;
        default:
            printf("Try again...");
            continue;
        }
        break;
    }
    while (true) {
        printf("Choose action:\n\t1 - Create\n\t2 - Show\n\t3 - Add\n\t4 - Solve\n\t5 - Edit\n\t6 - Delete\n\t7 - Sort\n");
        while (true)
        {
            rewind(stdin);
            scanf("%c", &c);
            switch (c) {
            case '1':
                Create(file);
                break;
            case '2':
                Show(file);
                break;
            case '3':
                Add(file);
                break;
            case '4':
                Solve(file);
                break;
            case '5':
                Edit(file);
                break;
            case '6':
                Delete(file);
                break;
            case '7':
                Sort(file);
                break;
            default:
                printf("Try again...(not %c)", c);
                continue;
            }
            break;
        }
    }
}

void PrintStudent(Student st){
    printf("\tSurname: %s\n\tGroup: %s\n\tPhisics: %d\n\tMath: %d\n\tInformatics: %d\n-------------\n",
        st.Surname, st.Number, st.Physics, st.Math, st.Informatics);
}

void Create(char* file) {
    printf("Enter name of file: ");
    scanf("%s", file);
    FILE* f = fopen(file, "wb");
    fclose(f);
    if (f != NULL)
        printf("File was created successfully\n");
    else
        printf("File was not created");
}

void Show(char* file) {
    FILE* f = fopen(file, "rb");
    int n = _filelength(_fileno(f)) / sizeof(Student);
    Student* sts = new Student[n];
    fread(sts, sizeof(Student), n, f);
    printf("List of students:\n");
    for (int i = 0; i < n; i++)
        PrintStudent(sts[i]);
}

void Add(char* file){
    Student st;
    printf("Enter surname: ");
    scanf("%s", st.Surname);
    printf("Enter number of group: ");
    scanf("%s", &st.Number);
    printf("Enter physics mark: ");
    scanf("%d", &st.Physics);
    printf("Enter math mark: ");
    scanf("%d", &st.Math);
    printf("Enter informatics mark: ");
    scanf("%d", &st.Informatics);
    FILE* f = fopen(file, "ab");
    fwrite(&st, sizeof(Student), 1, f);
    fclose(f);
}

void Solve(char* file) {
    FILE* f = fopen(file, "rb");
    int n = _filelength(_fileno(f)) / sizeof(Student);
    Student* sts = new Student[n];
    fread(sts, sizeof(Student), n, f);
    char group[7];
    printf("Enter number of group for search: ");
    scanf("%s", group);
    printf("Excellent students:\n");
    bool flag = true;
    for (int i = 0; i < n; i++) {
        Student st = sts[i];
        if (strcmp(st.Number, group) == 0 && st.Physics > 7 && st.Math > 7 && st.Informatics > 7)
            PrintStudent(st), flag = false;
    }
    if (flag)
        printf("There is nobody):\n");
}

void Edit(char* file) {
    char surname[20];
    FILE* f = fopen(file, "rb");
    int n = _filelength(_fileno(f)) / sizeof(Student);
    printf("Enter surname of student: ");
    scanf("%s", surname);
    Student* sts = new Student[n], *st = sts;
    fread(sts, sizeof(Student), n, f);
    fclose(f);
    bool flag = true;
    for (int i = 0; i < n; i++) {
        if (strcmp(sts[i].Surname, surname) == 0) {
            st = sts + i;
            flag = false;
            break;
        }
    }
    if (flag) {
        printf("This student is not found\n");
        return;
    }
    printf("What do you want to edit?\n\t1 - Surname\n\t2 - Group\n\t3 - Phisics\n\t4 - Math\n\t5 - Informatics\n");
    char c;
    while (true) {
        rewind(stdin);
        scanf("%c", &c);
        switch (c)
        {
        case '1':
            printf("Old surname: %s\nNew surname: ", st->Surname);
            scanf("%s", st->Surname);
            break;
        case '2':
            printf("Old group: %s\nNew group: ", st->Number);
            scanf("%s", st->Number);
            break;
        case '3':
            printf("Old phisics mark: %s\nNew phisics mark: ", st->Physics);
            scanf("%s", st->Physics);
            break;
        case '4':
            printf("Old math mark: %s\nNew math mark: ", st->Math);
            scanf("%s", st->Math);
            break;
        case '5':
            printf("Old informatics mark: %s\nNew informatics mark: ", st->Informatics);
            scanf("%s", st->Informatics);
            break;
        default:
            printf("Try again...");
            continue;
        }
        break;
    }
    f = fopen(file, "wb");
    fwrite(sts, sizeof(Student), n, f);
    fclose(f);
}

void Delete(char*) {

}

void Sort(char*) {

}