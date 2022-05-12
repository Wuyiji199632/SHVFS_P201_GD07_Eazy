using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQExamples : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        var names = new[] { "Gary", "Chloe", "Rebecca", "Eazy", "Ben", "Kevin", "Giselle" };
        var namesWithQuerry = from name in names
                              where name.Contains('c')
                              select name;
        var namesWithMethod = names.Where(name => name.Contains('C'));
       
    }
}
