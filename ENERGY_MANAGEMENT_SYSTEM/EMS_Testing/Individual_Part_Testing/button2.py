import RPi.GPIO as GPIO
import time
GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)
Button = 36
YellowLED = 16

GPIO.setup(Button, GPIO.IN, pull_up_down = GPIO.PUD_UP)
GPIO.setup(YellowLED, GPIO.OUT)
flag = 0

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
	else:
		GPIO.output(YellowLED, GPIO.LOW) 
