using UnityEngine;

public class PrefabRegistry : MonoBehaviour
{
    private static PrefabRegistry _instance;
    [SerializeField] private GameObject foodPrefab;

    [SerializeField] private GameObject enemyPrefab;

    private static PrefabRegistry Instance
    {
        get
        {
            _instance ??= Resources.Load<PrefabRegistry>("PrefabRegistry");
            return _instance;
        }
    }

    public static GameObject FoodPrefab => Instance.foodPrefab;
    public static GameObject EnemyPrefab => Instance.enemyPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(_instance);
    }
}