using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseRoutineActivator : MonoBehaviour
{
    [SerializeField] AllSKUs _currentSKU;
    private void OnEnable()
    {
        BAHMANPurchaseManager._Instance._StartPurchase(_currentSKU);
        gameObject.SetActive(false);
    }
}
