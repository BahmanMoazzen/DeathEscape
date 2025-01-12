using UnityEngine;
using UnityEngine.Events;

public class BAHMANPrefReader : MonoBehaviour
{
    [SerializeField] string _prefName;
    [SerializeField] string _prefValue;
    public UnityEvent _onValueExists;
    public UnityEvent _onValueNotExists;
    private void OnEnable()
    {
        if (PlayerPrefs.GetString(_prefName, string.Empty) == _prefValue)
        {
            _onValueExists?.Invoke();
        }
        else
        {
            _onValueNotExists?.Invoke();
        }
        gameObject.SetActive(false);
    }
}
