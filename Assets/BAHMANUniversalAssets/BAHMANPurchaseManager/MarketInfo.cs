using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarketInfo : ScriptableObject
{
    public string MarketKey;
    public abstract void InitializeMarket();
    public abstract void QueryInventory();
    
}
