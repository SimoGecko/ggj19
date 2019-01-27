// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

////////// DESCRIPTION //////////

public class VehicleMovement : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    public float speed = 3f;
    public float distToNext = .1f;
    public float distToKeep = .3f;


    // private
    List<Vector3> wp; // waypoints
    int currentIdx;
    Vector3 target;
    bool stopped;


    // references
    //public Transform[] samplePoints;
    LineRenderer lr;
    Taxi taxi;
	
	// --------------------- BASE METHODS ------------------
	void Start () {
        lr = GetComponent<LineRenderer>();
        
        lr.positionCount = 0;
        stopped = true;

        //GetPath(samplePoints.Select(x => x.position).ToList());
        target = transform.position;
        transform.forward = Vector3.right;
        taxi = GetComponentInChildren<Taxi>();
    }

    void Update () {
        Move();
        UpdateLineRenderer();
	}

    // --------------------- CUSTOM METHODS ----------------


    // commands
    public void GetPath(List<Vector3> path) {
        wp = path;
        currentIdx = 0;
        stopped = false;
    }

    private void Move() {

        Vector3 dir;

        if (!(wp == null || currentIdx < 0 || currentIdx >= wp.Count) && !stopped) {
            if (Vector3.Distance(target, wp[currentIdx]) < distToNext) {
                //change point
                if (currentIdx < wp.Count - 1) {
                    //increase
                    currentIdx++;
                } else {
                    //stop
                    stopped = true;
                }
            }
            dir = (wp[currentIdx] - target).normalized;
        } else {
            dir = (target-transform.position).normalized;
            if (dir.magnitude == 0) dir = transform.forward;
            Debug.Log("auto)");

        }

        //if (Vector3.Distance(transform.position, target) < .1f) target = transform.position + transform.forward*(distToKeep+1);

        if (!taxi.Crashed) {
            target += dir * speed * Time.deltaTime;

            transform.LookAt(target);
            if (Vector3.Distance(transform.position, target) >= distToKeep) {
                transform.position = target - (target - transform.position).normalized * distToKeep;
            }
        }
    }


    void UpdateLineRenderer() {
        if (stopped) {
            lr.positionCount = 0;
        } else {
            lr.positionCount = wp.Count - currentIdx + 1;

            lr.SetPosition(0, transform.position);
            for (int i = currentIdx; i < wp.Count; i++) {
                lr.SetPosition(1 + i - currentIdx, wp[i]);
            }
        }
    }


    // queries



    // other
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(target, 1f);
    }

}