import socket
import time

# Константи
SERVER_IP = '127.0.0.1'  # IP адреса сервера (локальний хост)
SERVER_PORT = 12345      # Порт для прослуховування
MAX_CLIENTS = 5          # Максимальна кількість учасників в чату

# Список для зберігання клієнтів
clients = []

# Створення UDP сокету
server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server_socket.bind((SERVER_IP, SERVER_PORT))
print(f"Сервер запущено на {SERVER_IP}:{SERVER_PORT}")

# Функція для відправки повідомлення всім клієнтам
def broadcast_message(message, sender):
    timestamp = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime())
    full_message = f"{sender} ({timestamp}): {message}"
    for client in clients:
        server_socket.sendto(full_message.encode(), client)

# Функція для обробки приватних повідомлень
def private_message(message, sender, recipient_ip):
    timestamp = time.strftime('%Y-%m-%d %H:%M:%S', time.localtime())
    full_message = f"Приватне повідомлення від {sender} ({timestamp}): {message}"
    server_socket.sendto(full_message.encode(), recipient_ip)

# Обробка клієнтських повідомлень
while True:
    message, client_address = server_socket.recvfrom(1024)
    message = message.decode()

    # Якщо це новий клієнт
    if client_address not in clients:
        if len(clients) < MAX_CLIENTS:
            clients.append(client_address)
            server_socket.sendto("Підключено до чату!".encode(), client_address)
            print(f"Клієнт {client_address} підключився.")
        else:
            server_socket.sendto("Максимальна кількість користувачів досягнута.".encode(), client_address)
            continue

    # Якщо повідомлення - приватне
    if message.startswith('@'):
        parts = message.split(' ', 1)
        if len(parts) > 1:
            recipient = parts[0][1:]  # Видаляємо '@' з ім'я користувача
            private_message(parts[1], str(client_address), recipient)
        else:
            server_socket.sendto("Невірний формат приватного повідомлення.".encode(), client_address)
    else:
        # Надіслати повідомлення всім клієнтам
        broadcast_message(message, str(client_address))
