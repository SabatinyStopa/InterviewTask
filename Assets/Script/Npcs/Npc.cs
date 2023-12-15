using UnityEngine;

namespace InterviewTask.Npcs
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] private Transform[] movingPath;
        [SerializeField] private float speed = 5f;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private int counter = 0;

        private void Update()
        {
            if (Vector2.Distance(transform.position, movingPath[counter].position) <= 0.1f) counter++;

            if (counter >= movingPath.Length) counter = 0;

            spriteRenderer.flipX = counter == 0; 

            transform.position = Vector3.MoveTowards(transform.position, movingPath[counter].position, Time.deltaTime * speed);
        }
    }
}