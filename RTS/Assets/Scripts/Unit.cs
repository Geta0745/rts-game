using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitSelecions.Instance.unitList.Add(this.gameObject);
    }

    private void OnDestroy() {
        UnitSelecions.Instance.unitList.Remove(this.gameObject);
    }
}
