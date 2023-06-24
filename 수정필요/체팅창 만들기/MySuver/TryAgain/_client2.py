

import socket
from _thread import *
import tkinter as tk
from tkinter import scrolledtext

# HOST = '127.0.0.1'
HOST = '192.168.10.160'  # 실제 IP 주소
PORT = 9999

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_socket.connect((HOST, PORT))

def recv_data(client_socket):
    while True:
        data = client_socket.recv(1024)
        chat_log.insert(tk.END, "recive : " + repr(data.decode()) + "\n")
        chat_log.see(tk.END)

def send_data(event=None):
    message = message_entry.get()
    if message == 'quit':
        client_socket.close()
        window.quit()
    client_socket.send(message.encode())
    chat_log.insert(tk.END, "send : " + message + "\n")  # 이 부분이 추가되었습니다.
    chat_log.see(tk.END)
    message_entry.delete(0, tk.END)

start_new_thread(recv_data, (client_socket,))

window = tk.Tk()
window.title("Chat Client")

frame = tk.Frame(window)
scrollbar = tk.Scrollbar(frame)
chat_log = scrolledtext.ScrolledText(frame, wrap=tk.WORD, yscrollcommand=scrollbar.set)
scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
chat_log.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
chat_log.config(state=tk.DISABLED)
frame.pack(fill=tk.BOTH, expand=True)

message_entry = tk.Entry(window)
message_entry.bind("<Return>", send_data)
message_entry.pack(fill=tk.X, expand=True)

send_button = tk.Button(window, text="Send", command=send_data)
send_button.pack()

window.mainloop()
