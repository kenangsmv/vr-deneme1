using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class Items
{
    public int id;
    public double price;
    public string token_add;
    public string name;
    public string type;
    public string link_img;

}

[System.Serializable]
public class ItemList
{
    public Items[] items;
}



public class Proximity : MonoBehaviour
{
    public string newTitle;
    public string newAuthor;
    public string newDesc;
    private Transform other;
    private Text myTitle;
    private Text myAuthor;
    private Text myDesc;
    private float dist;
    private GameObject player;
    private GameObject message1;
    private GameObject message2;
    private GameObject message3;
    private bool check;
	private string textDeger;
     public ItemList myitemList = new ItemList();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        other = player.GetComponent<Transform>();	
        message1 = GameObject.FindWithTag("ArtTitle");
        message2 = GameObject.FindWithTag("Auth");
        message3 = GameObject.FindWithTag("Description");
        myTitle = message1.GetComponent<Text>();
        myTitle.text = "";
        myAuthor = message2.GetComponent<Text>();
        myAuthor.text = "";
        myDesc = message3.GetComponent<Text>();
        myDesc.text = "";
        check = false;
		Debug.Log("dddd");
			
		StartCoroutine(GetRequest("https://qzlsklfacc.medianetwork.cloud/get_nft?collection=flippies&page=0&limit=30&order=oldest&fits=any&trait=&search=&min=0&max=0&listed=true&ownedby=&attrib_count=&bid=all"));
	}
	
	IEnumerator GetRequest(string uri)
{
    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    yield return uwr.SendWebRequest();

    if (uwr.isNetworkError)
    {
        Debug.Log("Error While Sending: " + uwr.error);
    }
    else
    {
      	textDeger = uwr.downloadHandler.text;
		myitemList = JsonUtility.FromJson<ItemList>(textDeger);
        string url_adress = "https://solanart.io/search/?token=" + myitemList.items[0].token_add;
         Debug.Log("name: " + myitemList.items[0].name);
         Debug.Log("type: " + myitemList.items[0].type);
         Debug.Log("image_url: " + myitemList.items[0].link_img);
         Debug.Log("fiyat: " + myitemList.items[0].price);
         Debug.Log("nft url adresi: " + url_adress);
    }
}

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            dist = Vector3.Distance(transform.position, other.position);
            if (dist < 4)
            {
				

					
				

         string url_adress = "https://solanart.io/search/?token=" + myitemList.items[0].token_add;
         Debug.Log("name: " + myitemList.items[0].name);
         Debug.Log("type: " + myitemList.items[0].type);
         Debug.Log("image_url: " + myitemList.items[0].link_img);
         Debug.Log("fiyat: " + myitemList.items[0].price);
         Debug.Log("nft url adresi: " + url_adress);
			for(int i =0;i<11;i++)
			{
				if("https://arweave.net/"+newTitle==myitemList.items[i].link_img.ToString())
				{
					myTitle.text= "Name: " +myitemList.items[i].name;
					myAuthor.text = "Price: " +myitemList.items[i].price.ToString();
					myDesc.text = "Token Address: " +myitemList.items[i].token_add;
							//for buy 
							if (Input.GetKey(KeyCode.B))
							{
								Application.OpenURL("https://solanart.io/search/?token="+myitemList.items[i].token_add);
							}
					i=11;
				}	
			}
               
                check = true;
            }
            if (dist > 4 && check == true)
            {
                Start();
            }
        }
		
		

    }
}
