import cv2
import numpy as np

# 이미지 불러오기
img = cv2.imread('tree.jpg')

# 이미지 전처리
hsv = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)
lower_green = np.array([40, 50, 50])
upper_green = np.array([80, 255, 255])
mask = cv2.inRange(hsv, lower_green, upper_green)
mask = cv2.GaussianBlur(mask, (5, 5), 0)
_, thresh = cv2.threshold(mask, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)

# 객체 검출
contours, _ = cv2.findContours(thresh, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
leaf_count = 0
for cnt in contours:
    area = cv2.contourArea(cnt)
    if area > 100:  # 객체 면적이 일정 크기 이상이면
        leaf_count += 1
        cv2.drawContours(img, [cnt], 0, (0, 255, 0), 2)

# 결과 출력
print('나뭇잎 개수:', leaf_count)
cv2.imshow('Result', img)
cv2.waitKey(0)