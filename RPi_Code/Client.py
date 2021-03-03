import socket
import struct

HOST = '127.0.0.1'
PORT = 65400

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    s.sendall(b'5')
    print('Client - Receiving data: ')
    data = s.recv(1024)

# Received data is in byte format. Formatting into float.
floatTuple = struct.unpack('f', data)
# Unpack() returns a tuple. Depacking tuple
floatData = floatTuple[0]
print('Client: received: ', repr(floatData))
