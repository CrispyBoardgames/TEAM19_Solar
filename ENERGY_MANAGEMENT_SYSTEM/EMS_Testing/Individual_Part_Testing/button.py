import RPi.GPIO as GPIO
import time
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
Button = 16
LED = 23

GPIO.setup(Button, GPIO.IN, pull_up_down = GPIO.PUD_UP)
GPIO.setup(LED, GPIO.OUT)

#try:
while True:
	button_state = GPIO.input(Button)
	print (button_state)
	if button_state == 0:
		GPIO.output(LED, GPIO.LOW)
		#	print "Button pressed..."
		#	time.sleep(1)
	else:
		GPIO.output(LED, GPIO.HIGH)
	time.sleep(0.5)
#except:
#	GPIO.cleanup()
