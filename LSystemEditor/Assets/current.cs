using System;
using System.Collections;



// Class representing the current state of the L-system at a certain iteration. 

public class current
{
  public current(float angle, int iteration, string state)
  {
    this.Angle = angle;
    this.Iteration = iteration;
    this.State = state;
  }

  public current(int iteration, string state)
  {
    this.Iteration = iteration;
    this.State = state;
  }

  private float _Angle;
  public float Angle
  {
    set { this._Angle = value; }
    get { return this._Angle; }
  }

  private int _Iteration;
  public int Iteration
  {
    set { this._Iteration = value; }
    get { return this._Iteration; }
  }

  private string _State;
  public string State
  {
    set { this._State = value; }
    get { return this._State; }
  }


}
