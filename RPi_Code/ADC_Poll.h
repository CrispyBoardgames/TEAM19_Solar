#ifndef ADC_POLL_FUNCTIONS
#define ADC_POLL_FUNCTIONS

#define VREF 5
#define SIZE 1024

//10 bits 2^10=1024
#define PROCESSORBITS 0x00001FF8
//Helps us select the important bits of the received data.

//used to print bits in testing.
#define BYTE_TO_BINARY_PATTERN "%c%c%c%c%c%c%c%c"
#define BYTE_TO_BINARY(byte)       \
    (byte & 0x80 ? '1' : '0'),     \
        (byte & 0x40 ? '1' : '0'), \
        (byte & 0x20 ? '1' : '0'), \
        (byte & 0x10 ? '1' : '0'), \
        (byte & 0x08 ? '1' : '0'), \
        (byte & 0x04 ? '1' : '0'), \
        (byte & 0x02 ? '1' : '0'), \
        (byte & 0x01 ? '1' : '0')
//end print bits

int ADC_SPI_SetUp();
float ADC_Read();

#endif
