using UnityEngine;


    public class DemoCircleExpositor : MonoBehaviour
    {
        [SerializeField] private float radius = 40f;
        [SerializeField] private float rotateSpeed = 10f;

        private float zOffset = 0f;
        public Transform[] items;
        private int count = 0;
        private int currentTarget = 0;
        private float offsetRotation, iniY;
        private Quaternion dummyRotation;

        void Start()
        {
            dummyRotation = transform.rotation;
            iniY = transform.position.y;
            foreach (Transform child in transform)
            {
                items[count] = child;
                count++;
            }

            offsetRotation = 360.0f / count;
            for (int i = 0; i < count; i++)
            {
                float angle = i * Mathf.PI * 2f / count;
                Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, iniY, -Mathf.Cos(angle) * radius);
                items[i].position = newPos;
            }

            zOffset = radius /*- 40f*/;
            transform.position = new Vector3(transform.position.x, transform.position.y, zOffset);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
            {
                ChangeTarget(-1);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.E))
            {
                ChangeTarget(1);
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, dummyRotation, rotateSpeed * Time.deltaTime);
        }

        public void ChangeTarget(int offset)
        {
            currentTarget += offset;
            if (currentTarget > items.Length - 1) currentTarget = 0;
            else if (currentTarget < 0) currentTarget = items.Length - 1;
            dummyRotation *= Quaternion.Euler(Vector3.forward * (offset * offsetRotation));
        }
    }
