using Skeleton;

public class Hero
{
    private string name;
    private int experience;
    private IWeapon weapon;

    public Hero(string name,IWeapon axe)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = axe;
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public IWeapon Weapon
    {
        get { return this.weapon; }
    }

    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
