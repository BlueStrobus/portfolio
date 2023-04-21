# import cv2

# # 웹캠 열기
# cap = cv2.VideoCapture(0)

# while True:
#     # 프레임 읽기
#     ret, frame = cap.read()
    
#     # 흑백으로 변환
#     gray_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
#     # 변환된 이미지 출력
#     cv2.imshow('Grayscale Frame', gray_frame)

#     # 'q' 키를 누르면 종료
#     if cv2.waitKey(1) == ord('q'):
#         break

# # 리소스 해제
# cap.release()
# cv2.destroyAllWindows()

####################화면크기#############################

import cv2

# 웹캠 열기
cap = cv2.VideoCapture(0)

# 초기 화면 크기 설정
frame_width = 640
frame_height = 480
cap.set(cv2.CAP_PROP_FRAME_WIDTH, frame_width)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, frame_height)

# 줌 초기값 설정
zoom = 1.0

# 좌우 반전 초기값 설정
flip = False

while True:
    # 프레임 읽기
    ret, frame = cap.read()
    
    # 화면 크기 조절
    frame = cv2.resize(frame, (int(frame_width*zoom), int(frame_height*zoom)))
    
    # 좌우 반전
    if flip:
        frame = cv2.flip(frame, 1)
    
    # 흑백으로 변환
    gray_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
    # 변환된 이미지 출력
    cv2.imshow('Grayscale Frame', gray_frame)

    # 'q' 키를 누르면 종료
    if cv2.waitKey(1) == ord('q'):
        break
    # '+' 키를 누르면 줌 인
    elif cv2.waitKey(1) == ord('+'):
        zoom += 0.1
    # '-' 키를 누르면 줌 아웃
    elif cv2.waitKey(1) == ord('-'):
        zoom -= 0.1
    # 'f' 키를 누르면 좌우 반전
    elif cv2.waitKey(1) == ord('f'):
        flip = not flip
    
    # 줌 값이 0보다 작으면 0.1로 설정
    if zoom < 0.1:
        zoom = 0.1
    
    # 줌 값이 3보다 크면 3으로 설정
    if zoom > 3:
        zoom = 3

# 리소스 해제
cap.release()
cv2.destroyAllWindows()


