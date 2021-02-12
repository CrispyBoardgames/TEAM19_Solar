
#include <wiringPi.h>
#include <stdio.h>

//MUX Macros
#define S0 0
#define S1 1
#define S2 2
#define POLL 3
//Need to change code to use BCM2835.h instead. Better to use the same one rather than have them conflicting.

void Channel_Sel(int channel);
void SetUp();

/*Example
int main(void)
{
    int p_choice = 0;
    SetUp();
    for(;;)
    {
        printf("Please enter choice:\t");
        scanf("%d", &p_choice);
        Channel_Sel(p_choice);
    }
    return 0;
}
*/
void MUX_SetUp()
{
    wiringPiSetup();
    //Channel Select pins
    pinMode(S0, OUTPUT);
    pinMode(S1, OUTPUT);
    pinMode(S2, OUTPUT);

    //Initial is 7
    digitalWrite(S2, LOW);
    digitalWrite(S1, LOW);
    digitalWrite(S0, LOW);
    //Polling Input
    pinMode(POLL, INPUT);
}
//Selects the channel to be read. From 0 to 7.
void MUX_Channel_Sel(int channel)
{
    printf("Received: %d\n", channel);
    switch (channel)
    {
    case 0: //000
        digitalWrite(S2, LOW);
        digitalWrite(S1, LOW);
        digitalWrite(S0, LOW);
        break;
    case 1: //001
        digitalWrite(S2, LOW);
        digitalWrite(S1, LOW);
        digitalWrite(S0, HIGH);
        break;
    case 2: //010
        digitalWrite(S2, LOW);
        digitalWrite(S1, HIGH);
        digitalWrite(S0, LOW);
        break;
    case 3: //011
        digitalWrite(S2, LOW);
        digitalWrite(S1, HIGH);
        digitalWrite(S0, HIGH);
        break;
    case 4: //100
        digitalWrite(S2, HIGH);
        digitalWrite(S1, LOW);
        digitalWrite(S0, LOW);
        break;
    case 5: //101
        digitalWrite(S2, HIGH);
        digitalWrite(S1, LOW);
        digitalWrite(S0, HIGH);
        break;
    case 6: //110
        digitalWrite(S2, HIGH);
        digitalWrite(S1, HIGH);
        digitalWrite(S0, LOW);
        break;
    case 7: //111
        digitalWrite(S2, HIGH);
        digitalWrite(S1, HIGH);
        digitalWrite(S0, HIGH);
        break;
    default: //000
        digitalWrite(S2, LOW);
        digitalWrite(S1, LOW);
        digitalWrite(S0, LOW);
        break;
    }

    return;
}
