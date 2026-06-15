using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject block;
    private GameObject player;
    public float boxW;
    public int lastDirection;//1で左、2で右、3で上、4で下
    public bool lastSplit;//trueで左右、falseで上下

    public bool thisGoal = false;

    void Start()
    {
        Init();
    }
    void Update()
    {
    }

    public void Open()
    {
        if (thisGoal) return;

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
                lastSplit = true;
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
                lastSplit = false;
            }
        }

        if (!isOpen) return;
        Vector3 pos1=transform.position+new Vector3(posX,0,posZ);
        Vector3 pos2=transform.position+new Vector3(-posX,0,-posZ);

        GameObject instance1;
        GameObject instance2;
        Block bs;

        //分裂オブジェクト1
        instance1=Instantiate(block,pos1,transform.rotation);
        if(lastSplit)instance1.GetComponent<Block>().setDirection(1);//左右だったら
        else instance1.GetComponent<Block>().setDirection(3);
        //////////////////
        //分裂オブジェクト2
        instance2 = Instantiate(block,pos2,transform.rotation);
        if (lastSplit)instance2.GetComponent<Block>().setDirection(2);//左右だったら
        else instance2.GetComponent<Block>().setDirection(4);
        ///////////////////

        Destroy(gameObject);

    }
    public void setDirection(int i)
    {
        lastDirection = i;
    }
    void Init()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Block"))
        {


            Debug.Log("ブロック同士が衝突しました");
            //1で左、2で右、3で上、4で下
            switch(col.GetComponent<Block>().lastDirection)
            {
                case 1:
                    // 左に移動
                    transform.position += new Vector3(0, 0, 1);
                    break;
                case 2:
                    // 右に移動
                    transform.position += new Vector3(0, 0, -1);
                    break;
                case 3:
                    // 上に移動
                    transform.position+= new Vector3(1, 0, 0);
                    break;
                case 4:
                    // 下に移動
                    transform.position += new Vector3(-1, 0, 0);
                    break;
                default:
                    Debug.Log("lastDirectionが定義されていません！");
                    break;
            }
        }
        if (col.gameObject.CompareTag("BlockDelete"))
        {
            Destroy(gameObject);
        }
    }
        
}
