using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

public class DatasEnvironement : MonoBehaviour
{
    private Dictionary<int, string> dictionnaire;
    public string csvFile;
    //private TilesTypesDict
    public void Start()
    {
        //TilesTypesDict = TilesTypes.ToDictionary();
        
        LoadCSV();
    }

    public void LoadCSV()
    {
        string filePath = Path.Combine(Application.dataPath, csvFile);
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            string[] linesTile = File.ReadAllLines(filePath);
    //Debug.Log(linesTile);
            for (int y = 0; y < linesTile.Length; y++)
            {
                //Debug.Log(linesTile[y]);
                string[] valuesTile = linesTile[y].Split(',');

                SOItems item = ScriptableObject.CreateInstance<SOItems>();
                item.id = y;
                Debug.Log(valuesTile.Length);
                if (valuesTile.Length > 5) {
                    item.displayName = valuesTile[2];
                    item.description = valuesTile[3];
                    Debug.Log("Textures/icone_" + valuesTile[4].Split(".png")[0] + "_hover");
                    
                    item.itemTexture2DHover = Resources.Load<Texture2D>("Textures/icone_" + valuesTile[4].Split(".png")[0] + "_hover");

                    if (item.itemTexture2DHover != null) {
                        Debug.Log(item.itemTexture2DHover);
                    }

                    item.itemTexture2DLink = Resources.Load<Texture2D>("Textures/icone_" + valuesTile[4].Split(".png")[0] + "_link");

                    item.itemTexture2DSelect = Resources.Load<Texture2D>("Textures/icone_" + valuesTile[4].Split(".png")[0] + "_select");

                    switch(valuesTile[6].ToLower()) {
                        case "bon":
                            item.percent = 100;
                            break;
                        case "humour":
                            item.percent = 0;
                            break;
                        case "anachronique":
                            item.percent = 0;
                            break;
                        case "détritus":
                            item.percent = 0;
                            break;
                        default:
                            item.percent = 0;
                            break;
                    }

                    switch(valuesTile[5].ToLower()) {
                        case "tête":
                            item.typeVetement = TypeVetementEnum.Tete;
                            break;
                        case "haut":
                            item.typeVetement = TypeVetementEnum.Haut;
                            break;
                        case "cou":
                            item.typeVetement = TypeVetementEnum.Cou;
                            break;
                        case "bas / pieds":
                            item.typeVetement = TypeVetementEnum.BasPied;
                            break;
                        case "accessoire":
                            item.typeVetement = TypeVetementEnum.Accessoire;
                            break;
                        default:
                            item.typeVetement = TypeVetementEnum.Tete;
                            break;
                    }

                    AssetDatabase.CreateAsset(item, $"Assets/Items/{item.displayName}.asset");
                /* for (int x = 0; x < valuesTile.Length; x++)
                    {
                        Debug.Log("col:"+x+" line:"+y+", value = "+valuesTile[x]);
                        //exemple : dictionnaire.add(y, valuesTile[x]);
                    }*/
                }

                AssetDatabase.SaveAssets();
            }
                
        }
        else
        {
            Debug.LogError("CSV file not found");
        }
    }
    
}