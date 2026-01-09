using UnityEngine;

public class Potion : MonoBehaviour, ICollectible
{
    [SerializeField] string name = "Potion";
    public string Name
    {
        get => name;
    }

    public void Collect(ICollector collector)
    {
           collector.CollectItem(this);
    }
}
