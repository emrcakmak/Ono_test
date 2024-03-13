using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MauseManger : MonoBehaviour
{


    public Camera camera1;
    public Camera camera2;
    public GameObject geri;
    public Button geri_but;
    public bool infoPage = false;
    public Vector3 desiredRotationcam2 = new Vector3(0f, 124f, 0f);
    public Vector3 desiredRotationcam1 = new Vector3(27f, -132f, 0f);
    public Transform Pos1;
    public Transform Pos2;
    public GameObject Name;

    private void Awake()
    {

    }
    void Start()
    {
        
        //camera1.enabled = false;
        //camera2.enabled = true;
        Debug.Log(Camera.main);
        geri_but.onClick.AddListener(OnClick);
        geri_but.gameObject.SetActive(false);


    }


    void OnClick()
    {
        //camera1.enabled=true;
        //camera2.enabled=false;
        camera1.transform.position = Pos1.position;
        camera1.transform.eulerAngles = desiredRotationcam1;
        Name.SetActive(true);
        geri.SetActive(false);
        infoPage = false;

    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("EVobje"))
                {
                    Debug.Log("ÝþlemYapýlacakTag etiketine sahip objeye týklandý!");
                    //camera1.enabled=false;
                    //camera2.enabled = true;
                    infoPage = true;
                    camera1.transform.position = Pos2.position;

                    camera1.transform.eulerAngles = desiredRotationcam2;
                    Name.SetActive(false);
                    geri.SetActive(true);



                }
            }
        }
    }
}
