#include <stdio.h>
#include <bcm2835.h>

#include "ADC_Poll.h"
/*
    Run SPI_SetUp() first, then Read()
*/
//Add -lbcm2835 to compile
//Run with sudo
//LSB Size = Vref / 1024


//Does not call bcm2835_init(). This should be done elsewhere since the MUX code would also use it.
int ADC_SPI_SetUp()
{
    //2: Initialize library
    /*if (!bcm2835_init())
    {
        printf("BCM Library failed.\n");
        return 1;
    }*/
    //3: Begin the SPI
    if (!bcm2835_spi_begin())
    {
        printf("SPI failed");
        return 1;
    }
    //4: Set the bit order: MSB for MCP3001
    bcm2835_spi_setBitOrder(BCM2835_SPI_BIT_ORDER_MSBFIRST);
    //5: Set data mode: Modes 0,0 and 1,1 for MCP3001 (ADC)
    bcm2835_spi_setDataMode(BCM2835_SPI_MODE0);
    //6: Set SPI clock divider: ADC can only handle up to 2.8 MHz
    bcm2835_spi_setClockDivider(BCM2835_SPI_CLOCK_DIVIDER_1); //Gives 1.5625 MHz on RPI3    //Not true. Changed for testing. Too lazy to correct today. (2/11/2021)
    //128 gives 3.125 MHz
    //Look up the clock divider function in the BCM2835 library
    //7: Set CHIP select
    bcm2835_spi_chipSelect(BCM2835_SPI_CS0);
    //Should be GPIO8
    //8: Set chip select polarity
    bcm2835_spi_setChipSelectPolarity(BCM2835_SPI_CS0, LOW);
    //CS on MCP3001 is active low.

    return 0;
}

float ADC_Read()
{
    char decision = 'y';
    char dummy_Write = 0;

    uint8_t upper_Read = 0;
    uint16_t upper_16 = 0;
    uint8_t lower_Read = 0;
    uint16_t lower_16 = 0;

    char total_Read[2]; //Full data stored here.
    int int_Total_Read = 0;
    int processed;
    float voltage;

    bcm2835_spi_transfernb(&dummy_Write, total_Read, 2);

    upper_Read = (total_Read[0]) & 0b00011111;
    upper_16 = (uint16_t)upper_Read << 8;

    lower_Read = total_Read[1];
    lower_16 = lower_Read;

    int_Total_Read = (upper_16 | lower_16) >> 3;
    processed = (int_Total_Read & PROCESSORBITS);
    voltage = (float)processed * (float)VREF / (float)SIZE;

    return voltage;
}

/*
int main()
{
    
    char decision = 'y';
    char dummy_Write = 0;

    uint8_t upper_Read = 0;
    uint16_t upper_16 = 0;
    uint8_t lower_Read = 0;
    uint16_t lower_16 = 0;

    char total_Read[2]; //Full data stored here.
    int int_Total_Read = 0;
    int processed;
    float voltage;
    while (1)
    //{
        //printf("Would you like to read?: y/n \n");
        //scanf("%c", &decision);

        //if (decision == 'y')
        //{
            //printf("Reading\n");
            //bcm2835_spi_transfernb(&dummy_Write, total_Read, 2);
        //}
        else
        {
            printf("\nStopping program. Goodbye!\n");
            bcm2835_spi_end();
            bcm2835_close();
            return 0;
        }
    printf("Total Read: " BYTE_TO_BINARY_PATTERN " " BYTE_TO_BINARY_PATTERN "\n",
           BYTE_TO_BINARY(total_Read[0]), BYTE_TO_BINARY(total_Read[1]));
    printf("Converting!\n");
    upper_Read = (total_Read[0]) & 0b00011111;
    upper_16 = (uint16_t)upper_Read << 8;
    printf("\nUpper read: " BYTE_TO_BINARY_PATTERN, BYTE_TO_BINARY(upper_Read));
    lower_Read = total_Read[1];
    lower_16 = lower_Read;
    printf("\nLower read: " BYTE_TO_BINARY_PATTERN, BYTE_TO_BINARY(lower_Read));
    int_Total_Read = (upper_16 | lower_16) >> 3;
    processed = (int_Total_Read & PROCESSORBITS);
    voltage = (float)processed * (float)VREF / (float)SIZE;
    printf("\nRAW Receive: %d \tProcessed: %f \tVoltage: %f\n", total_Read, processed, voltage);
    //}
    //For sending data out
    //bcm2835_spi_transfern(DataOut, Word Size);
    //For receiving and transferring at the same time
    //bcm2835_spi_transfernb(out, in, word size);
    bcm2835_spi_end();
    //bcm2835_close();  //Don't close as the MUX code needs this. Only close when everything shuts off.
    return 0; //All went well
}*/
