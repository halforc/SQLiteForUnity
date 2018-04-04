using UnityEngine;
using System.Collections;


public class LineTest : MonoBehaviour {

	private LineRenderer linerender;
	//定义一个Vector3,用来存储鼠标点击的位置  
	private Vector3 position;
	//用来索引端点  
	private int index = 0;
	//端点数  
	private int LengthOfLineRenderer = 0;
	// Use this for initialization
	void Start () {
		linerender = gameObject.GetComponent<LineRenderer>();
		//linerender.material = new Material(Shader.Find("Particles/Additive"));
		//linerender.SetColors(Color.red, Color.red);
		linerender.SetWidth(0.002f, 0.002f);
	}
	
	// Update is called once per frame
	void Update () {
		//鼠标左击  
		if(Input.GetMouseButtonDown(0)) {
			//将鼠标点击的屏幕坐标转换为世界坐标，然后存储到position中  
			position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
			//端点数+1  
			LengthOfLineRenderer++;
			//设置线段的端点数  
			linerender.SetVertexCount(LengthOfLineRenderer);

		}
		//连续绘制线段  
		while(index < LengthOfLineRenderer) {
			//两点确定一条直线，所以我们依次绘制点就可以形成线段了  
			linerender.SetPosition(index, position);
			index++;
		}   
	}

	void OnGUI() {
		GUILayout.Label("当前鼠标X轴位置：" + Input.mousePosition.x);
		GUILayout.Label("当前鼠标Y轴位置：" + Input.mousePosition.y);
	} 
}
