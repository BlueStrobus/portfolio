import tkinter as tk
from PIL import ImageTk, Image
import datetime

# tkinter 윈도우 생성
window = tk.Tk()
window.title("타이머")
window.geometry("1000x500")

# 배경 이미지 설정
bg_image = Image.open("HLens.png")
bg_image = bg_image.resize((window.winfo_screenwidth(), window.winfo_screenheight()))
bg_photo = ImageTk.PhotoImage(bg_image)
bg_label = tk.Label(window, image=bg_photo)
bg_label.place(x=0, y=0, relwidth=1, relheight=1)

# 라벨 생성
font = ("Inconsolata", 40) #Helvetica   Ailial??
label = tk.Label(window, font=font, fg="green")
label.pack(pady=20)

# Entry 위젯 생성
font2 = ("Inconsolata", 20)
input_frame = tk.Frame(window)
input_frame.pack(pady=10)
input_label = tk.Label(input_frame, font=font2, text="날짜를 입력하세요 (yyyy-mm-dd): ")
input_label.pack(side="left")
input_entry = tk.Entry(input_frame, font=font, bd=2)
input_entry.pack(side="left")


# ##########시간 어디있나##############수정중##############
# #시간
# input_frame1 = tk.Frame1(window)
# input_frame1.pack(pady=10)
# input_label = tk.Label(input_frame1, font=font2, text="시간을 입력하세요 (hh:mm:ss): ")
# input_label.pack(side="left")
# input_entti = tk.Entry(input_frame1, font=font, bd=2)
# input_entti.pack(side="left")
# #########################################



def start_timer():
    # 입력한 날짜와 시간을 받아옴
    input_date = input_entry.get()
    input_time = "00:00:00"
    year, month, day = map(int, input_date.split("-"))
    hour, minute, second = map(int, input_time.split(":"))

    # 입력한 날짜와 시간을 datetime 객체로 변환
    target_date = datetime.datetime(year, month, day, hour, minute, second)

    # 라벨 업데이트 함수
    def update():
        # 현재 날짜와 시간을 받아옴
        now = datetime.datetime.now()
        
        # 입력한 날짜와 현재 날짜와의 차이를 계산함
        time_diff = target_date - now
        
        # 남은 날짜와 시간을 계산함
        remaining_days = time_diff.days
        remaining_seconds = time_diff.seconds
        remaining_hours = remaining_seconds // 3600
        remaining_minutes = (remaining_seconds % 3600) // 60
        remaining_seconds = remaining_seconds % 60
        
        # 라벨 업데이트
        label.config(text=f"남은 시간: {remaining_days}일 {remaining_hours}시간 {remaining_minutes}분 {remaining_seconds}초")
        
        # 입력한 날짜와 현재 날짜가 같으면 종료
        if now >= target_date:
            label.config(text="타이머 종료")
            return
        
        # 1초마다 업데이트
        window.after(1000, update)

    # 타이머 시작
    update()

# 시작 버튼 생성
start_button = tk.Button(window, text="타이머 시작", font=font, bg="green", fg="white", command=start_timer)
start_button.pack(pady=10)

# tkinter 메인 루프 실행
window.mainloop()
