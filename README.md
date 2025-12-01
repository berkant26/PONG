
<img width="376" height="712" alt="Screenshot_2" src="https://github.com/user-attachments/assets/240ddeea-9712-4a50-b9c0-5402c0df3cbf" />
<img width="360" height="707" alt="Screenshot_1" src="https://github.com/user-attachments/assets/c231e091-c114-4f14-8f17-f55d7215b86e" />


I've created a complete Pong game following SOLID principles and OOP best practices. Here's how the code follows these principles:
SOLID Principles Applied:

Single Responsibility: Each class has one job

PaddleMovement - only moves paddles
BallMovement - only handles ball physics
ScoreManager - only manages scores
UIManager - only updates UI


Open/Closed: ScoreManager is open for extension (new observers) but closed for modification
Liskov Substitution: PlayerInput and AIInput can be swapped via IPaddleInput interface
Interface Segregation: Small, focused interfaces like IPaddleInput and IScoreObserver
Dependency Inversion: High-level modules depend on abstractions (interfaces), not concrete classes
