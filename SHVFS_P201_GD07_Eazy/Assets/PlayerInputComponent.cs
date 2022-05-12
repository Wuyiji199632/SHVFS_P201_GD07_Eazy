using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace HacMan_GD07
{
    public class PlayerInputComponent : MovementComponent
    {
        // Start is called before the first frame update

        public int NumOfPills;
        // Update is called once per frame
        protected override void Update()
        {
           if(Input.GetKeyDown(KeyCode.S))
           {
                currentInputDirection = IntVector2.down;
           }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentInputDirection = IntVector2.up;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentInputDirection = IntVector2.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentInputDirection = IntVector2.right;
            }
            base.Update();
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if(other.GetComponent<EnemyInputComponent>()!=null)
        //    {
        //        Destroy(this.gameObject);
        //        //SceneManager.LoadScene("LosingScene");
        //        Debug.Log("You Lose!");

        //    }
        //    if(other.GetComponent<Pill>()!=null)
        //    {
        //        Destroy(other.gameObject);
        //        if(FindObjectsOfType<Pill>().Length<=1)
        //        {
        //            Debug.Log("You Win!");
        //            //SceneManager.LoadScene("GameScene");
        //        }
        //    }
        //}

    }
    
}

