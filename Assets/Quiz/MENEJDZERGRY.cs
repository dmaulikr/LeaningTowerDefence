using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class MENEJDZERGRY : MonoBehaviour {

	public Pytania[] pytan;
	private static List<Pytania> Nnoodpowiedzi;
	private Pytania aktualnepytanie;
	int iloscpytan = 10;
    private static int pkt1 = 0;
    int pkts = pkt1;
    private bool Punktowanie = false;

	[SerializeField]
	private Text trescText;
	[SerializeField]
	private Text a;
	[SerializeField]
	private Text b;
	[SerializeField]
	private Text c;
	[SerializeField]
	private Text d;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text odp1;
    [SerializeField]
    private Text odp2;
    [SerializeField]
    private Text odp3;
    [SerializeField]
    private Text odp4;


	[SerializeField]
	private float czasmiedzypytaniami = 12f;
	void Start ()
	{

        Screen.orientation = ScreenOrientation.LandscapeLeft;
		if (Nnoodpowiedzi == null) {
			Nnoodpowiedzi = pytan.ToList<Pytania>();
		}
        if (Nnoodpowiedzi.Count == iloscpytan - 5)
        {
            animator.SetTrigger("K");
            trescText.text = "Gratulacje uzyskałeś " + pkt1 + "/5 punktów";         
            odp1.text = "";
            odp2.text = "";
            odp3.text = "";
            odp4.text = "";
            StartCoroutine(czaz());
        }
        else
        {
            StartCoroutine(czas());
            losowepytanie();
        }
	}

	void losowepytanie() {
		int losowosc = Random.Range(0, Nnoodpowiedzi.Count);
		aktualnepytanie = Nnoodpowiedzi[losowosc];
		trescText.text = aktualnepytanie.tresc;
		a.text = aktualnepytanie.A;
		b.text = aktualnepytanie.B;
		c.text = aktualnepytanie.C;
		d.text = aktualnepytanie.D;
	}

	IEnumerator Nastepnepytanie ()
	{
            Nnoodpowiedzi.Remove(aktualnepytanie);
            yield return new WaitForSeconds(czasmiedzypytaniami);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
		IEnumerator czas ()
	{
		yield return new WaitForSeconds(11f);
            StartCoroutine(Nastepnepytanie());
	}
        IEnumerator czaz()
        {
            yield return new WaitForSeconds(1f);
            PlayerPrefs.SetInt("pkt2", pkt1);
            Application.LoadLevel("Shooter");
        }
    

	public void Awyboruzytkownika(){
        animator.SetTrigger("A");
		if (aktualnepytanie.prawda == 'A') {
            aktualnepytanie.prawda = 'B';
            pkt1++;
            odp1.text = "A";
            odp2.text = "Odpowiedź jest: ";
            odp3.text = "Poprawna !!!";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
		}
        else {
            odp1.text = "A";
            odp2.text = "Odpowiedź jest: ";
            odp3.text = "Błędna !!!";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
		}
            StartCoroutine(Nastepnepytanie());
		}

	public void Bwyboruzytkownika(){
        animator.SetTrigger("B");
		if (aktualnepytanie.prawda == 'B') {
            aktualnepytanie.prawda = 'C';
            pkt1++;
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "B";
            odp3.text = "Poprawna !!!";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
        }
        else
        {
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "B";
            odp3.text = "Błędna !!!";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
        }
			StartCoroutine(Nastepnepytanie());
		}

	public void Cwyboruzytkownika(){
        animator.SetTrigger("C");
		if (aktualnepytanie.prawda == 'C') {
            aktualnepytanie.prawda = 'D';
            pkt1++;
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "Poprawna !!!";
            odp3.text = "C";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
        }
        else
        {
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "Błędna !!!";
            odp3.text = "C";
            odp4.text = "Masz " + pkt1 + "/5 punktów";
        }
			StartCoroutine(Nastepnepytanie());
		}
	public void Dwyboruzytkownika(){
        animator.SetTrigger("D");
		if (aktualnepytanie.prawda == 'D') {
            aktualnepytanie.prawda = 'A';
            pkt1++;
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "Poprawna !!!";
            odp3.text = "Masz " + pkt1 + "/5 punktów";
            odp4.text = "D";
        }
        else
        {
            odp1.text = "Odpowiedź jest: ";
            odp2.text = "Błędna !!!";
            odp3.text = "Masz " + pkts + "/5 punktów";
            odp4.text = "D";
        }
			StartCoroutine(Nastepnepytanie());
		}
}
