import subprocess
import os
import time
#import echo_server
#from echo_server import PyServer

print('Starting C server')
subprocess.Popen('./Server')

print('Starting python client')
#serv = PyServer()
# serv.Start()
subprocess.Popen(['python3', "Client.py"])
time.sleep(0.01)
