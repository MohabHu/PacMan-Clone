using UnityEngine;
using Pathfinding;


public class GhostAi : MonoBehaviour {

    [SerializeField]
    int aICases = 0;

    public static bool IsRetreating{get; private set;}

    public static bool carefulRetreat{get; set;}
    
    AIDestinationSetter destinationSetter;

    AIPath aIPath;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform point;

    [SerializeField]
    Transform[] points;


    [SerializeField]
    float chaseMaxTime, retreatMaxTime;

    float chaseTime, retreatTime;

    

    private void Awake() {
        destinationSetter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
        retreatTime = retreatMaxTime;
        chaseTime = chaseMaxTime;
        IsRetreating = false;
        carefulRetreat = false;
        if(points.Length == 0){
            points[0].position = Vector3.zero;
        }
    }

    
    private void Update() {
        SwitchCases();
        
    }
    

    void SwitchCases(){
        switch(aICases){
            case 3:
                ChaseShy();
                break;
            case 2:
                if(retreatTime <= 1){
                    if(retreatTime <= 0){
                        retreatTime = retreatMaxTime;
                        carefulRetreat = false;
                        FinishRetreating();
                        aICases = 1;
                    }
                    else{
                        carefulRetreat = true;
                        retreatTime -= Time.deltaTime;
                    }
                }
                else{
                    
                    Retreat();
                    retreatTime -= Time.deltaTime;
                }

                
                
                break;

            case 1:
                if(chaseTime <= 0){
                    chaseTime = chaseMaxTime;
                    aICases = 0;
                }
                else{
                    chaseTime -= Time.deltaTime;
                    Chase();
                }
                break;

            case 0:
                Patrol();
                
                break;
        }
    }

    void Patrol(){
        if(destinationSetter.target == player){
            destinationSetter.target = point;
        }
        else if(aIPath.reachedDestination && destinationSetter.target == point){
            aICases = 1;
        }
    }
    
    void Chase(){
        destinationSetter.target = player;
    }
    void Retreat(){
        destinationSetter.target = point;
        IsRetreating = true;
    }

    void FinishRetreating(){
        IsRetreating = false;
    }

    public void StartRetreating(){
        aICases = 2;
    }

    int i;
    public void ClydeChase(){
        aICases = 3;
        i = Random.Range(0, points.Length - 1);
    }
    
    void ChaseShy(){
        destinationSetter.target = points[i];
        if(aIPath.reachedDestination){
            aICases = 1;
        }
    }

    

}
