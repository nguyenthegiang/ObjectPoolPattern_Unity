# ObjectPoolPattern_Unity
[PRU221m - Presentation]

## Introduction
There are 4 Projects in this Repository:
 - **CodeDemo**: a simple game scene where you are a spaceship that can move up and down and shoot bullets
   + _Bullet.cs_: The bullet object that will be shot
   + _Spaceship.cs_: The player that will shoot the bullet
 - **CodeDemo_WithPool**: same game scene but using Object Pool Design Pattern to optimize bullets controlling
   + _Bullet.cs_: The Reusable Bbject that will be used for pooling
   + _ObjectPool.cs_: The Reusable Pool used to make the pool of Bullets
   + _Spaceship.cs_: The Client that will use the pool to get bullets
 - **CodeDemo_BetterPool**: optimize the usage of Object Pool Pattern by changing the code to minimize Algorithmic Complexity
   + _Bullet.cs_: The Reusable Bbject that will be used for pooling
   + _ObjectPool.cs_: The Reusable Pool used to make the pool of Bullets, improve the performance by modifying its methods 
   + _Spaceship.cs_: The Client that will use the pool to get bullets 
 - **CodeDemo_UnityPool**: using the built-in Pool of Unity 2021 to simplify usage
   + _Bullet.cs_: The Reusable Bbject that will be used for pooling
   + _Spaceship.cs_: The Client that will use the ObjectPool from UnityEngine.Pool to get bullets

## Usage
With each Project, follow these steps to run:
 - Create an Unity Project of version 2021 or above and replace the Assets folder with the Assets folder of the project from Repository
 - Open the SampleScene (discard changes) and run the game

Gameplay:
 - Use Arrow key to move Up and Down
 - Press Space to shoot
