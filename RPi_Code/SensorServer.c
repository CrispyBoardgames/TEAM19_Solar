#include <unistd.h>
#include <stdio.h>
#include <sys/socket.h>
#include <stdlib.h>
#include <netinet/in.h>
#include <string.h>

#include <stdio.h>
#include <bcm2835.h>

#include "ADC_Poll.h"
#include "MUX.h"

#define PORT 65400

//To compile do: sudo gcc -o SensorServer SensorServer.c ADC_Poll.c MUX.c -lbcm2835
int Read_Setup(int channelSel);
void Stop();

//Code taken and modified from
// https://www.geeksforgeeks.org/socket-programming-cc/
int main()
{
    //Starting MUX and ADC
    int choice = 0;
    //Set up BCM2835
    if (!bcm2835_init())
        return 1;
    //Setup MUX
    MUX_SetUp();
    //Setup ADC
    ADC_SPI_SetUp();
    intt buffInt = 0;

    //Setting up server
    int server_fd, new_socket, valread;
    struct sockaddr_in address;
    int opt = 1;
    int addrlen = sizeof(address);
    char buffer[1024] = {0};
    char *resultStr = "0.0";

    // Creating socket file descriptor
    if ((server_fd = socket(AF_INET, SOCK_STREAM, 0)) == 0)
    {
        perror("socket failed");
        exit(EXIT_FAILURE);
    }
    // Helps avoid "address already in use" error
    if (setsockopt(server_fd, SOL_SOCKET, SO_REUSEADDR | SO_REUSEPORT,
                   &opt, sizeof(opt)))
    {
        perror("setsockopt");
        exit(EXIT_FAILURE);
    }
    address.sin_family = AF_INET;
    address.sin_addr.s_addr = INADDR_ANY;
    address.sin_port = htons(PORT);

    // Forcefully attaching socket to the port 8080
    if (bind(server_fd, (struct sockaddr *)&address,
             sizeof(address)) < 0)
    {
        perror("bind failed");
        exit(EXIT_FAILURE);
    }
    if (listen(server_fd, 3) < 0)
    {
        perror("listen");
        exit(EXIT_FAILURE);
    }
    if ((new_socket = accept(server_fd, (struct sockaddr *)&address,
                             (socklen_t *)&addrlen)) < 0)
    {
        perror("accept");
        exit(EXIT_FAILURE);
    }
    //Begin reading from client
    //-1 < buffInt < 8. Send anything outside of range to stop.
    //Will do one more reading before stopping, so scrap if you don't need it.
    while (1)
    {
        valread = read(new_socket, buffer, 1024); //Choose MUX channel select line
        buffInt = atoi(buffer);
        if (buffInt > 7 || buffInt < 0)
            break;

        MUX_Channel_Sel(buffInt);
        float result = ADC_Read();
        //printf("Server - Received %s\n", buffer);
        //printf("Server - Sending back\n");
        //Sends back result to python
        send(new_socket, &result, sizeof(result), 0);
    }
    Stop();
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