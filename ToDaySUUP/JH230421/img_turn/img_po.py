import cv2

# 이미지 읽기
img = cv2.imread("D:\FOX1.jpg")

# 이미지 흑백으로 변환
gray_img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# 이미지 상하 반전
flip_img_up_down = cv2.flip(img, 0)

# 이미지 좌우 반전
flip_img_left_right = cv2.flip(img, 1)

# 이미지 출력
cv2.imshow('Original Image', img)
cv2.imshow('Grayscale Image', gray_img)
cv2.imshow('Flip Image Up and Down', flip_img_up_down)
cv2.imshow('Flip Image Left and Right', flip_img_left_right)

# 이미지 창 유지
cv2.waitKey(0)

# 모든 창 닫기
cv2.destroyAllWindows()
