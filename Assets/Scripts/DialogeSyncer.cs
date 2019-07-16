
using UnityEngine;

public class DialogeSyncer : MonoBehaviour
{
    public Animator anim;
    public string[] triggerName;

    
   public void PlayeAnim(int trigger)
    {
        anim.SetTrigger(triggerName[trigger]);
    }
}
