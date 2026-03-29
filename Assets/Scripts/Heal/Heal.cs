using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healPower = 3;

    public int ReturnHealPower()
    {
        return _healPower;
    }

    public void DestroyHeal()
    {
        gameObject.SetActive(false);
    }
}
