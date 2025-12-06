using System;

public abstract class Card
{
    protected string name;
    protected string description;
    protected int energyCost;
    
    public Card(string name, string description, int energyCost)
    {
        this.name = name;
        this.description = description;
        this.energyCost = energyCost;
    }
    
    public abstract void Play(Attributes user, Attributes target);
    
    public virtual bool CanPlay(Attributes user)
    {
        return user.GetEnergy() >= energyCost;
    }
    
    public int GetEnergyCost()
    {
        return energyCost;
    }
    
    public string GetName()
    {
        return name;
    }
    
    public string GetDescription()
    {
        return description;
    }
    
    public virtual void OnDraw()
    {
        
    }
    
    public virtual void OnDiscard()
    {

    }
}

public class AttackCard : Card
{
    private int damage;
    private string damageType;
    private bool targetAll;

    public AttackCard(string name, string description, int energyCost, int damage, string damageType)
        : base(name, description, energyCost, "Common")
    {
        this.damage = damage;
        this.damageType = damageType;
        this.targetAll = false;
    }
    
    public AttackCard(string name, string description, int energyCost, int damage, string damageType, string rarity)
        : base(name, description, energyCost, rarity)
    {
        this.damage = damage;
        this.damageType = damageType;
        this.targetAll = false;
    }
    
    public override void Play(Attributes user, Attributes target)
    {
        if (!user.UseEnergy(energyCost))
        {
            Console.WriteLine("Not enough energy!");
            return;
        }
        
        ApplyDamage(target);
        
        Console.WriteLine($"{user.GetName()} plays {name}!");
        Console.WriteLine($"{target.GetName()} takes {damage} {damageType} damage!");
    }

    private void ApplyDamage(Attributes target)
    {
        target.TakeDamage(damage);
    }
    
    public int GetDamage()
    {
        return damage;
    }
    
    public string GetDamageType()
    {
        return damageType;
    }
    
    public bool IsAOE()
    {
        return targetAll;
    }
    
    public void SetTargetAll(bool value)
    {
        targetAll = value;
    }
}

public class SkillCard : Card
{
    private string effectType;
    private int effectValue;
    
    public SkillCard(string name, string description, int energyCost, string effectType, int effectValue)
        : base(name, description, energyCost, "Common")
    {
        this.effectType = effectType;
        this.effectValue = effectValue;
    }

    public SkillCard(string name, string description, int energyCost, string effectType, int effectValue, string rarity)
        : base(name, description, energyCost, rarity)
    {
        this.effectType = effectType;
        this.effectValue = effectValue;
    }
    
    public override void Play(Attributes user, Attributes target)
    {
        if (!user.UseEnergy(energyCost))
        {
            Console.WriteLine("Not enough energy!");
            return;
        }
        
        ApplyEffect(user, target);
        
        Console.WriteLine($"{user.GetName()} plays {name}!");
    }
    
    private void ApplyEffect(Attributes user, Attributes target)
    {
        switch (effectType.ToUpper())
        {
            case "BLOCK":
                if (user is PlayerAtt player)
                {
                    player.AddBlock(effectValue);
                    Console.WriteLine($"{user.GetName()} gains {effectValue} block!");
                }
                break;
                
            case "HEAL":
                user.Heal(effectValue);
                Console.WriteLine($"{user.GetName()} heals {effectValue} HP!");
                break;
                
            case "DRAW":
                Console.WriteLine($"{user.GetName()} will draw {effectValue} cards!");
                break;
                
            case "ENERGY":
                Console.WriteLine($"{user.GetName()} gains {effectValue} energy!");
                break;
                
            default:
                Console.WriteLine($"Unknown effect type: {effectType}");
                break;
        }
    }
    
    public string GetEffectType()
    {
        return effectType;
    }
    
    public int GetEffectValue()
    {
        return effectValue;
    }
}