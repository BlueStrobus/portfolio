import pygame
import random

# 게임 화면 설정
WIDTH = 800
HEIGHT = 600
FPS = 60

# 색상 정의
WHITE = (255, 255, 255)
BLUE = (0, 0, 255)
GREEN = (0, 255, 0)
RED = (255, 0, 0)

# 초기화
pygame.init()
pygame.mixer.init()
screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("벽돌깨기")
clock = pygame.time.Clock()

# 패들 클래스 정의
class Paddle(pygame.sprite.Sprite):
    def __init__(self):
        pygame.sprite.Sprite.__init__(self)
        self.image = pygame.Surface((100, 20))
        self.image.fill(BLUE)
        self.rect = self.image.get_rect()
        self.rect.x = (WIDTH - self.rect.width) // 2
        self.rect.y = HEIGHT - 50
        self.speedx = 0

    def update(self):
        self.speedx = 0
        keystate = pygame.key.get_pressed()
        if keystate[pygame.K_LEFT]:
            self.speedx = -5
        if keystate[pygame.K_RIGHT]:
            self.speedx = 5
        self.rect.x += self.speedx
        if self.rect.right > WIDTH:
            self.rect.right = WIDTH
        if self.rect.left < 0:
            self.rect.left = 0

# 공 클래스 정의
class Ball(pygame.sprite.Sprite):
    def __init__(self):
        pygame.sprite.Sprite.__init__(self)
        self.image = pygame.Surface((20, 20))
        self.image.fill(RED)
        self.rect = self.image.get_rect()
        self.rect.x = WIDTH // 2
        self.rect.y = HEIGHT // 2
        self.speedx = random.choice([-2, 2])
        self.speedy = -2

    def update(self):
        self.rect.x += self.speedx
        self.rect.y += self.speedy
        if self.rect.right > WIDTH or self.rect.left < 0:
            self.speedx *= -1
        if self.rect.top < 0:
            self.speedy *= -1

# 벽돌 클래스 정의
class Brick(pygame.sprite.Sprite):
    def __init__(self, x, y):
        pygame.sprite.Sprite.__init__(self)
        self.image = pygame.Surface((60, 20))
        self.image.fill(GREEN)
        self.rect = self.image.get_rect()
        self.rect.x = x
        self.rect.y = y

# 게임 오브젝트 그룹 생성
all_sprites = pygame.sprite.Group()
bricks = pygame.sprite.Group()
paddle = Paddle()
ball = Ball()

all_sprites.add(paddle)
all_sprites.add(ball)

# 벽돌 생성
for row in range(5):
    for col in range(10):
        brick = Brick(100 + col * 70, 50 + row * 30)
        all_sprites.add(brick)
        bricks.add(brick)

# 게임 루프
running = True
while running:
    clock.tick(FPS)
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    # 게임 로직 업데이트
    all_sprites.update()

        # 공과 벽돌 충돌 검사
    brick_collision = pygame.sprite.spritecollide(ball, bricks, True)
    if brick_collision:
        ball.speedy *= -1

    
        # 공과 패들 충돌 검사
    if pygame.sprite.collide_rect(ball, paddle):
        ball.speedy *= -1

    # 화면 업데이트
    screen.fill(WHITE)
    all_sprites.draw(screen)
    pygame.display.flip()

# 게임 종료
pygame.quit()



