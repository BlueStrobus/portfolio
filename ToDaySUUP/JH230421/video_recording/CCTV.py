import cv2
import numpy as np
import datetime

# 웹캠 열기
cap = cv2.VideoCapture(0)

# 화면 크기 설정
frame_width = int(cap.get(cv2.CAP_PROP_FRAME_WIDTH))
frame_height = int(cap.get(cv2.CAP_PROP_FRAME_HEIGHT))

# 동영상 저장용 녹화 객체 생성
fourcc = cv2.VideoWriter_fourcc(*'XVID')
out = cv2.VideoWriter('output.avi', fourcc, 20.0, (frame_width, frame_height))

while True:
    # 프레임 읽기
    ret, frame = cap.read()

    # 현재 시간 구하기
    now = datetime.datetime.now()
    timestamp = now.strftime("%Y-%m-%d %H:%M:%S")
    
    # 프레임에 시간 추가
    font = cv2.FONT_HERSHEY_SIMPLEX
    cv2.putText(frame, timestamp, (10, 50), font, 1, (255, 255, 255), 2, cv2.LINE_AA)
    
    # 동영상 녹화
    out.write(frame)
    
    # 프레임 출력
    cv2.imshow('Recording', frame)
    
    # 'q' 키를 누르면 종료
    if cv2.waitKey(1) == ord('q'):
        break

# 리소스 해제
out.release()
cap.release()
cv2.destroyAllWindows()
