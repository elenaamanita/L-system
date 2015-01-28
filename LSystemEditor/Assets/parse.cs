using UnityEngine; 
 using System; 
 using System.Collections; 
 using System.Collections.Generic; 
 using System.Text; 

 
 
  
//Parses through what rules and start state the user has entered and expands it. 
 
 public class parse : MonoBehaviour { 
 	 
 	public readonly char RULE_SPLITTER = ','; 
 	public readonly char RULE_ASSIGNER = '>'; 
 	 
 	public string variables = "";
  public string constants = ""; 
 	public string start = ""; 
 	public string rules = ""; 
 	public int iterations = 0; 
 	public float angle;
  public rules rule;
 	private List<rules> ruleList; 
 	private LinkedList<current> stateList; 
 	private current state; 
 	 
 	 
 	// Use this for initialization 
 	void Start () { 
  
 		ruleList = new List<rules>(); 
 		stateList = new LinkedList<current>(); 
 		 
 		/*Set the initial state of the rule system*/ 
 		state = new current(angle, 0, start); 
 		stateList.AddFirst(state); 
 		 
 		this.RuleAggregation(); 
 		this.IterateState(); 
 		  
 		 
 		main painter = (main)this.GetComponent("main"); 
 		painter.create(stateList); 
 	} 
 	 
 	public void reset() { 
 		ruleList = new List<rules>(); 
 		stateList = new LinkedList<current>(); 
 		 
 		/*Set the initial state of the rule system*/ 
 		state = new current(angle, 0, start); 
 		stateList.AddFirst(state); 
 		 
 		this.RuleAggregation(); 
 		this.IterateState(); 
 		  
 		 
 		main painter = (main)this.GetComponent("main"); 
 		painter.create(stateList); 
 		 
 	} 
 	 
 	//Splits the rules based on whatever rule splitter is defined as, then the multiple strings are initialized as the class rules. 
	public void RuleAggregation() { 
 		string[] splitRules = new string[20];
    splitRules=rules.Split(RULE_SPLITTER); 
 		 
 		foreach(string splitString in splitRules) { 
 			string[] splitAssign = new string[20];
      splitAssign = splitString.Split(RULE_ASSIGNER); 
 			for(int i = 0; i < splitAssign.Length-1; i+=2) { 
 				rule = new rules(splitAssign[i][0], splitAssign[i+1]); 
 				ruleList.Add(rule); 
 			} 
 		} 
 	} 
 	 
 	//Creates the L-System states using the list of known rules by expanding each character with the use of StringBuilder 
 	public void IterateState() { 
 		current currentState; 
 		rules currentRule; 
 		Predicate<rules> ruleFinder; 
 		StringBuilder sb = new StringBuilder(); 
 		 
 		for(int i = 1; i <= iterations; i++) { 
 			currentState = stateList.Last.Value; 
 			sb.Length = 0; 
 			foreach(char character in currentState.State) { 
 				ruleFinder = delegate(rules x){ return x.Index == character; }; 
 				currentRule = ruleList.Find(ruleFinder); 
 				if(currentRule != null) { 
 					sb.Append(currentRule.Rule); 
 				}else{ 
					sb.Append (character); 
 				} 
 			} 
 			currentState = new current(angle, i, sb.ToString()); 
 			stateList.AddLast(currentState); 
 		}
 	} 
 	 
 	 
 	//Initialization of this parser. 
 	public void initialize(string vars, string consts, string strt, 
 		string lrules, int iters, float angl) { 
 		this.iterations = iters; 
 		this.variables = vars; 
		this.constants = consts; 
 		this.start = strt; 
 		this.rules = lrules; 
 		this.angle = angl; 
    Debug.Log(start);
    Debug.Log(rules);
    Debug.Log(iterations);
 	} 
 } 
