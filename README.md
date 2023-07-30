# Character Health Controller

[中文](https://github.com/make-game-modules/character-health-controller/blob/main/README.zh-cn.md)

This project provides a Unity script for managing a character's health and damage effects. When the character is injured, it starts a timer and calls the `StopDamageEffect` method of `DamageEffectController` to stop the damage effect when the timer ends.

## How to Install

In your Unity project, clone this repository at any location using Git.

## How to Use

1. Attach the `CharacterHealthController` script to the character object.
2. Make the character take damage by calling the `TakeDamage` method.

## Parameter Settings

- `currentHealth`: The current health of the character.
- `maxHealth`: The maximum health of the character.
- `damageCooldown`: The cooldown time after being injured.
- `damageTimer`: The timer after being injured.

## Operating Principle

When the character is injured, this script calls the `TriggerDamageEffect` method of `DamageEffectController` to start the damage effect and starts the timer. When the timer ends, it calls the `StopDamageEffect` method of `DamageEffectController` to stop the damage effect.

## Copyright Information

This project uses the MIT open source license. Everyone is welcome to improve and use the project.

## Others

If you have any questions or suggestions about this project, you are welcome to submit them to us through issue or pull request.
