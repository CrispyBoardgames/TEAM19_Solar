import RPi.GPIO as GPIO
#import dht11
import sys
import Adafruit_DHT
import I2C_LCD_driver

from time import *

mylcd = I2C_LCD_driver.lcd()

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.cleanup()

sensor = Adafruit_DHT.DHT11
gpio = 17

while True:
  
#    instance = dht11.DHT11(pin = 4)
#    result = instance.read()

# Uncomment for Fahrenheit:
    humidity, temperature = Adafruit_DHT.read_retry(sensor, gpio)
    temperature = (temperature * 1.8) + 32 

#    if result.is_valid():
    if humidity is not None and temperature is not None:
        mylcd.lcd_display_string("Temp: %d%s F" % (temperature, chr(223)), 1)
        mylcd.lcd_display_string("Humidity: %d %%" % humidity, 2)
    else:
        mylcd.lcd_display_string("Failed to get reading. Try again!")