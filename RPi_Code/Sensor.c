#include <stdio.h>
#include <bcm2835.h>

#include "ADC_Poll.h"
#include "MUX.h"

//To compile do: gcc -o Sensor Sensor.c ADC_Poll.c MUX.c -lbcm2835

int main()
{
    int choice = 0;
    scanf("%d", &choice);
    //Set up BCM2835
    if (!bcm2835_init())
        return 1;
    //Setup MUX
    MUX_SetUp();
    //Setup ADC
    ADC_SPI_SetUp();
    //Select which channel to read (0-7)
    MUX_Channel_Sel(choice);
    float result = ADC_Read();
    printf("\nAnswer: %f\n", result);
    return 0;
}

int Read_Setup(int channelSel)
{
    int choice = 0;
    scanf("%d", &choice);
    //Set up BCM2835
    if (!bcm2835_init())
        return 1;
    //Setup MUX
    MUX_SetUp();
    //Setup ADC
    ADC_SPI_SetUp();
    //Select which channel to read (0-7)
    MUX_Channel_Sel(choice);
    float result = ADC_Read();
    printf("\nAnswer: %f\n", result);
    return 0;
}

//Stops all necessary functions that were started. Call when you are done with readings.
void Stop()
{
    bcm2835_spi_end();
    bcm2835_close();
    return;
}
