using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 1f;
    public bool IsSplit { get; private set; } = true;
    public int IncreaseScaleFactor { get; private set; } = 2;
    
    private float _decreaseFactor = 0.5f;

    public float ChangeChance()
    {
        return SplitChance * _decreaseFactor;
    }

    public void SetChance(float chance)
    {
        SplitChance = chance;
    }

    public void ChangeState()
    {
        IsSplit = false;
    }

    public void IncreaseFactor()
    {
        IncreaseScaleFactor++;
    }
}