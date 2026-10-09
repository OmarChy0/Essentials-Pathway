# Essentials Pathway

A Unity project made of five small scenes, each one demonstrating a core game development skill: free camera navigation, 3D physics, 2D and 3D audio, programming, and a top-down 2D game. A main menu lets you pick any scene, and every scene has a **Back** button to return to it.

![Main menu](docs/images/menu.png)

## Introduction

This project was built while following the **Unity Essentials** pathway on [Unity Learn](https://learn.unity.com/pathways). Unity Essentials is a free, beginner-friendly course made by Unity. It is designed for anyone who is new to Unity and wants the background, context, and skills to confidently create in the Unity Editor. The pathway is hands-on: instead of only reading about concepts, you build small projects and put each new skill into practice right away.

The course is where I learned the foundations of working with Unity, including:

- **Getting started:** installing the Unity Editor, and creating and managing projects with Unity Hub.
- **The Unity Editor:** understanding the main windows and tools, and how they fit together in a normal workflow.
- **Scenes:** creating and managing scenes, and placing and arranging objects in them.
- **Navigation:** moving around in both 3D space and 2D space in the Scene view.
- **Real-time 3D:** working with 3D objects, lighting, cameras, and physics.
- **Programming basics:** writing simple C# scripts to control how objects behave and respond to the player.
- **Audio:** adding sound to a scene, including the difference between 2D and 3D sound.
- **Real-time 2D:** building a simple 2D scene and controlling a character in it.

To practice all of this, I built the five scenes in this repository. Each scene matches one topic from the course, so together they show what I learned: navigation, 3D, audio, programming, and 2D.

## Scenes

### 1. Playground – Navigation

A free-camera scene set in an outdoor playground. Four digits are hidden somewhere in the scene, and you type the 4-digit code into the box at the top of the screen once you find them.

- **Goal:** Find the 4 hidden digits and enter the code.
- **Controls:**
  - `W` `A` `S` `D`: move the camera
  - `Q` `E`: move the camera down and up
  - Right mouse button (hold): look around

![Playground scene](docs/images/playground.png)

### 2. Kid's Room – 3D

A 3D physics scene in a kid's bedroom. A ball collides with objects in the room, and a physics display shows what is happening.

- **Goal:** Hit objects with the ball and watch how they react.
- **Controls:** Same as the Playground scene.
- **Features:**
  - Ball collisions with objects in the room
  - Physics display
  - **Restart** button to reset the scene

![Kid's Room scene](docs/images/kids-room.png)

### 3. Kitchen – Audio

A kitchen scene that shows the difference between 2D sound and 3D sound. 2D sound plays the same no matter where you are, while 3D sound gets louder or quieter depending on where the camera is relative to the sound source.

- **Goal:** Move around the kitchen and listen to how the sound changes.
- **Controls:** Same as the Playground scene.

![Kitchen scene](docs/images/kitchen.png)

### 4. Living Room – Programming

A scripted game where you control a mouse running around a living room and collecting cheese. A counter at the top of the screen shows how many collectibles remain.

- **Goal:** Collect all the cheese.
- **Controls:**
  - Arrow keys: move
  - `Space`: jump

![Living Room scene](docs/images/mouse-collecting.png)

### 5. Top Down – 2D

A 2D top-down view of a living room where you drive a small car and collect stars. A counter at the top of the screen shows how many stars remain.

- **Goal:** Collect all the stars.
- **Controls:** Arrow keys only

![Top Down 2D scene](docs/images/car-stars.png)

## Controls Summary

| Scene | Controls |
|---|---|
| Playground – Navigation | `W` `A` `S` `D` move, `Q` `E` down/up, hold right mouse button to look |
| Kid's Room – 3D | Same as Playground |
| Kitchen – Audio | Same as Playground |
| Living Room – Programming | Arrow keys to move, `Space` to jump |
| Top Down – 2D | Arrow keys |

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/OmarChy0/Essentials-Pathway.git
   ```
2. Open **Unity Hub**, click **Add**, and select the cloned project folder.
3. Open the project with the Unity version shown in `ProjectSettings/ProjectVersion.txt`.
4. Open the main menu scene from the `Assets/Scenes` folder and press **Play**.

## Built With

- [Unity](https://unity.com/)
- C#

## Learning Resource

- [Unity Essentials Pathway on Unity Learn](https://learn.unity.com/pathways)

## Author

**Omar** ([@OmarChy0](https://github.com/OmarChy0))
