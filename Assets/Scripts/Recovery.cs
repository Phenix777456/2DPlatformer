using UnityEngine;

public class Recovery : MonoBehaviour
{
    [field: SerializeField] public int healPower { get; private set; } = 3;

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
