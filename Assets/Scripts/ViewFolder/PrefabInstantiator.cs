using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public GameObject Instantiate()
    {
        return GameObject.Instantiate(prefab, transform);
    }
}
