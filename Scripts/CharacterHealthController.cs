using System.Collections;
using UnityEngine;

/// <summary>
/// 这是一个用于管理角色生命值的Unity脚本。当角色受伤时，它会启动一个定时器，
/// 并在定时器结束后调用 DamageEffectController 的 StopDamageEffect 方法以停止受伤效果。
/// 你需要将此脚本挂载到你希望管理的游戏角色对象上，这样它就可以正常工作了。
/// </summary>
public class CharacterHealthController : MonoBehaviour
{
    // 定义角色当前的生命值
    public float currentHealth = 100f;
    // 定义角色生命值的上限
    public float maxHealth = 100f;
    // 定义受伤后的冷却时间
    public float damageCooldown = 1.0f;
    // 定义受伤后的定时器
    public float damageTimer = 0.0f;
    // 定义角色是否受伤的状态
    private bool isDamaged = false;

    /// <summary>
    /// 在Awake方法中确保角色的当前生命值不会超过其上限。
    /// Awake是Unity的一个生命周期方法，当对象实例化时会被调用。
    /// </summary>
    private void Awake()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// 获取角色当前的生命值百分比。
    /// </summary>
    /// <returns>返回角色当前的生命值百分比。</returns>
    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }

    /// <summary>
    /// 角色受到伤害并扣除相应的生命值，同时调用DamageEffectController的TriggerDamageEffect方法产生受伤效果，并启动定时器。
    /// </summary>
    /// <param name="damage">角色受到的伤害值。</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        DamageEffectController damageEffectController = GetComponent<DamageEffectController>();
        if (damageEffectController != null)
        {
            damageEffectController.TriggerDamageEffect();
            isDamaged = true;
            damageTimer = damageCooldown;
        }
    }

    /// <summary>
    /// Update是Unity的一个生命周期方法，会在每一帧被调用。在这里，我们用它来计算受伤效果的冷却时间，
    /// 当冷却时间结束后，调用DamageEffectController的StopDamageEffect方法来停止受伤效果。
    /// </summary>
    private void Update()
    {
        if (isDamaged)
        {
            damageTimer -= Time.deltaTime;

            if (damageTimer <= 0)
            {
                DamageEffectController damageEffectController = GetComponent<DamageEffectController>();
                if (damageEffectController != null)
                {
                    damageEffectController.StopDamageEffect();
                }

                isDamaged = false;
            }
        }
    }
}
