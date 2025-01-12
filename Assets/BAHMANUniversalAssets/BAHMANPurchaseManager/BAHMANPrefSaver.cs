using UnityEngine;

public class BAHMANPrefSaver : MonoBehaviour
{
    [SerializeField] string _prefName;
    [SerializeField] string _prefValue;
    private void OnEnable()
    {
        PlayerPrefs.SetString(_prefName, _prefValue);
        gameObject.SetActive(false);
    }
}
