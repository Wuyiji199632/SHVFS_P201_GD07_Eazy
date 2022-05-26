using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

namespace HacMan_GD07
{
    public class LevelGeneratorSystem : Singleton<LevelGeneratorSystem>
    {
        public CollectionSystem CollectionSystem;
        public BaseGridObject[] BaseGridObjectPrefabs;
        public bool Level1IsRunning = false;
        public bool Leve2IsRunning = false;
        public bool Level3IsRunning = false;
        public bool Level4IsRunning = false;
        public bool Level5IsRunning = false;
        public bool Level6IsRunning = false;
        public bool Level7IsRunning = false;
        public bool Level8IsRunning = false;
        public bool Level9IsRunning = false;
        public bool Level10IsRunning = false;
        public static int[,] Grid0 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 0, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 3, 1},
            {1, 0, 0, 0, 5, 1, 4, 1, 3, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 3, 1},
            {1, 0, 0, 0, 0, 1, 4, 1, 3, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 5, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid2 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 3, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 5, 1, 0, 3, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid3 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 3, 1},
            {1, 0, 4, 0, 0, 1, 4, 1, 3, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 3, 1},
            {1, 0, 0, 1, 0, 0, 0, 5, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid4 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 0, 5, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid5 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 0, 0, 3, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 0, 0, 5, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
       public static int[,] Grid6 = new int[,]
       {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 5, 1},
            {1, 0, 0, 1, 3, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
       };
        public static int[,] Grid7 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 0, 0, 5, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 3, 0, 0, 0, 3, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid8 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 3, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 4, 0, 0, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 5, 0, 1, 3, 0, 0, 0, 3, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };
        public static int[,] Grid9 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 3, 0, 3, 1},
            {1, 0, 1, 1, 4, 0, 0, 1, 0, 1},
            {1, 4, 0, 0, 0, 1, 4, 1, 5, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 1, 3, 0, 0, 0, 3, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };


        protected override void Awake()
        {
            LoadLevel();
            CollectionSystem = FindObjectOfType<CollectionSystem>();

            //GenerateLevel();
        }
        // Start is called before the first frame update



        // Update is called once per frame
        void Update()
        {
           
        }
        public void GenerateLevel(LevelGrid levelgrid)
        {
            var gridSizeY = levelgrid.Grid.GetLength(0);
            var gridSizeX =levelgrid. Grid.GetLength(1);
            for (var y = 0; y < gridSizeY; y++)
            {
                for (var x = 0; x < gridSizeX; x++)
                {
                    var objectType =levelgrid.Grid[y, x];
                    var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                    var gridObjectClone = Instantiate(gridObjectPrefab);
                    gridObjectClone.GridPosition = new IntVector2(x, -y);
                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0);
                }
            }                      
        }
        public void TurnOffPanels()
        {
            CollectionSystem.WinPanel.gameObject.SetActive(false);
            CollectionSystem.LossPanel.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene");
            
        }
        public void LoadLevel()
        {
            var i = Random.Range(0, 9);
            Time.timeScale = 1;           
            if (i == 0)
            {
                AppDataSystem.Save(new LevelGrid(Grid0), "Level0");
                var level0 = AppDataSystem.Load<LevelGrid>("Level0");
                Level1IsRunning = true;
                GenerateLevel(level0);
            }
            if (i == 1)
            {
                AppDataSystem.Save(new LevelGrid(Grid1), "Level1");
                var level1 = AppDataSystem.Load<LevelGrid>("Level1");
                Leve2IsRunning = true;
                GenerateLevel(level1);
            }
            if (i == 2)
            {
                AppDataSystem.Save(new LevelGrid(Grid2), "Level2");
                var level2 = AppDataSystem.Load<LevelGrid>("Level2");
                Level3IsRunning = true;
                GenerateLevel(level2);
            }
            if (i == 3)
            {
                AppDataSystem.Save(new LevelGrid(Grid3), "Level3");
                var level3 = AppDataSystem.Load<LevelGrid>("Level3");
                Level4IsRunning = true;
                GenerateLevel(level3);
            }
            if (i == 4)
            {
                AppDataSystem.Save(new LevelGrid(Grid4), "Level4");
                var level4 = AppDataSystem.Load<LevelGrid>("Level4");
                Level5IsRunning = true;
                GenerateLevel(level4);
            }
            if (i == 5)
            {
                AppDataSystem.Save(new LevelGrid(Grid5), "Level5");
                var level5 = AppDataSystem.Load<LevelGrid>("Level5");
                Level6IsRunning = true;
                GenerateLevel(level5);
            }
            if (i == 6)
            {
                AppDataSystem.Save(new LevelGrid(Grid6), "Level6");
                var level6 = AppDataSystem.Load<LevelGrid>("Level6");
                Level7IsRunning = true;
                GenerateLevel(level6);
            }
            if (i == 7)
            {
                AppDataSystem.Save(new LevelGrid(Grid7), "Level7");
                var level7 = AppDataSystem.Load<LevelGrid>("Level7");
                Level8IsRunning = true;
                GenerateLevel(level7);
            }
            if (i == 8)
            {
                AppDataSystem.Save(new LevelGrid(Grid8), "Level8");
                var level8 = AppDataSystem.Load<LevelGrid>("Level8");
                Level9IsRunning = true;
                GenerateLevel(level8);
            }
            if (i == 9)
            {
                AppDataSystem.Save(new LevelGrid(Grid9), "Level9");
                var level9 = AppDataSystem.Load<LevelGrid>("Level4");
                Level10IsRunning = true;
                GenerateLevel(level9);
            }
        }
        [ContextMenu("Log Grid")]
        public void LogGrid()
        {
            var obj = JsonConvert.SerializeObject(Grid0);
            Debug.Log(obj);
        }
        [ContextMenu("Save Level")]
        public void SaveLevel()
        {
            var obj = JsonConvert.SerializeObject(Grid0);
            var fulfillPath = $"{Application.dataPath}/Assets/Levels/Level_1.json";
            Debug.Log(obj);
            if (!File.Exists(fulfillPath))
            {
                var fileStream = File.Create(fulfillPath);
                fileStream.Close();
                Debug.Log($"Saved level: {obj}");
            }
            File.WriteAllText(fulfillPath, obj);
        }
        //[ContextMenu("Log System")]
        ////public void LogEnemies()
        ////{
        ////    var enemies=new List<ExampleEnemies>()
        ////    {
        ////        new 
        ////    }
        ////}
    }  
}

