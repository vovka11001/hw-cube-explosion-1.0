using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool IsRoute { get; private set; } = true;
    public float SplitChance { get; private set; } = 1f;
    private float _decreaseFactor = 0.5f;

    public void ChangeState()
    {
       IsRoute = false;
    }

    public void ChangeChance()
    {
        SplitChance *= _decreaseFactor;
    }
}