# 角色生命值控制器

这个项目提供了一个 Unity 脚本，用于管理角色的生命值和受伤效果。当角色受伤时，它会启动一个定时器，并在定时器结束后调用 `DamageEffectController` 的 `StopDamageEffect` 方法以停止受伤效果。

## 如何安装

在你的 Unity 项目中，使用 Git 在任意位置克隆本仓库即可。

## 如何使用

1. 将 `CharacterHealthController` 脚本挂载到角色对象上。
2. 通过调用 `TakeDamage` 方法来让角色受到伤害。

## 参数设置

- `currentHealth`： 角色当前的生命值。
- `maxHealth`： 角色生命值的上限。
- `damageCooldown`： 受伤后的冷却时间。
- `damageTimer`： 受伤后的定时器。

## 运行原理

当角色受伤时，该脚本会调用 `DamageEffectController` 的 `TriggerDamageEffect` 方法来启动受伤效果，并启动定时器。当定时器结束后，将调用 `DamageEffectController` 的 `StopDamageEffect` 方法来停止受伤效果。

## 版权信息

本项目采用 MIT 开源许可证，欢迎任何人对项目的改进和使用。

## 其他

如果你有任何关于这个项目的问题或建议，欢迎通过 issue 或者 pull request 提交给我们。
