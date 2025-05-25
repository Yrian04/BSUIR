#include <unistd.h>
#include <iostream>

using namespace std;

int main()
{
    cout << "PID: " << getpid() << endl;
    cout << "PPID: " << getppid() << endl;
    system("ls");
    for(int i = 0; i < 3; i++)
        if(fork() == 0)
        {
            cout << "Process " << getppid() << " make process " << getpid() << endl;
            if(i == 2)
                for(int j = 0; j < 2; j++)
                    if(fork() == 0)
                    {
                        cout << "\tProcess " << getppid() << " make process" << getpid() << endl;
                        if(j == 0)
                        {
                            if(fork() == 0)
                            {
                                cout << "\t\tProcess " << getppid() << " make process" << getpid() << endl;
                                cout << "\t\tProcess " << getpid() << " with parent " << getppid() << " stops" << endl;
                                return 0;
                            }
                        }
                        
                        cout << "\tProcess " << getpid() << " with parent " << getppid() << " stops" << endl;
                        return 0;
                    }
            cout << "Process " << getpid() << " with parent " << getppid() << " stops" << endl;

            return 0;
        }
}