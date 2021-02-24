import time
import csv
import MySQLdb
import random

db = MySQLdb.connect(host="localhost", user="root", passwd="SDSU2021", db="datatest")
cursor = db.cursor()

while True:
    a = random.randint(0,100)
    b = random.randint(0,100)
    temperature = a
    humidity = b
    
    print temperature
    print humidity
    
    try:
        cursor.execute("""INSERT INTO testing (temperature, humidity) VALUES (%s, %s)""", (temperature, humidity))
        db.commit()
        print "Row was inserted successfully into testing MySQL database"
        
    except:
        db.rollback()
        print "Failed writing to database"
        
    time.sleep(5)