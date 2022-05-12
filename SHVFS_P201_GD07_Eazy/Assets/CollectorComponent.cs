using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace HacMan_GD07
{
    public class CollectorComponent : MonoBehaviour
    {
        public int PillsGotten = 0;
        public int PlayerHealth = 100;
        public bool IsInvincible = false;
        public bool IsHealed = false;
        public float Timer;
        public Pill Pill;
        private LevelGeneratorSystem Generator;
        public GameObject Projectile;
        private Renderer HacmanRenderer;
        // Start is called before the first frame update
        void Start()
        {
            Generator = FindObjectOfType<LevelGeneratorSystem>();
            HacmanRenderer = GetComponent<Renderer>();
            
        }

        // Update is called once per frame
        void Update()
        {
            CheckPills();
            Debug.Log("playerHealth= " + PlayerHealth);
            TurnOffInvincibility();
            Heal();
            ChangeColor();
           
        }
        private void OnTriggerEnter(Collider col)
        {
            if(col.GetComponent<CollectableComponent>()!=null)
            {
                Evently.Instance.Publish(new CollectionEvent(col.GetComponent<CollectableComponent>()));
                PillsGotten++;                             
            }
            if (col.GetComponent<InvincibilityPill>() != null)
            {
                Evently.Instance.Publish(new InvincibilityEvent(col.GetComponent<InvincibilityPill>()));
                IsInvincible = true;
            }
            if(col.GetComponent<HealingComponent>()!=null&&PlayerHealth<100)
            {
                Evently.Instance.Publish(new HealingEvent(col.GetComponent<HealingComponent>()));
                IsHealed = true;
            }
            if (col.GetComponent<EnemyInputComponent>()!=null)
            {
                Debug.Log("Take Damage!");
                if(!IsInvincible)
                { Evently.Instance.Publish(new DamageEvent(col.GetComponent<CollectorComponent>())); }
                if(PillsGotten%5==0)
                {
                    Evently.Instance.Publish(new AttackEvent(col.GetComponent<EnemyInputComponent>()));                  
                    Debug.Log("I can attack now!");                   
                }
                                            
            }
        }
        void CheckPills()
        {
            Pill = FindObjectOfType<Pill>();
            if(Pill==null)
            {
                Debug.Log("Victory!");
                SceneManager.LoadScene("SampleScene");
            }
            
        }
        void TurnOffInvincibility()
        {
            if(IsInvincible)
            {
                Timer += Time.deltaTime;
                if(Timer>6)
                {
                    Timer = 0;
                    IsInvincible = false;
                    Debug.Log("Invincibility Turned off!");
                }                
            }
        }
        void Heal()
        {           
            if(IsHealed)
            {
                PlayerHealth += 30;
                IsHealed = false;
                if(PlayerHealth>=100)
                {
                    PlayerHealth = 100;
                }
            }
        }
        void CheckAttackMoment()
        {
            HacmanRenderer.material.SetColor("_Color", Color.yellow);
        }
        void ChangeColor()
        {
            if (PillsGotten % 5 == 0 && PillsGotten != 0)
            {
                CheckAttackMoment();
            }
            if(PillsGotten%5>0&&PillsGotten!=0)
            {
                HacmanRenderer.material.SetColor("_Color", Color.white);
            }
        }
    }
}
