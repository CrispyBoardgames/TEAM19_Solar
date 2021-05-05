import RPi.GPIO as GPIO
import time
import sys
import I2C_LCD_driver
import subprocess
import os
import socket
import struct

HOST = '127.0.0.1'
PORT = 65400    # >1024

# This function is what is geting us the values from the sensor pcb
# TO USE: call the function and enter a value (2 - current reading, 6 - battery reading, 5 - PV panel, 4 is the inverter voltage) for the parameter


def ServerCall(muxSel):  # when called, enter parameters as: ('5')
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

# Sorting Algorithm for Current Reading
# Function receives a list of values and returns the highest.
# Currents must be read back to back, and not in a round robin fashion.


def SortTopA(Currents):
    topAmp = 2.50

    for amp in Currents:
        # 2.5 is base: 0 Amps. We normalize to 0 to use the properties of absolute values.
        if(abs(amp - 2.50) > abs(topAmp - 2.50)):
            topAmp = amp

    return topAmp

# Call this method after sorting for the top.
# Follows simple linear relationship: 400 mV / 1 Amp
# Since we want the line to be a function of the voltage read (input), we flip and get 2.5 Amp / Volt
# Some simple calculations give us the offset, b, and get Amps = 2.5*Vin - 6.25


def TranslateAmps(Vamp):
    return ((2.5 * Vamp) - 6.25)

# ADC will not see negative values. Thus,  no absolute value necessary. Translation of voltages is not needed.


def SortTopV(Voltages):
    topVolt = 0.0

    for volt in Voltages:
        if(abs(volt) > abs(topVolt)):
            topVolt = abs(volt)

    return topVolt


# Voltage Divider Constants
voltConstant = 10.091
invConstant = 51.233

GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)
mylcd = I2C_LCD_driver.lcd()

onOffSwitch = 32
fanRelay = 16
inverterRelay = 18
buckRelay = 22
#flag = 0

GPIO.setup(onOffSwitch, GPIO.IN, pull_up_down=GPIO.PUD_DOWN)
GPIO.setup(fanRelay, GPIO.OUT)
GPIO.setup(inverterRelay, GPIO.OUT)
GPIO.setup(buckRelay, GPIO.OUT)

GPIO.output(fanRelay, GPIO.LOW)
GPIO.output(inverterRelay, GPIO.LOW)
GPIO.output(buckRelay, GPIO.LOW)

# Connection to database

# Opening server
print('Starting C server')
subprocess.Popen('sudo ./SensorServer')

temperature = 70.2  # get rid of
voltage1 = 12.031  # get rid of
voltage2 = 3.008  # get rid of
voltage3 = 4.727  # get rid of

while True:
    # Calling server
    battery1 = ServerCall('6') * voltConstant  # Ready to store
    pv1 = ServerCall('5') * voltConstant  # Ready to store

    # Reading inverter output
    inv_voltages1 = []
    inv_currents1 = []

    # 6 samples per 16 ms
    numSamples = 0
    while(numSamples < 6):
        inv_voltages1.append(ServerCall('4'))
        inv_currents1.append(ServerCall('2'))
        time.sleep(0.002)  # Wait 2 ms

    # Sort for top
    maxInvVolt = SortTopV(inv_voltages1)
    maxInvAmp = TranslateAmps(SortTopA(inv_currents1))

    InvVrms = maxInvVolt * 0.707 * invConstant  # Ready to store
    InvArms = maxInvAmp * 0.707 * invConstant  # Ready to store

    Power = InvVrms * InvArms   # Ready to store

    switch_state = GPIO.input(onOffSwitch)
    print(switch_state)
#	if button_state == 1:
#		time.sleep(0.5)
#		if flag == 0:
#			flag = 1
#		else:
#			flag = 0
    if switch_state == 1:
        #        GPIO.output(fanRelay, GPIO.HIGH)
        GPIO.output(inverterRelay, GPIO.HIGH)
        GPIO.output(buckRelay, GPIO.HIGH)
        mylcd.lcd_clear()
        while switch_state == 1:
            mylcd.lcd_display_string("Temp: %d%s F" %
                                     (temperature, chr(223)), 1)
            mylcd.lcd_display_string("Battery: %f V" % voltage1, 2)
            mylcd.lcd_display_string("Current: %f V" % voltage2, 3)
            mylcd.lcd_display_string("PV: %f V" % voltage3, 4)
            switch_state = GPIO.input(onOffSwitch)
#            mylcd.lcd_display_string("Temp: %d%s F" % (temperature, chr(223)), 1)
#        mylcd.lcd_display_string("V1: %f V" % voltage1, 2)
#        mylcd.lcd_display_string("V2: %f V" % voltage2, 3)
#        mylcd.lcd_display_string("V3: %f V" % voltage3, 4)

#        mylcd.lcd_display_string("Failed to get reading. Try again!")
    else:
        #        GPIO.output(fanRelay, GPIO.LOW)
        GPIO.output(inverterRelay, GPIO.LOW)
        GPIO.output(buckRelay, GPIO.LOW)
        mylcd.lcd_clear()
        while switch_state != 1:
            mylcd.lcd_display_string(" System is shutoff!", 2)
            mylcd.lcd_display_string("Enable Middle Switch", 3)
            switch_state = GPIO.input(onOffSwitch)
    time.sleep(.5)
    inv_voltages1.clear()
    inv_currents1.clear()
