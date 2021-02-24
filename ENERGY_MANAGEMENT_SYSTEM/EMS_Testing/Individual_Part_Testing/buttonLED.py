import RPi.GPIO as GPIO
import time
GPIO.setmode(GPIO.BOARD)
GPIO.setwarnings(False)
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

