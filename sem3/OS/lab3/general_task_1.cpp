#include <iostream>
#include <unistd.h>
#include <sys/types.h>
#include <semaphore.h>
#include <sys/wait.h>
#include <fcntl.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <map>
#include <chrono>

using namespace std;

const int   N               = 3;
const int   TIMER           = 5; 
sem_t       *process_sem; 
pid_t       pid;

int main(int argc, char **argv)
{
    if (argc != 2)
    {
        cout << "There must be one argument" << endl;
        return 1;
    }

    process_sem = sem_open("process_sem", O_CREAT, 0666, 0);
    
    sem_init(process_sem, 1, N);

    while(true)
    {
        sleep(1);

            int sem;
            sem_getvalue(process_sem, &sem);
            cout << "c process " << sem << endl;

        sem_wait(process_sem);
        
            cout << "~c process" << endl;

        pid = fork();
        if (pid == 0)
        {
            if (execl(argv[1], "", NULL) == -1)
            {
                perror("execl");
                return 1;
            }

            return -1;
        }

            cout << pid << endl;

        if (fork() == 0)
        {
            sleep(TIMER);

                cout << pid << endl;
                cout << "KILL THE CHILD!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" << endl;

            if (kill(pid, SIGKILL) == -1)
            {
                perror("killer");
                return -1;
            }

            sem_post(process_sem);

                int sem;
                sem_getvalue(process_sem, &sem);
                cout << "!c process " << sem << endl;

            return 0;
        }
    }

    sem_unlink("process_sem");

    sem_close(process_sem);
}