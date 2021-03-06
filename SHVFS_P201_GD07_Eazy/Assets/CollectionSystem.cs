using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace HacMan_GD07
{
    public class CollectionSystem : Singleton<CollectionSystem>
    {
        public GameObject WinPanel;
        public GameObject LossPanel;
        // Start is called before the first frame update
        void Start()
        {
            WinPanel.gameObject.SetActive(false);
            LossPanel.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
           
        }
        public void OnEnable()
        {
            Evently.Instance.Subscribe<CollectionEvent>(OnCollected);
            Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
            Evently.Instance.Subscribe<InvincibilityEvent>(OnInvincibility);
            Evently.Instance.Subscribe<HealingEvent>(OnHealing);
            Evently.Instance.Subscribe<AttackEvent>(OnAttacking);
            
        }
        public void OnDisable()
        {
            Evently.Instance.UnSubscribe<CollectionEvent>(OnCollected);
            Evently.Instance.UnSubscribe<DamageEvent>(OnDamaged);
            Evently.Instance.UnSubscribe<InvincibilityEvent>(OnInvincibility);
            Evently.Instance.UnSubscribe<HealingEvent>(OnHealing);
            Evently.Instance.UnSubscribe<AttackEvent>(OnAttacking);

        }
        private void OnCollected(CollectionEvent evt)
        {
            Destroy(evt.Collectable.gameObject);
        }
        private void OnDamaged(DamageEvent dmg)
        {          
            dmg.Collector.PlayerHealth -= 20;
            if(dmg.Collector.PlayerHealth<=0)
            {
                dmg.Collector.PlayerHealth = 0;
                LossPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                            
            }
        }
        private void OnInvincibility(InvincibilityEvent invincibility)
        {
            Destroy(invincibility.InvincibilityPill.gameObject);
        }
        private void OnHealing(HealingEvent HealingPill)
        {
            Destroy(HealingPill.HealingPill.gameObject);
        }
        private void OnAttacking(AttackEvent Enemy)
        {
            Destroy(Enemy.Enemy.gameObject);
        }
        
    }
}
