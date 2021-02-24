import RPi.GPIO as GPIO
import time
GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)

GPIO.setup(16, GPIO.OUT)
print "LED on"
GPIO.output(16, GPIO.HIGH)
time.sleep(5)
print "LED off"
GPIO.output(16, GPIO.LOW)
