import RPi.GPIO as GPIO
import time
import sys
import I2C_LCD_driver

GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)
mylcd = I2C_LCD_driver.lcd()

onOffSwitch = 32
fanRelay = 16
inverterRelay = 18
buckRelay = 22
#flag = 0

GPIO.setup(onOffSwitch, GPIO.IN, pull_up_down = GPIO.PUD_DOWN)
GPIO.setup(fanRelay, GPIO.OUT)
GPIO.setup(inverterRelay, GPIO.OUT)
GPIO.setup(buckRelay, GPIO.OUT)

GPIO.output(fanRelay, GPIO.LOW)
GPIO.output(inverterRelay, GPIO.LOW)
GPIO.output(buckRelay, GPIO.LOW)

temperature = 70.2
voltage1 = 12.031
voltage2 = 3.008
voltage3 = 4.727

while True:
    switch_state = GPIO.input(onOffSwitch)
    print (switch_state)
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
            mylcd.lcd_display_string("Temp: %d%s F" % (temperature, chr(223)), 1)
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
