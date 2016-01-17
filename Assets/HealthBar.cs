using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public GUIStyle healthStyle;
    public GUIStyle backStyle;
    Combat combat;
    
    void Awake() {
        combat = (Combat)GetComponent<Combat>();
    }
    void OnGUI() {
        InitStyles();

        //draw health bar
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        //draw health bar background
        GUI.color = Color.grey;
        GUI.backgroundColor = Color.grey;
        GUI.Box(new Rect(pos.x - 25, Screen.height - pos.y + 20, Combat.MaxHealth/2, 7), ".", backStyle);

        //draw health bar
        GUI.color = Color.green;
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(pos.x - 25, Screen.height - pos.y + 21, combat.health/2, 5), ".", healthStyle);
    }
    void InitStyles() {
        if (healthStyle == null) {
            healthStyle = new GUIStyle(GUI.skin.box);
            healthStyle.normal.background = MakeTex(2,2,new Color(0f,0f,0f,1.0f));
        }

        if (backStyle == null)
        {
            backStyle = new GUIStyle(GUI.skin.box);
            backStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 1.0f));
        }
    }

    Texture2D MakeTex(int width, int height, Color col) {
        Color[] pix = new Color[width * height];
        for (int x = 0; x < pix.Length; ++x )
        {
            pix[x] = col;
        }

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
