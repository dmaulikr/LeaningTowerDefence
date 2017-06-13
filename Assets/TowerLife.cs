using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class TowerLife : MonoBehaviour {

    private static int _mnoznik;
    public static float zycie = 100000;
    private float maxzycie = zycie;
    private float _;

    [SerializeField]
    private Image Mask;
    [SerializeField]
    private Text Licznikczasu;

	void Start () {
        _mnoznik = PlayerPrefs.GetInt("pkt2");
        StartCoroutine(tajmer());

	}
	void Update () {
        HBar();
	}
    private void HBar()
    {
        Mask.fillAmount = skalowanie(maxzycie, zycie);
    }
    private float skalowanie(float max, float min)
    {
        return min / max;
    }
    public IEnumerator tajmer()
    {

        yield return new WaitForSeconds(1f);
    }
}
