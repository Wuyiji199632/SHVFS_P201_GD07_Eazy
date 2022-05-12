using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HacMan_GD07
{
    public class CollectionEvent 
    {
        public CollectableComponent Collectable;
        // Start is called before the first frame update
        public CollectionEvent(CollectableComponent collectable)
        {
            Collectable = collectable;
        }        
    }
    public class DamageEvent : MonoBehaviour
    {
        // Start is called before the first frame update

        public CollectorComponent Collector;
        public DamageEvent(CollectorComponent collector)
        {
            Collector = FindObjectOfType<CollectorComponent>();
            collector = Collector;

        }

    }
    public class InvincibilityEvent
    {
        public InvincibilityPill InvincibilityPill;
        public InvincibilityEvent(InvincibilityPill Pill)
        {
            InvincibilityPill = Pill;
        }
    }
    public class HealingEvent
    {
        public HealingComponent HealingPill;
        public HealingEvent(HealingComponent healingPill)
        {
            HealingPill = healingPill;
        }

    }
    public class AttackEvent
    {
        public EnemyInputComponent Enemy;
        public AttackEvent(EnemyInputComponent enemy)
        {
            Enemy = enemy;
        }
    }

    



}
