import socket
import time

# Константи
SERVER_IP = '127.0.0.1'  # IP адреса сервера
SERVER_PORT = 12345      # Порт для з’єднання

# Створення UDP сокету
client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# Підключення до сервера
def connect_to_server():
    username = input("Введіть ваше ім'я: ")
    client_socket.sendto(username.encode(), (SERVER_IP, SERVER_PORT))
    while True:
        message = input(f"{username}: ")

        # Приватне повідомлення
        if message.startswith('@'):
            client_socket.sendto(message.encode(), (SERVER_IP, SERVER_PORT))
        else:
            client_socket.sendto(message.encode(), (SERVER_IP, SERVER_PORT))

        if message.lower() == 'exit':
            print("Ви вийшли з чату.")
            break

        # Отримуємо повідомлення від сервера
        data, _ = client_socket.recvfrom(1024)
        print(data.decode())

# Запуск клієнта
connect_to_server()
