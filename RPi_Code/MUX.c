
#include <bcm2835.h>
#include <stdio.h>

#include "MUX.h"

//Polling is done by ADC. This is only used to change select lines.
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

int MUX_SetUp()
{
    if (!bcm2835_init())
        return 1; //Something went wrong
    //Channel Select pins
    //08,10,12 refer to the physical layout.
    //They correspond to GPIO #: 15, 16, 1 respectively.
    bcm2835_gpio_fsel(RPI_V2_GPIO_P1_08, BCM2835_GPIO_FSEL_OUTP);
    bcm2835_gpio_fsel(RPI_V2_GPIO_P1_10, BCM2835_GPIO_FSEL_OUTP);
    bcm2835_gpio_fsel(RPI_V2_GPIO_P1_12, BCM2835_GPIO_FSEL_OUTP);

    //Initial is 0
    bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
    bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
    bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
    
    return 0;
}
//Selects the channel to be read. From 0 to 7.
void MUX_Channel_Sel(int channel)
{
    printf("Received: %d\n", channel);
    switch (channel)
    {
    case 0: //000
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
        break;
    case 1: //001
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, HIGH);
        break;
    case 2: //010
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
        break;
    case 3: //011
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, HIGH);
        break;
    case 4: //100
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
        break;
    case 5: //101
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, HIGH);
        break;
    case 6: //110
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
        break;
    case 7: //111
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, HIGH);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, HIGH);
        break;
    default: //000
        bcm2835_gpio_write(RPI_V2_GPIO_P1_08, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_10, LOW);
        bcm2835_gpio_write(RPI_V2_GPIO_P1_12, LOW);
        break;
    }
    return;
}
