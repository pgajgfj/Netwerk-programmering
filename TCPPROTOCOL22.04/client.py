import socket

SERVER_HOST = '127.0.0.1'
SERVER_PORT = 12345
BUFFER_SIZE = 1024

def get_vehicle_region():
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((SERVER_HOST, SERVER_PORT))

    vehicle_code = input("Введіть код автомобільного номера (наприклад, AA): ")

    client_socket.send(vehicle_code.encode('utf-8'))

    response = client_socket.recv(BUFFER_SIZE).decode('utf-8')
    print(response)

    client_socket.close()

if __name__ == '__main__':
    get_vehicle_region()
