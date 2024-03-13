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
    public TextMeshProUGUI Sipariþkodu;
    public TextMeshProUGUI Malzemekodu;
    public string url = "https://www.google.com";
    public TextMeshProUGUI Ocak_sýcaklýðý;
    public TextMeshProUGUI Ocak_aðýrlýðý;
    public TextMeshProUGUI üsrt_kalýp_sýcaklýðý;
    public TextMeshProUGUI Alt_kalýp_sýcaklýðý;
    public TextMeshProUGUI Ývme;
    public TextMeshProUGUI Basýnç;

    public Image Sipariþ_miktarý;
    public Image OEE;
    public float Max_Sipariþ_miktarý = 800;
    public float Current_Sipariþ_miktarý = 0;
    public TextMeshProUGUI Siðariþ_miktar_text;
    public TextMeshProUGUI OEE_text;
    public int oee_time = 20;



    public float Timer = 3f;
    public float current_time = 0f;

    void Start()

    {
        urlButton.onClick.AddListener(OpenURL);
        Sipariþ_miktarý.fillAmount = 0f; 
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
                Ocak_sýcaklýðý.text = randomNumber.ToString();
                Ocak_aðýrlýðý.text = randomNumber.ToString();
                üsrt_kalýp_sýcaklýðý.text = randomNumber.ToString();
                Alt_kalýp_sýcaklýðý.text = randomNumber.ToString();
                Ývme.text = randomNumber.ToString();
                Basýnç.text = randomNumber.ToString();
               



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
            string[] Sipariþkodu_ref = Sipariþkodu.text.Split("-");
            string[] Malzemekodu_ref = Malzemekodu.text.Split("-");
            var sipariþ_int = (int.Parse(Sipariþkodu_ref[1]))+1;
            var Malzemekodu_int = (int.Parse(Malzemekodu_ref[1])) + 1;
            string new_Sipariþ = string.Concat(Sipariþkodu_ref[0],"-" ,sipariþ_int.ToString());
            string new_Malzemekodu = string.Concat(Malzemekodu_ref[0],"-" ,Malzemekodu_int.ToString());
            Sipariþkodu.text = new_Sipariþ;
            Malzemekodu.text = new_Malzemekodu;
            sÝpariþ_bar(50);
            




        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            anim.Play("Anim_world");




        }

    }

    public void sÝpariþ_bar(float artýþdeðer)
    {
        if(Current_Sipariþ_miktarý< Max_Sipariþ_miktarý) { 
        Current_Sipariþ_miktarý += artýþdeðer;
        Sipariþ_miktarý.fillAmount = Current_Sipariþ_miktarý / Max_Sipariþ_miktarý;
        string[] Sipariþ_miktarý_ = Siðariþ_miktar_text.text.Split("/");
        var sipariþ_int = (int.Parse(Sipariþ_miktarý_[0]))+artýþdeðer;
        Debug.Log(sipariþ_int);
        string new_Sipariþ = string.Concat(sipariþ_int.ToString(), "/", Sipariþ_miktarý_[1]);
        Siðariþ_miktar_text.text = new_Sipariþ;
        }

    }
    public void OEE_bar()
    {
        Debug.Log("oee");
        float randomNumber = Random.Range(75f, 85f);
        OEE.fillAmount = randomNumber/100;
        string[] OEE_ = OEE_text.text.Split("%");
        var new_deðer = OEE_[0] = ((int)randomNumber).ToString();
        string new_deðer_ = string.Concat("%", OEE_[0]);
        OEE_text.text = new_deðer_;
        

    }

    void OpenURL()
    {

        Application.OpenURL(url);
    }
}
