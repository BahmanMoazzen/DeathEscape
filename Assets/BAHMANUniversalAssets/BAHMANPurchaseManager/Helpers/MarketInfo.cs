using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MarketInfo : ScriptableObject
{
    public string _MarketKey;
    public string[] _SKUs;
    protected UnityAction _onSuccess, _onFail;
    protected string _currentSKU;
    public virtual void _BuyWholeProcess(string iSKU, UnityAction iOnSuccess, UnityAction iOnFail)
    {

        _onSuccess = iOnSuccess;
        _onFail = iOnFail;
        _currentSKU = iSKU;
        
    }
    public abstract void _InitializeMarket();
    public abstract void _DisposeMarket();
    public abstract void _QueryInventory();
    public abstract void _QuerySKUDetails();
    public abstract void _QueryPurchases();
    public abstract void _PurchaseProduct(string iSKU);
    public abstract void _ConsumProduct(string iSKU);

}
