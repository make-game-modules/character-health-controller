using System.Collections;
using UnityEngine;

/// <summary>
/// ����һ�����ڹ����ɫ����ֵ��Unity�ű�������ɫ����ʱ����������һ����ʱ����
/// ���ڶ�ʱ����������� DamageEffectController �� StopDamageEffect ������ֹͣ����Ч����
/// ����Ҫ���˽ű����ص���ϣ���������Ϸ��ɫ�����ϣ��������Ϳ������������ˡ�
/// </summary>
public class CharacterHealthController : MonoBehaviour
{
    // �����ɫ��ǰ������ֵ
    public float currentHealth = 100f;
    // �����ɫ����ֵ������
    public float maxHealth = 100f;
    // �������˺����ȴʱ��
    public float damageCooldown = 1.0f;
    // �������˺�Ķ�ʱ��
    public float damageTimer = 0.0f;
    // �����ɫ�Ƿ����˵�״̬
    private bool isDamaged = false;

    /// <summary>
    /// ��Awake������ȷ����ɫ�ĵ�ǰ����ֵ���ᳬ�������ޡ�
    /// Awake��Unity��һ���������ڷ�����������ʵ����ʱ�ᱻ���á�
    /// </summary>
    private void Awake()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// ��ȡ��ɫ��ǰ������ֵ�ٷֱȡ�
    /// </summary>
    /// <returns>���ؽ�ɫ��ǰ������ֵ�ٷֱȡ�</returns>
    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }

    /// <summary>
    /// ��ɫ�ܵ��˺����۳���Ӧ������ֵ��ͬʱ����DamageEffectController��TriggerDamageEffect������������Ч������������ʱ����
    /// </summary>
    /// <param name="damage">��ɫ�ܵ����˺�ֵ��</param>
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
    /// Update��Unity��һ���������ڷ���������ÿһ֡�����á������������������������Ч������ȴʱ�䣬
    /// ����ȴʱ������󣬵���DamageEffectController��StopDamageEffect������ֹͣ����Ч����
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
