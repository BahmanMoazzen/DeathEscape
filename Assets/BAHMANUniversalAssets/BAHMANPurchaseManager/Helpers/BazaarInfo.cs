using UnityEngine;
using UnityEngine.Events;
using Bazaar.Poolakey;
using Bazaar.Poolakey.Data;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "NewBazaar", menuName = "Bahman/Bazaar", order = 1)]
public class BazaarInfo : MarketInfo
{
    protected Payment _bazaarIAB;
    public override void _ConsumProduct(string iTokenID)
    {
        _bazaarIAB.Consume(iTokenID, onConsumeDone);
    }
    public override void _BuyWholeProcess(string iSKU, UnityAction iOnSuccess, UnityAction iOnFail)
    {
        base._BuyWholeProcess(iSKU, iOnSuccess, iOnFail);
        _PurchaseProduct(iSKU);

    }
    public override void _DisposeMarket()
    {
        _bazaarIAB.Disconnect();
    }

    public override void _InitializeMarket()
    {
        _dLog("initializing ...");
        SecurityCheck securityCheck = SecurityCheck.Enable(_MarketKey);
        PaymentConfiguration paymentConfiguration = new PaymentConfiguration(securityCheck);
        _bazaarIAB = new Payment(paymentConfiguration);

        _bazaarIAB.Connect(onInitDone);

    }

    public override void _PurchaseProduct(string iSKU)
    {
        _bazaarIAB.Purchase(iSKU, SKUDetails.Type.inApp, null, onPurchaseDone);
    }

    public override void _QueryInventory()
    {
        throw new System.NotImplementedException();
    }

    public override void _QueryPurchases()
    {

        _bazaarIAB.GetPurchases(SKUDetails.Type.all, onQueryPurchasesDone);
    }

    public override void _QuerySKUDetails()
    {
        throw new System.NotImplementedException();
    }

    void onInitDone(Bazaar.Data.Result<bool> iResult)
    {

        if (iResult.status == Bazaar.Data.Status.Success)
        {
            _dLog("Initialization Success. Querying ...");
            _QueryPurchases();
        }
        else
        {
            _dLog("Initialization Failed.");
            _onFail();
        }
    }

    void onQueryPurchasesDone(Bazaar.Data.Result<List<PurchaseInfo>> iResult)
    {

        if (iResult.status == Bazaar.Data.Status.Success)
        {
            _dLog("Querying Success. Consuming ...");
            foreach (PurchaseInfo p in iResult.data)
            {
                _ConsumProduct(p.purchaseToken);
            }
        }
        else
        {
            _dLog("No Old Purchase Found!");
        }
    }
    void onConsumeDone(Bazaar.Data.Result<bool> iResult)
    {
        if (iResult.status == Bazaar.Data.Status.Success)
        {
            _dLog("Consume Successfull.");
            _onSuccess();
        }
        else
        {
            _dLog("Consume Failed.");
            if (_currentSKU != string.Empty)
            {

                _onFail();
            }
        }
    }
    void onPurchaseDone(Bazaar.Data.Result<PurchaseInfo> iResult)
    {
        if (iResult.status == Bazaar.Data.Status.Success)
        {
            _dLog("Purchase Done. Consuming ...");
            _ConsumProduct(iResult.data.purchaseToken);
        }
        else
        {
            _dLog("Purchase Failed.");
            _onFail();
        }
    }
}
