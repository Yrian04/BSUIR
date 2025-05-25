#include <iostream>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <string.h>
#include <cmath>
#include <pthread.h>

using namespace std;

const int m = 10;

struct value
{
    int i;
    double v;
};

int main(int argc, char **argv) 
{
    if (argc > 3)
    {   
        cout << "Error: Too many arguments" << endl;
        return 1;
    }
    if (argc < 2)
    {
        cout << "Error: Too few arguments" << endl;
        return 1;
    }

    int k = atoi(argv[1]);TT
    if (k == 0)
    {
        cout << "Error: Invalid the first argument" << endl;
        return 1;
    }

    double n = atof(argv[2]);
    if(n == 0)
    {
        cout << "Error: Invalid the second argument" << endl;
        return 1;
    }

    int mypipe[2];
    pipe(mypipe);

    value t[m*k];
    pid_t pid;
    for (int i = 0; i < m*k; i++)
    {
        pid = fork();
        if (pid == 0)
        {
            value v;
            double x = 2 * M_PI * (i/m) / n;
            while (x > M_PI)
                x -= 2 * M_PI;
            while (x < -M_PI)
                x += 2 * M_PI;
            if (x > M_PI / 2)
                x = M_PI - x;
            if (x < -M_PI / 2)
                x = -M_PI - x;
            v.v = x;
            for (int j = 1; j < i % m + 1; v.v *= (-1) * x * x / (2. * j * (2. * j++ + 1.)));
            v.i = i / m;
            write(mypipe[1], &v, sizeof(value));
            cout << "PID: " << getpid() << " T[" << i << "]" << '(' << v.i << ") = " << v.v <<  endl;

            return 0;
        }
    }
    int p;
    for(int i = m*k; i > 0; i--) wait(&p);
    double y[k] = {0};
    read(mypipe[0], t, sizeof(value)*k*m);
    cout << "Answer:" << endl;
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < m; y[t[j+i*m].i] += t[j++ +i*m].v);
        cout << round(y[i]*100000.)/100000. << endl;
        // cout << y[i] << endl;
    }

}