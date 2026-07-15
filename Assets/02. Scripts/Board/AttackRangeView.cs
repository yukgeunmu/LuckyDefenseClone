using LuckyDefense.Heroes.Data;
using UnityEngine;

public class AttackRangeView : MonoBehaviour
{
    [SerializeField]
    private GameObject attackRangeObject;

    public void Show(float range)
    {
        attackRangeObject.SetActive(true);

        this.transform.localScale = new Vector3(range * 2, range * 2, 1);
    }

    public void Hide()
    {
        attackRangeObject.SetActive(false);
    }

}
