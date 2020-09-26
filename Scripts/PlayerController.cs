using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myrigidbody;
    private Vector3 change;
    public GameObject projectilePrefab;
    public Sprite Lin, Viv, Peter, Aditya;
    public Sprite LinR, LinL, VivR, VivL, PeterR, PeterL, AdityaR, AdityaL, LinD, VivD, PeterD, AdityaD;
    public int character = 1; 
    private SpriteRenderer MainChar;
    private readonly string selectedChar = "SelectedCharacter";
    public VectorValue enterPos;
    float projectileRate = 0.5f;
    private float lastProjectile = 0.0f;

    public PlayerHealth playerHealth;
    public HealthBar healthbar;
    public SignalScript healthSignal;

    public PlayerInfoObjects playerInfo;

    public PlayerInventory _playerInventory;
    public InventoryItems healthitem;
    public InventoryItems sworditem;
    public InventoryItems moneyitem;
    public InventoryItems chickenitem;

    public GhostKilled gKilled;
    public NPCTracker npcs;

    public AchievementTracker ATracker;
    public MapTravelTracker MTT;

    //public GameObject tutorial;

    void Awake()
    {
        MainChar = this.GetComponent<SpriteRenderer>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.idle;
        int getChar;
        getChar = PlayerPrefs.GetInt(selectedChar);
        healthSignal.Raise();
        switch (getChar)
        {
            case 1:
                MainChar.sprite = Lin;
                character = 1;
                if (playerInfo.playerName == "" || playerInfo.playerName != "Lin")
                {
                    playerInfo.playerName = "Lin";
                    playerInfo.playerSprite = LinD;
                    playerInfo.maxHealth = 100;
                    playerInfo.damage = 10;
                    playerInfo.amountMoney = 1000;
                    playerHealth.playerHealth = 100;
                    SetUpNewGame();
                }
                break;
            case 2:
                MainChar.sprite = Viv;
                character = 2;
                if (playerInfo.playerName == "" || playerInfo.playerName != "Viv")
                {
                    playerInfo.playerName = "Viv";
                    playerInfo.playerSprite = VivD;
                    playerInfo.maxHealth = 100;
                    playerInfo.damage = 10;
                    playerInfo.amountMoney = 1000;
                    playerHealth.playerHealth = 100;
                    SetUpNewGame();
                }
                
                break;
            case 3:
                MainChar.sprite = Aditya;
                character = 3;
                if (playerInfo.playerName == "" || playerInfo.playerName != "Aditya")
                {
                    playerInfo.playerName = "Aditya";
                    playerInfo.playerSprite = AdityaD;
                    playerInfo.maxHealth = 100;
                    playerInfo.damage = 10;
                    playerInfo.amountMoney = 1000;
                    playerHealth.playerHealth = 100;
                    SetUpNewGame();
                }
                break;
            case 4:
                MainChar.sprite = Peter;
                character = 4;
                if (playerInfo.playerName == "" || playerInfo.playerName != "Peter")
                {
                    playerInfo.playerName = "Peter";
                    playerInfo.playerSprite = PeterD;
                    playerInfo.maxHealth = 100;
                    playerInfo.damage = 10;
                    playerInfo.amountMoney = 1000;
                    playerHealth.playerHealth = 100;
                    SetUpNewGame();
                }
                break;
            default:
                MainChar.sprite = Peter;
                character = 4;
                if (playerInfo.playerName == "" || playerInfo.playerName != "Peter")
                {
                    playerInfo.playerName = "Peter";
                    playerInfo.playerSprite = PeterD;
                    playerInfo.maxHealth = 100;
                    playerInfo.damage = 10;
                    playerInfo.amountMoney = 1000;
                    playerHealth.playerHealth = 100;
                    SetUpNewGame();
                }
                break;
        }
        myrigidbody = GetComponent<Rigidbody2D>();
        transform.position = enterPos.initialValue;
        healthbar.SetHealth();
        
        

    }

    void ResetAchievementTracker()
    {
        foreach(AchievementInfo achievement in ATracker._myAchievement)
        {
            if (achievement.isAchieved)
            {
                achievement.isAchieved = false;
                if (achievement.isCollected)
                {
                    achievement.isCollected = false;
                }
            }
        }
        MTT.Church = false;
        MTT.Desert = false;
        MTT.Island = false;
        MTT.Village = false;
        MTT.Lava = false;
        MTT.Underground = false;
        MTT.Undersea = false;

        npcs.Desert = false;
        npcs.Island = false;
        npcs.Village = false;
        npcs.Lava = false;
        npcs.Underground = false;

        ATracker._myAchievement.Clear();
    }

    void SetUpNewGame()
    {
        _playerInventory._myInventory.Clear();
        healthitem.numberHad = 0;
        sworditem.numberHad = 0;
        moneyitem.numberHad = 0;
        chickenitem.numberHad = 0;
        gKilled.ghostKilled = 0;
        if (ATracker._myAchievement.Count != 0)
        {
            ResetAchievementTracker();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState = PlayerState.walk;
        if (Input.GetKey(KeyCode.A))
        {
            if(character == 1)
            {
                MainChar.sprite = LinL;
            }
            if(character == 2)
            {
                MainChar.sprite = VivL; 
            }
            if(character == 3)
            {
                MainChar.sprite = AdityaL; 
            }
            if(character == 4)
            {
                MainChar.sprite = PeterL; 
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (character == 1)
            {
                MainChar.sprite = LinR;
            }
            if (character == 2)
            {
                MainChar.sprite = VivR;
            }
            if (character == 3)
            {
                MainChar.sprite = AdityaR;
            }
            if (character == 4)
            {
                MainChar.sprite = PeterR;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (character == 1)
            {
                MainChar.sprite = Lin;
            }
            if (character == 2)
            {
                MainChar.sprite = Viv;
            }
            if (character == 3)
            {
                MainChar.sprite = Aditya;
            }
            if (character == 4)
            {
                MainChar.sprite = Peter;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (character == 1)
            {
                MainChar.sprite = LinD;
            }
            if (character == 2)
            {
                MainChar.sprite = VivD;
            }
            if (character == 3)
            {
                MainChar.sprite = AdityaD;
            }
            if (character == 4)
            {
                MainChar.sprite = PeterD;
            }
        }
        

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            CharacterMovement();
        }

       
        if (Input.GetMouseButtonDown(0) && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {

            StartCoroutine(AttackCo());
            
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            TakeDamage(10);
            healthSignal.Raise();
            SoundManager.instance.LostHealth(); 
        }
            
       
    }

    void TakeDamage(int damage)
    {
        playerHealth.playerHealth -= damage;

        healthbar.SetHealth();

        if(playerHealth.playerHealth <= 0){
             Application.LoadLevel(Application.loadedLevel);
             playerHealth.playerHealth = 100;
        }
    }

    

    private IEnumerator AttackCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        PrepareArrow();
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void PrepareArrow()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 directionFromPlayerToMouse = mousePositionInWorld - transform.position;

        float radiansToMouse = Mathf.Atan2(directionFromPlayerToMouse.y, directionFromPlayerToMouse.x);
        float angleToMouse = radiansToMouse * 180f / Mathf.PI;
        if (Time.time > projectileRate + lastProjectile)
        {
            Arrow arrow = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(new Vector3(0, 0, angleToMouse));
            lastProjectile = Time.time;
        }
    }


    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myrigidbody != null )
        {
            yield return new WaitForSeconds(knockTime);
            myrigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    void CharacterMovement()
    {
        myrigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }




}
