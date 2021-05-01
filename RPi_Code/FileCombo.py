#The purpose of this file is to test and see if ServerNClient and Client can be in one
#file instead of two.

import subprocess
import os
import time
import socket
import struct
#import echo_server
#from echo_server import PyServer

print('Starting C server')
subprocess.Popen('./SensorServer')

HOST = '127.0.0.1'
PORT = 65400    # >1024

#This function is what is geting us the values from the sensor pcb
#TO USE: call the function and enter a value (2 - current reading, 6 - battery reading, 5 - PV panel, 4 is the inverter voltage) for the parameter
def ServerCall(muxSel):#when called, enter parameters as: ('5')
    channelSel = bytes(muxSel, 'utf-8')
    
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((HOST, PORT))
        s.sendall(channelSel)  # Use to select MUX channel sel lines. 0-7
        print('Client - Receiving data: ')
        data = s.recv(1024)  # ADC read in byte format.

# Received data is in byte format. Formatting into float.
    floatTuple = struct.unpack('f', data)
# Unpack() returns a tuple. Depacking tuple
    floatData = floatTuple[0]
    print('Client: received: ', repr(floatData))
    
    return floatData

ServerCall('2')