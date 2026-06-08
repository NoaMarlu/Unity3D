using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject block;
    private GameObject player;
    public float boxW;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        
    }

    public void Open()
    {

        int posX = 0;
        int posZ = 0;
        bool isOpen=false;

        if(player.transform.position.x >= transform.position.x|| player.transform.position.x <= transform.position.x)
        {
            if (player.transform.position.z < transform.position.z + 0.5f && player.transform.position.z > transform.position.z - 0.5f)
            {
                Debug.Log("ひゃっほう！");
                posX = 0;
                posZ = 1;
                isOpen = true;
            }
        }
        if(player.transform.position.z >= transform.position.z || player.transform.position.z <= transform.position.z)
        {
            if (player.transform.position.x <= transform.position.x + 0.5f && player.transform.position.x >= transform.position.x - 0.5f)
            {
                Debug.Log("うへあ！");
                posX = 1;
                posZ = 0;
                isOpen = true;
            }
        }

        if (!isOpen) return;
        Vector3 pos1=transform.position+new Vector3(posX,0,posZ);
        Vector3 pos2=transform.position+new Vector3(-posX,0,-posZ);

        Instantiate(block,pos1,transform.rotation);
        Instantiate(block,pos2,transform.rotation);
        Destroy(gameObject);

    }

}
