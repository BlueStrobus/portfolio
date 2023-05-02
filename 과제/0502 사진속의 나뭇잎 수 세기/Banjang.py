import cv2
import numpy as np
import tensorflow as tf

# 모델 경로와 클래스 이름 파일 경로를 설정합니다.
model_path = "path/to/model.pb"
class_names_path = "path/to/class_names.txt"

# 모델과 클래스 이름 파일을 로드합니다.
model = tf.keras.models.load_model(model_path)
with open(class_names_path, "r") as f:
    class_names = f.read().splitlines()

# 이미지를 로드합니다.
image = cv2.imread("C:\Users\user\Desktop\과제 이미지\KakaoTalk_20230502_141726334_02.jpg")

# 이미지를 전처리합니다.
preprocessed_image = preprocess(image)

# 모델을 사용하여 객체를 감지합니다.
predictions = model(preprocessed_image)

# 감지된 객체를 표시하고 개수를 계산합니다.
num_of_leaves = 0
for prediction in predictions:
    class_name = class_names[prediction.class_index]
    if class_name == "leaf":
        num_of_leaves += 1
        x, y, w, h = prediction.bounding_box
        cv2.rectangle(image, (x, y), (x + w, y + h), (0, 255, 0), 2)

# 나뭇잎 개수를 출력합니다.
print(f"The number of leaves is: {num_of_leaves}")

# 결과 이미지를 저장합니다.
cv2.imwrite("path/to/result_image.jpg", image)
 


# 코딩  단 수많은 나뭇잎 사진들을 딥러닝 시켜 학습시켜야함 