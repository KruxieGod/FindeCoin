using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollectorUI : GUI
{
    [SerializeField] private TextMeshProUGUI _textCoins;

    public void SetCoins(int count) => _textCoins.SetText(count.ToString());
}
