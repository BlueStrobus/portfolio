


import cv2

# 이미지 파일 로드
img = cv2.imread('tree2.jpg')

# 이미지를 그레이스케일로 변환
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# 이미지의 경계선 찾기
edges = cv2.Canny(gray, 50, 150)

# 경계선에서 윤곽선 찾기
contours, _ = cv2.findContours(edges, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

# 윤곽선의 개수가 잎사귀의 개수와 같다고 가정
leaf_count = len(contours)

# 결과 출력
print("사진 속 나무의 잎사귀 수:", leaf_count)
