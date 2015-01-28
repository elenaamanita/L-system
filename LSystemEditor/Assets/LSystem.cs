using UnityEngine; 
 using UnityEditor; 
 using System.Collections; 
 
 
  
// Quick and dirty wizard for allowing the user to enter L-System through Unity 
  

 public class LSystem : MonoBehaviour { 
 	 
 	static Camera cam; 
 	 
 	public string variables = ""; 
 	public string constants = ""; 
 	public string start = ""; 
	public string rules = ""; 
 	public int iteration = 0; 
 	public float angle = 0.0f; 
 	 
 	public bool guiOn = false; 
 	 
 	[MenuItem("GameObject/Create Other/L-System...")] 
 	static void CreateWizard () { 
 		cam = Camera.current; 
 		ScriptableWizard.DisplayWizard("Create L-System", typeof(LSystem)); 
 	} 
 	 
 	void OnWizardCreate() { 
 		GameObject lsys = new GameObject("L-System"); 
 		lsys.transform.position = new Vector3(0.0f, 0.0f, 0.0f); 
 		 
 		parse parse = (parse)lsys.AddComponent(typeof(parse)); 
 		main render = (main)lsys.AddComponent(typeof(main)); 
 		 
 		if(guiOn) { 
 			Gui gui = (Gui)lsys.AddComponent(typeof(Gui));	 
 		} 
 		 
 		parse.initialize(variables, constants, start, rules, iteration, angle); 
 		 
 	} 
 } 
