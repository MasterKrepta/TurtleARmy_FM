

public interface IAbility
{
    public int Level { get; set; }
    public int CostToUse { get; set; }
    void UseAbility();
}
