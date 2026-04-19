using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool IsRoute { get; private set; } = true;

    public void ChangeState()
    {
        IsRoute = false;
    }
}