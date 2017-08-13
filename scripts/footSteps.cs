using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClimberFX.Utility
{
    public class footSteps : MonoBehaviour
    {

        CharacterController cc;
        public AudioSource walk_default;
        public AudioSource run_default;
        public AudioSource walk_grass;
        public AudioSource run_grass;
        public AudioSource walk_wood;
        public AudioSource run_wood;
        public AudioSource walk_forest;
        public AudioSource run_forest;
        public AudioSource jump_start;
        public AudioSource jump_end;
        bool pulou = false;

        // Use this for initialization
        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (cc.isGrounded)
            {
                if (pulou)
                {
                    jump_end.Play();
                    pulou = false;
                }
            }
            else
            {
                walk_default.Stop();
                run_default.Stop();
                walk_grass.Stop();
                run_grass.Stop();
                walk_wood.Stop();
                run_wood.Stop();
                walk_forest.Stop();
                run_forest.Stop();
                if (!jump_start.isPlaying && (!pulou))
                {
                    jump_start.Play();
                    pulou = true;
                }
            }

            //Controle de velocidade e volume, respeitanto a velocidade de movimentação
            walk_default.pitch = Random.Range(1.1f, 1.4f) * cc.velocity.magnitude / 2;
            walk_default.volume = Random.Range(0.5f, 0.7f) * cc.velocity.magnitude / 2;

            run_default.pitch = Random.Range(0.9f, 1.1f) * cc.velocity.magnitude / 4;
            run_default.volume = Random.Range(0.7f, 0.9f) * cc.velocity.magnitude / 4;

            walk_wood.pitch = Random.Range(0.6f, 0.85f) * cc.velocity.magnitude / 1.8f;
            walk_wood.volume = Random.Range(0.5f, 0.7f) * cc.velocity.magnitude / 1.8f;

            run_wood.pitch = Random.Range(1.0f, 1.4f) * cc.velocity.magnitude / 4;
            run_wood.volume = Random.Range(0.9f, 1.2f) * cc.velocity.magnitude / 4;

            walk_forest.pitch = Random.Range(0.8f, 1.1f) * cc.velocity.magnitude / 2;
            walk_forest.volume = Random.Range(1.2f, 1.5f) * cc.velocity.magnitude / 2;

            run_forest.pitch = Random.Range(0.9f, 1.1f) * cc.velocity.magnitude / 4;
            run_forest.volume = Random.Range(1.2f, 1.5f) * cc.velocity.magnitude / 4;

            walk_grass.pitch = Random.Range(1.0f, 1.3f) * cc.velocity.magnitude / 2;
            walk_grass.volume = Random.Range(1.7f, 2.2f) * cc.velocity.magnitude / 2;

            run_grass.pitch = Random.Range(0.8f, 1.0f) * cc.velocity.magnitude / 4;
            run_grass.volume = Random.Range(1.5f, 2f) * cc.velocity.magnitude / 4;



        }

        //Executa quando em contato com superfícies
        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (cc.isGrounded)
            {
                if (hit.gameObject.tag == "grass")
                {
                    if (cc.velocity.magnitude > 0.2f && cc.velocity.magnitude < 3f && !walk_grass.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        //walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        walk_grass.Play();
                    }
                    else if (cc.velocity.magnitude > 3f && !run_grass.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        //run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        run_grass.Play();
                    }
                    //else if (cc.velocity.magnitude < 0.2f)
                    //{
                    //    walk_grass.Stop();
                    //    run_grass.Stop();
                    //}
                }
                else if (hit.gameObject.tag == "wood")
                {
                    if (cc.velocity.magnitude > 0.2f && cc.velocity.magnitude < 3f && !walk_wood.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        //walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        walk_wood.Play();
                    }
                    else if (cc.velocity.magnitude > 3f && !run_wood.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        //run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        run_wood.Play();
                    }
                    //else if (cc.velocity.magnitude < 0.2f)
                    //{
                    //    walk_wood.Stop();
                    //    run_wood.Stop();
                    //}
                }
                else if (hit.gameObject.tag == "forest")
                {
                    if (cc.velocity.magnitude > 0.2f && cc.velocity.magnitude < 3f && !walk_forest.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        //walk_forest.Stop();
                        run_forest.Stop();
                        walk_forest.Play();
                    }
                    else if (cc.velocity.magnitude > 3f && !run_forest.isPlaying)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        //run_forest.Stop();
                        run_forest.Play();
                    }
                    //else if (cc.velocity.magnitude < 0.2f)
                    //{
                    //    walk_forest.Stop();
                    //    run_forest.Stop();
                    //}
                }
                else //if (hit.gameObject.tag == "default")
                {
                    if (cc.velocity.magnitude > 0.2f && cc.velocity.magnitude < 3f && !walk_default.isPlaying)
                    {
                        //walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        walk_default.Play();
                    }
                    else if (cc.velocity.magnitude > 3f && !run_default.isPlaying)
                    {
                        walk_default.Stop();
                        //run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                        run_default.Play();
                    }
                    else if (cc.velocity.magnitude < 0.2f)
                    {
                        walk_default.Stop();
                        run_default.Stop();
                        walk_grass.Stop();
                        run_grass.Stop();
                        walk_wood.Stop();
                        run_wood.Stop();
                        walk_forest.Stop();
                        run_forest.Stop();
                    }
                }
            }
        }
    }
}