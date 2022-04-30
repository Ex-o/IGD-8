using CoinCounter;
using UnityEngine;

namespace System.Utils
{
    public static class CoinCallbacks
    {
        public static void Update(UnityEngine.UI.Text text, Count count)
        {
            text.text = $"{count.Value}";
            Debug.Log(count.Value);
        }
    }
}