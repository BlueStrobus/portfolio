import cv2
import numpy as np
from skimage import feature

# 이미지 불러오기
image = cv2.imread("D:\pystudy\Pillow\Tree7.jpg")

# 이미지 전처리 (노이즈 제거, 그레이스케일 변환, 가우시안 블러 적용)
image_gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
image_gray = cv2.GaussianBlur(image_gray, (5, 5), 0)

# Canny edge detection 수행
edges = feature.canny(image_gray, sigma=3)

# Contour 추출
contours, _ = cv2.findContours(np.uint8(edges), cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

# 나뭇잎 개수 초기화
num_leaves = 0

# Contour에서 나뭇잎 영역 검출 및 개수 카운트
for contour in contours:
    area = cv2.contourArea(contour)
    if area > 50 and area < 5000:  # 임계값 조정
        perimeter = cv2.arcLength(contour, True)
        approx = cv2.approxPolyDP(contour, 0.02 * perimeter, True)
        x, y, w, h = cv2.boundingRect(approx)
        if h > w:  # 나뭇잎은 길쭉한 형태이므로 높이가 너비보다 큰 경우만 인식
            num_leaves += 1

# 나뭇잎 개수 출력
print("나뭇잎 개수:", num_leaves)

# 위에껀 이미지를 인식 못하고 그림만 인식해용