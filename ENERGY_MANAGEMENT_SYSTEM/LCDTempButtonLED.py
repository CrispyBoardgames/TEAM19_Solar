import RPi.GPIO as GPIO
import time
import sys
import Adafruit_DHT
import I2C_LCD_driver

GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)
mylcd = I2C_LCD_driver.lcd()

sensor = Adafruit_DHT.DHT11
gpio = 17
Button = 36
YellowLED = 16
BlueLED = 18
GreenLED = 22
flag = 0

GPIO.setup(Button, GPIO.IN, pull_up_down = GPIO.PUD_UP)
GPIO.setup(YellowLED, GPIO.OUT)
GPIO.setup(BlueLED, GPIO.OUT)
GPIO.setup(GreenLED, GPIO.OUT)


while True:
    button_state = GPIO.input(Button)
#print (button_state)
    if button_state == 0:
        time.sleep(0.5)
        if flag == 0:
            flag = 1
        else:
            flag = 0

    if flag == 1:
        GPIO.output(YellowLED, GPIO.HIGH)
        GPIO.output(BlueLED, GPIO.HIGH)
        GPIO.output(GreenLED, GPIO.HIGH)
    else:
        GPIO.output(YellowLED, GPIO.LOW)
        GPIO.output(BlueLED, GPIO.LOW)
        GPIO.output(GreenLED, GPIO.LOW)

    humidity, temperature = Adafruit_DHT.read_retry(sensor, gpio)
    temperature = (temperature * 1.8) + 32 

#    if result.is_valid():
    if humidity is not None and temperature is not None:
        mylcd.lcd_display_string("Temp: %d%s F" % (temperature, chr(223)), 1)
        mylcd.lcd_display_string("Humidity: %d %%" % humidity, 2)
    else:
        mylcd.lcd_display_string("Failed to get reading. Try again!")


