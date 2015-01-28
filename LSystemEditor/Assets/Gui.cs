using UnityEngine; 
 using System.Collections; 
 
 
  
// What shows up inside the LSystemEditor, what sort of GUI features 
 
 public class Gui : MonoBehaviour 
 { 
 	public Rect windowRect;
  public string varsText= "";
  public string constsText= ""; 
 	public string startText = ""; 
 	public string ruleText = ""; 
 	public string iterText = ""; 
 	public string anglText = ""; 
 	 
 	private float guiAngle = 0.0f; 
 	private float cameraDistance = 0.5f; 
 	public float Vspeed = 24;
  public float Hspeed = 24;

  public string rule_num = "0";


  
    public string vars_Text1;
    public string start_Text1;
    public string rule_Text1;
    public string iter_Text1;
    public string angl_Text1;

    public string vars_Text2;
    public string start_Text2;
    public string rule_Text2;
    public string iter_Text2;
    public string angl_Text2;

    public string vars_Text3;
    public string start_Text3;
    public string rule_Text3;
    public string iter_Text3;
    public string angl_Text3;

    public string vars_Text4;
    public string start_Text4;
    public string rule_Text4;
    public string iter_Text4;
    public string angl_Text4;

    public string vars_Text5;
    public string start_Text5;
    public string rule_Text5;
    public string iter_Text5;
    public string angl_Text5;

    public string vars_Text6;
    public string start_Text6;
    public string rule_Text6;
    public string iter_Text6;
    public string angl_Text6;

    public string vars_Text7;
    public string start_Text7;
    public string rule_Text7;
    public string iter_Text7;
    public string angl_Text7;

    public string vars_Text8;
    public string start_Text8;
    public string rule_Text8;
    public string iter_Text8;
    public string angl_Text8; 
    

  
  //setting the rules
  void Start()
  {
    
    vars_Text1="F";
    start_Text1="F";
    rule_Text1="F->F[+F]F[-F]F";
    iter_Text1="5";
    angl_Text1="25.7";
    
    vars_Text2="F";
    start_Text2 = "F";
    rule_Text2 = "F->F[+F]F[-F][F]";
    iter_Text2 = "5";
    angl_Text2 = "20";

    vars_Text3="F";
    start_Text3 = "F";
    rule_Text3 = "F->FF-[-F+F+F]+[+F-F-F]";
    iter_Text3 = "4";
    angl_Text3 = "22.5";

    vars_Text4="X,F";
    start_Text4 = "X";
    rule_Text4 = "X->F[+X]F[-X]+X,F->FF";
    iter_Text4 = "7";
    angl_Text4 = "20";

    vars_Text5="X,F";
    start_Text5 = "X";
    rule_Text5 = "X->F[+X][-X]FX,F->FF";
    iter_Text5 = "7";
    angl_Text5 = "25.7";

    vars_Text6 = "X,F";
    start_Text6 = "X";
    rule_Text6 = "X->F-[[X]+X]+F[+FX]-X,F->FF";
    iter_Text6 = "5";
    angl_Text6 = "22.5";

    //Sierpinski triangle 
    vars_Text7 = "A,B";
    start_Text7 = "A";
    rule_Text7 = "A->B-A-B,B->A+B+A";
    iter_Text7 = "8";
    angl_Text7 = "60";

    //Hilbert Curve
    vars_Text8 = "F";
    start_Text8 = "F+F+F+F";
    rule_Text8 = "F->FF+F-F+F+FF";
    iter_Text8 = "4";
    angl_Text8 = "90";


    
  }
 	void OnGUI() { 
 		main painter = (main)this.GetComponent("main"); 
 		guiAngle = GUI.HorizontalSlider(new Rect(0,0,Screen.width,20),guiAngle,0.0F,360.0F); 
 		cameraDistance = GUI.VerticalSlider(new Rect(Screen.width-40,50,40,Screen.height -50), cameraDistance, 0.01f, 2.0f);

    //"Vertical" are raw input of the control
    //they are the members pre set in unity editor
    //it returnS from 0 to  1 depends how long you push the butoon(w,a,s,d)
    //Time.deltatTime is the time of renderer every frame cost 

    Camera.main.transform.position += new Vector3(0.0f, Input.GetAxis("Vertical") * Vspeed*Time.deltaTime, Input.GetAxis("Horizontal")*Hspeed*Time.deltaTime); 
 		painter.ChangeAngle = guiAngle; 
 		 
 		windowRect = GUI.Window(0, new Rect(0,30,320,320), GenerateNewSystem, ""); 
 	} 


 	 //create the functions and their position to the gui box for the output of the rules
 	void GenerateNewSystem(int windowID) { 

    GUI.Label(new Rect(10,4,64,32),"Variables :");
    varsText=GUI.TextField(new Rect(104,4,200,32),varsText);

   // GUI.Label(new Rect(10,50,64,32),"Constants:");
    //constsText=GUI.TextField(new Rect(104,50,200,32),constsText);

 		GUI.Label(new Rect(10,50,64,32), "Start :"); 
 		startText = GUI.TextField(new Rect(64,50,240,32), startText); 
 		 
 		GUI.Label(new Rect(10,90,64,32), "Rules :"); 
 		ruleText = GUI.TextField(new Rect(64,90,240,32), ruleText); 
 		 
 		GUI.Label(new Rect(10,130,64,32), "Iterations :"); 
 		iterText = GUI.TextField(new Rect(104,130,200,32), iterText); 
 		 
 		GUI.Label(new Rect(10,170,64,32), "Angle :"); 
 		anglText = GUI.TextField(new Rect(104,170,200,32), anglText);

    //insert the rule to show
   GUI.Label(new Rect(10, 210, 64, 32), "get rule :");
    rule_num=GUI.TextField(new Rect(104,210,200,32),rule_num);

    //generate the rule inserted 
    if(GUI.Button (new Rect(10,280,128,32), "Generate")) {

    //change from rule to rule through the gui window
    
      if(rule_num[0]-48 != 0 || rule_num != null)
      {
        switch(rule_num[0]-48)
        { 
        case 1:
        varsText= vars_Text1;        
        startText = start_Text1;
        ruleText = rule_Text1;
        anglText = angl_Text1;
        iterText = iter_Text1;
        break;

        case 2:
        varsText = vars_Text2;
        startText = start_Text2;
        ruleText = rule_Text2;
        anglText = angl_Text2;
        iterText = iter_Text2;
        break;

        case 3:
        varsText = vars_Text3;
        startText = start_Text3;
        ruleText = rule_Text3;
        anglText = angl_Text3;
        iterText = iter_Text3;
        break;

        case 4:
        varsText = vars_Text4;
        startText = start_Text4;
        ruleText = rule_Text4;
        anglText = angl_Text4;
        iterText = iter_Text4;
        break;

        case 5:
        varsText = vars_Text5;
        startText = start_Text5;
        ruleText = rule_Text5;
        anglText = angl_Text5;
        iterText = iter_Text5;
        break;

        case 6:
        varsText = vars_Text6;
        startText = start_Text6;
        ruleText = rule_Text6;
        anglText = angl_Text6;
        iterText = iter_Text6;
        break;

        case 7:
        varsText = vars_Text7;
        startText = start_Text7;
        ruleText = rule_Text7;
        anglText = angl_Text7;
        iterText = iter_Text7;
        break;

        case 8:
        varsText = vars_Text8;
        startText = start_Text8;
        ruleText = rule_Text8;
        anglText = angl_Text8;
        iterText = iter_Text8;
        break;
        default:
        varsText = vars_Text1;
        startText = start_Text1;
        ruleText = rule_Text1;
        anglText = angl_Text1;
        iterText = iter_Text1;
        break;
        }
      } 
 			main paint = (main)this.GetComponent("main"); 
 			paint.reset(); 
 			parse parse = (parse)this.GetComponent("parse"); 
 			parse.initialize(varsText,constsText,startText,ruleText,int.Parse(iterText),float.Parse(anglText)); 
 			parse.reset();	 
 		} 
 	} 
 } 
