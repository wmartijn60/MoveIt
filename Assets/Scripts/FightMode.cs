using UnityEngine;

public class FightMode : MonoBehaviour
{
    [SerializeField] private StatSystem boss;
    [SerializeField] private StatSystem player;

    public void BossAttackPlayer() {
        player.TakeDamage(boss.CalculateDamage());
    }

    public void PlayerAttackBoss() {
        boss.TakeDamage(player.CalculateDamage());
    }

    public void ResetBossHealth() {
        boss.ResetHealth();
    }

    public void ResetPlayerHealth() {
        player.ResetHealth();
    }
}
