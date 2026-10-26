import serial
import time

# Change COM3 to your Arduino's actual port.
arduino = serial.Serial("COM3", 9600, timeout=2)

# The Uno may reset when the serial connection opens.
time.sleep(2)

def control_led(command):
    command = command.upper().strip()

    if command not in ("ON", "OFF"):
        print("Invalid command.")
        return

    arduino.write((command + "\n").encode())

    response = arduino.readline().decode().strip()
    print("Arduino:", response)


try:
    while True:
        command = input("SAM > ").strip().upper()

        if command == "ON":
            control_led("ON")

        elif command == "OFF":
            control_led("OFF")

        elif command == "EXIT":
            break

        else:
            print("Try ON, OFF, or EXIT.")

finally:
    arduino.close()