#include <iostream>
#include <unistd.h>

void PrintTime()
{
    timespec mt;
    clock_gettime(CLOCK_REALTIME, &mt);
    int h = (mt.tv_sec % 86400) / 3600;
    int m = (mt.tv_sec % 3600) / 60;
    int s = (mt.tv_sec % 3600) % 60;
    int mi = mt.tv_nsec / 1000000 ;
    std::cout << "Time: " << h << ':' << m << ':' << s << ':' << mi << std::endl;
}

int main()
{
    pid_t pid = fork();
    if(pid > 0)
    {
        std::cout << "Parent process PID: " << getpid() << std::endl;
        std::cout << "Its parent process PID: " << getppid() << std::endl;
        PrintTime();

        system("ps -x");
    }
    else
    {
        std::cout << "Child process PID: " << getpid() << std::endl;
        std::cout << "Its parent process PID: " << getppid() << std::endl;
        PrintTime();
    }
}