using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject InfoPage;
    [SerializeField]
    private MauseManger masue;
    public Animator anim;
    public Button urlButton;
    public TextMeshProUGUI Sipari�kodu;
    public TextMeshProUGUI Malzemekodu;
    public string url = "https://www.google.com";
    public TextMeshProUGUI Ocak_s�cakl���;
    public TextMeshProUGUI Ocak_a��rl���;
    public TextMeshProUGUI �srt_kal�p_s�cakl���;
    public TextMeshProUGUI Alt_kal�p_s�cakl���;
    public TextMeshProUGUI �vme;
    public TextMeshProUGUI Bas�n�;

    public Image Sipari�_miktar�;
    public Image OEE;
    public float Max_Sipari�_miktar� = 800;
    public float Current_Sipari�_miktar� = 0;
    public TextMeshProUGUI Si�ari�_miktar_text;
    public TextMeshProUGUI OEE_text;
    public int oee_time = 20;



    public float Timer = 3f;
    public float current_time = 0f;

    void Start()

    {
        urlButton.onClick.AddListener(OpenURL);
        Sipari�_miktar�.fillAmount = 0f; 
        OEE.fillAmount = 0f;
        anim.GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        current_time += Time.deltaTime;

        if (current_time >= Timer)
        {
            Debug.Log("girdi");
            for (int i = 0; i <= 5; i++)
            {
                float randomNumber = Random.Range(450f, 550f);
                Ocak_s�cakl���.text = randomNumber.ToString();
                Ocak_a��rl���.text = randomNumber.ToString();
                �srt_kal�p_s�cakl���.text = randomNumber.ToString();
                Alt_kal�p_s�cakl���.text = randomNumber.ToString();
                �vme.text = randomNumber.ToString();
                Bas�n�.text = randomNumber.ToString();
               



            }

            OEE_bar();
            current_time = 0;

        }


        if (masue.infoPage)
        {
            InfoPage.SetActive(true);

        }

        else
        {
            InfoPage.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            string[] Sipari�kodu_ref = Sipari�kodu.text.Split("-");
            string[] Malzemekodu_ref = Malzemekodu.text.Split("-");
            var sipari�_int = (int.Parse(Sipari�kodu_ref[1]))+1;
            var Malzemekodu_int = (int.Parse(Malzemekodu_ref[1])) + 1;
            string new_Sipari� = string.Concat(Sipari�kodu_ref[0],"-" ,sipari�_int.ToString());
            string new_Malzemekodu = string.Concat(Malzemekodu_ref[0],"-" ,Malzemekodu_int.ToString());
            Sipari�kodu.text = new_Sipari�;
            Malzemekodu.text = new_Malzemekodu;
            s�pari�_bar(50);
            




        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            anim.Play("Anim_world");




        }

    }

    public void s�pari�_bar(float art��de�er)
    {
        if(Current_Sipari�_miktar�< Max_Sipari�_miktar�) { 
        Current_Sipari�_miktar� += art��de�er;
        Sipari�_miktar�.fillAmount = Current_Sipari�_miktar� / Max_Sipari�_miktar�;
        string[] Sipari�_miktar�_ = Si�ari�_miktar_text.text.Split("/");
        var sipari�_int = (int.Parse(Sipari�_miktar�_[0]))+art��de�er;
        Debug.Log(sipari�_int);
        string new_Sipari� = string.Concat(sipari�_int.ToString(), "/", Sipari�_miktar�_[1]);
        Si�ari�_miktar_text.text = new_Sipari�;
        }

    }
    public void OEE_bar()
    {
        Debug.Log("oee");
        float randomNumber = Random.Range(75f, 85f);
        OEE.fillAmount = randomNumber/100;
        string[] OEE_ = OEE_text.text.Split("%");
        var new_de�er = OEE_[0] = ((int)randomNumber).ToString();
        string new_de�er_ = string.Concat("%", OEE_[0]);
        OEE_text.text = new_de�er_;
        

    }

    void OpenURL()
    {

        Application.OpenURL(url);
    }
}
