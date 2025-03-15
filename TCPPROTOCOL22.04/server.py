import socket
import sqlite3

SERVER_HOST = '127.0.0.1'
SERVER_PORT = 12345
BUFFER_SIZE = 1024

def initialize_db():
    conn = sqlite3.connect('vehicle_codes.db')
    cursor = conn.cursor()
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS vehicle_codes (
            code TEXT PRIMARY KEY,
            region_name TEXT
        )
    ''')
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AA', 'Kyiv')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AB', 'Kyivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AE', 'Cherkaska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AK', 'Chernihivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AM', 'Sumy oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AN', 'Kharkivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AO', 'Luhanska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AP', 'Donetska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AR', 'Zaporizka oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AT', 'Dnipropetrovska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AX', 'Khersonska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('AY', 'Mykolaivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BA', 'Lvivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BB', 'Volynska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BC', 'Ternopilska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BD', 'Ivano-Frankivska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BE', 'Rivnenska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BF', 'Zhytomyrska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BG', 'Kirovohradska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BH', 'Odeska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BI', 'Khmelnytska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BJ', 'Poltavska oblast')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BK', 'Chernivtsi')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BL', 'Crimea')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BM', 'Kyiv (new style plates)')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BN', 'Lviv')")
    cursor.execute("INSERT OR IGNORE INTO vehicle_codes (code, region_name) VALUES ('BO', 'Dnipro')")
    conn.commit()
    conn.close()

def get_region_by_code(code):
    conn = sqlite3.connect('vehicle_codes.db')
    cursor = conn.cursor()
    cursor.execute("SELECT region_name FROM vehicle_codes WHERE code = ?", (code,))
    result = cursor.fetchone()
    conn.close()
    return result

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind((SERVER_HOST, SERVER_PORT))
server_socket.listen(5)
print(f"Сервер запущено на {SERVER_HOST}:{SERVER_PORT}")

initialize_db()

while True:
    client_socket, client_address = server_socket.accept()
    print(f"Підключено до клієнта: {client_address}")

    try:
        client_request = client_socket.recv(BUFFER_SIZE).decode('utf-8')
        print(f"Отримано код: {client_request}")

        region = get_region_by_code(client_request)

        if region:
            client_socket.send(f"Область для коду {client_request}: {region[0]}".encode('utf-8'))
        else:
            client_socket.send(f"Код {client_request} не знайдений!".encode('utf-8'))

    except Exception as e:
        print(f"Помилка: {e}")
    finally:
        client_socket.close()
