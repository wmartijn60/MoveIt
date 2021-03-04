public class StatsPlayer : StatSystem
{
    int weaponDamage = 15;
    public override int CalculateDamage() {
        return baseDamage + weaponDamage;
    }

}
