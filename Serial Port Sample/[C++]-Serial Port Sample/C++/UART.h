#include <windows.h>
#include <commctrl.h>

int SetupUart(char *Port="COM1",int baud=9600,int Bitsize=8,int StopBits=1,int Parity=NOPARITY);
int WriteUart(unsigned char *buf, int len);
int ReadUart(unsigned char *buf, int len);
int CloseUart();