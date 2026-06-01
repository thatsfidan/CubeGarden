# 🌿 Cube Garden

An interactive 3D Unity game where a player-controlled cube explores a scene 
and collides with colored cubes, each triggering a unique effect.

## 🎮 Gameplay
Use WASD or Arrow keys to move your cube around the scene.
Touch colored cubes to trigger special effects — each cube disappears after interaction.

## 🟦 Cube Effects

| Cube | Effect |
|------|--------|
| 🔵 Blue | Player grows by 20% |
| 🔴 Red | Player shrinks by 20% |
| 🟢 Green | Player jumps upward |
| 🟣 Purple | Player speed doubles |
| 🟠 Orange | Player rotates 360° |
| ⚫ Black | Player resets |

## ⚠️ Special Rules
- Grow too large (>2× scale) → **"Too Powerful!"** — movement stops
- Shrink too small (<0.3× scale) → **"You Faded Away..."** — position resets

## 🛠️ Built With
- Unity (3D)
- C#
- Rigidbody & Trigger Collisions
- Smooth Camera Follow
