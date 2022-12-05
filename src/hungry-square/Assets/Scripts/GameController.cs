using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        Food.Spawn();
    }
}