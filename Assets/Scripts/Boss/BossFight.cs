using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{

    public Player Player;
    public Boss Boss;

    public Slider PlayerBar;
    public Slider BossBar;

    void Start()
    {
        SetFightStage(true);
    }

    public void SetFightStage(bool rdy)
    {
        Player.ready = rdy;
        Boss.ready = rdy;
    }

    public void DamageBoss(int dmg)
    {
        Boss.TakeDamage(dmg);
        BossBar.value = 100 / Boss.bossHealth * Boss.currentHealth;
    }

    public void DamagePlayer(int dmg)
    {
        Player.TakeDamage(dmg);
        PlayerBar.value = 100 / Player.playerHealth * Player.currentHealth;
    }
}
