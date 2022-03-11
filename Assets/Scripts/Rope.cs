using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Rope : MonoBehaviour
{

    public ObiSolver solver;
    public ObiCollider character;

    public Material material;
    public ObiRopeSection section;

    [Range(0, 1)]
    public float hookResolution = 0.5f;
    public float hookExtendRetractSpeed = 2;
    public float hookShootSpeed = 30;
    public int particlePoolSize = 100;

    public GameController gameController;

    private ObiRope rope;
    private ObiRopeBlueprint blueprint;
    private ObiRopeExtrudedRenderer ropeRenderer;

    private ObiRopeCursor cursor;

    private RaycastHit hookAttachment;

    private AudioSource ropeThrow;

    void Awake()
    {
        rope = gameObject.AddComponent<ObiRope>();
        ropeRenderer = gameObject.AddComponent<ObiRopeExtrudedRenderer>();
        ropeRenderer.section = section;
        ropeRenderer.uvScale = new Vector2(1, 4);
        ropeRenderer.normalizeV = false;
        ropeRenderer.uvAnchor = 1;
        rope.GetComponent<MeshRenderer>().material = material;

        blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>();
        blueprint.resolution = 0.5f;
        blueprint.pooledParticles = particlePoolSize;

        rope.maxBending = 0.02f;

        cursor = rope.gameObject.AddComponent<ObiRopeCursor>();
        cursor.cursorMu = 0;
        cursor.direction = true;

        ropeThrow = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        DestroyImmediate(blueprint);
    }

    private void LaunchHook()
    {

        Vector3 mouse = Input.mousePosition;
        mouse.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 mouseInScene = Camera.main.ScreenToWorldPoint(mouse);

        Ray ray = new Ray(transform.position, mouseInScene - transform.position);


        if (Physics.Raycast(ray, out hookAttachment))
        {
            StartCoroutine(AttachHook());
        }

    }

    private IEnumerator AttachHook()
    {
        yield return null;

        var pinConstraints = rope.GetConstraintsByType(Oni.ConstraintType.Pin) as ObiConstraints<ObiPinConstraintsBatch>;
        pinConstraints.Clear();

        Vector3 localHit = rope.transform.InverseTransformPoint(hookAttachment.point);

        int filter = ObiUtils.MakeFilter(ObiUtils.CollideWithEverything, 0);
        blueprint.path.Clear();
        blueprint.path.AddControlPoint(Vector3.zero, Vector3.zero, Vector3.zero, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "Hook start");
        blueprint.path.AddControlPoint(localHit.normalized * 0.5f, Vector3.zero, Vector3.zero, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "Hook end");
        blueprint.path.FlushEvents();

        yield return blueprint.Generate();
        
        rope.ropeBlueprint = blueprint;

        yield return null;

        rope.GetComponent<MeshRenderer>().enabled = true;

        for (int i = 0; i < rope.activeParticleCount; ++i)
            solver.invMasses[rope.solverIndices[i]] = 0;

        float currentLength = 0;

        while (true)
        {
            Vector3 origin = solver.transform.InverseTransformPoint(rope.transform.position);

            Vector3 direction = hookAttachment.point - origin;
            float distance = direction.magnitude;
            direction.Normalize();

            currentLength += hookShootSpeed * Time.deltaTime;

            if (currentLength >= distance)
            {
                cursor.ChangeLength(distance);
                break;
            }

            cursor.ChangeLength(Mathf.Min(distance, currentLength));

            float length = 0;
            for (int i = 0; i < rope.elements.Count; ++i)
            {
                solver.positions[rope.elements[i].particle1] = origin + direction * length;
                solver.positions[rope.elements[i].particle2] = origin + direction * (length + rope.elements[i].restLength);
                length += rope.elements[i].restLength;
            }

            yield return null;
        }

        for (int i = 0; i < rope.activeParticleCount; ++i)
            solver.invMasses[rope.solverIndices[i]] = 10; // 1/0.1 = 10

        var batch = new ObiPinConstraintsBatch();
        batch.AddConstraint(rope.elements[0].particle1, character, transform.localPosition, Quaternion.identity, 0, 0, float.PositiveInfinity);
        batch.AddConstraint(rope.elements[rope.elements.Count-1].particle2, hookAttachment.collider.GetComponent<ObiColliderBase>(),
                                                          hookAttachment.collider.transform.InverseTransformPoint(hookAttachment.point), Quaternion.identity, 0, 0, float.PositiveInfinity);
        batch.activeConstraintCount = 2;
        pinConstraints.AddBatch(batch);

        rope.SetConstraintsDirty(Oni.ConstraintType.Pin);
    }

    private void DetachHook()
    {
        rope.ropeBlueprint = null;
        rope.GetComponent<MeshRenderer>().enabled = false;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && gameController.inGame)
        {
            if (!rope.isLoaded)
            {
                LaunchHook();
                //ropeThrow.Play();
            }

            else
                DetachHook();
        }

        if (gameController.isGameOver && rope.isLoaded)
        {
            gameObject.SetActive(false);
        }
        else if (gameController.isGameClear && rope.isLoaded)
        {
            gameObject.SetActive(false);
        }
    }
}
