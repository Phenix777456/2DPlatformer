using UnityEngine;

public class WorldSpaceUI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _yPosition;

    private void LateUpdate()
    {
        transform.position = _target.position + new Vector3(0, _yPosition, 0);

        bool isActive = _target.gameObject.activeInHierarchy;

        if (isActive == false)
        {
            gameObject.SetActive(false);
        }
    }
}
