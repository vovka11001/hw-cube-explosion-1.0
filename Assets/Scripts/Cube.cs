using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 1f;
    private float _decreaseFactor = 0.5f;

    public float ChangeChance()
    {
        return SplitChance * _decreaseFactor;
    }

    public void SetChance(float chance)
    {
        SplitChance = chance;
    }
}