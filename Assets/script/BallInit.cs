using UnityEngine;
using System.Collections;
 
public class BallInit : MonoBehaviour {
 
	//黑色直角线段
	LineRenderer lineRenderer0;
	LineRenderer lineRenderer1;
	//贝塞尔曲线
	LineRenderer BezierRenderer;
 
	//三个小球触摸对象
	public GameObject mark0;
	public GameObject mark1;
	public GameObject mark2;
 
	//算法公式类
	private Bezier myBezier;
 
	void Start ()
	{
		//分别得到黑色直角线段 与黄色贝塞尔曲线的 线段组件
		lineRenderer0 = GameObject.Find("line0").GetComponent<LineRenderer>();
		lineRenderer1 = GameObject.Find("line1").GetComponent<LineRenderer>();
		BezierRenderer = GameObject.Find("Bezier").GetComponent<LineRenderer>();
		//黑色直角是有两个线段组成
		lineRenderer0.SetVertexCount(2);
		lineRenderer1.SetVertexCount(2);
		//为了让贝塞尔曲线细致一些 设置它有100个点组成
		BezierRenderer.SetVertexCount(100);
 
	}
 
	void Update ()
	{
 
		//mark0 表示中间的小球
		//mark1 表示右边的小球
		//mark2 表示左边的小球
 
		//中间的标志点分别减去左右两边的标志点，计算出曲线的X Y 的点
		float y = (mark0.transform.position.y  - mark2.transform.position.y)  ;
		float x = (mark0.transform.position.x  - mark2.transform.position.x) ; 
 
		//因为我们是通过3个点来确定贝塞尔曲线， 所以参数3 设置为0 即可。
		//这样参数1 表示起点 参数2表示中间点 参数3 忽略 参数4 表示结束点
		myBezier = new Bezier( mark2.transform.position,  new Vector3(x,y,0f),  new Vector3(0f,0f,0f), mark1.transform.position );
 
		//绘制贝塞尔曲线
		for(int i =1; i <= 100; i++)
		{
			Vector3 vec = myBezier.GetPointAtTime( (float)(i * 0.01) );
			BezierRenderer.SetPosition(i -1,vec);
		}
 
		//绘制直角黑色标志线段
		lineRenderer0.SetPosition(0,mark0.transform.position);
		lineRenderer0.SetPosition(1,mark2.transform.position);
		lineRenderer1.SetPosition(0,mark0.transform.position);
		lineRenderer1.SetPosition(1,mark1.transform.position);
	}
}