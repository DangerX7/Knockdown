using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;
    void Update()
    {
     //   if(Input.GetKeyDown(KeyCode.Space))
        {
     //       SaveManager.Save(so);
        }
      //  if (Input.GetKeyDown(KeyCode.Return))
        {
     //       so = SaveManager.Load();
        }
    }

    public void Save()
    {
        SaveManager.Save(so);
    }

    public void Load()
    {
        so = SaveManager.Load();
    }

}
