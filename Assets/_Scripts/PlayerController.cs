
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;


public class PlayerController : MonoBehaviour
{

   //Referência usada para a câmera filha do jogador
    GameObject playerCamera;    
   Camera cam;
   //Utilizada para poder travar a rotação no angulo que quisermos.
   float cameraRotation;

   float runningVel = 10f;
   float _baseSpeed = 6.0f;
   float _gravidade = 4.0f; 
   float maxSpeed = 1f;
   private GameObject tip;
   
   GameObject moveableOject;
   
   float y = 0;
   float x = 0;

   public float horizontalJump = 12f;


   private float jump = 1.4f;

   CharacterController characterController;

   public LayerMask isWall;


   private bool isWallRight, isWallLeft, isFirstTime, isMoving;

   private GameManager gm;


   public Vector3 startPosition;

    float startingFOV;
   
   private float currentFOV;

   public float zoomRate;
   public float minFOV;
   public float maxFOV;
   
   void Start()
   {


        gm = GameManager.GetInstance();
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        isWallRight = false;
        isWallLeft = false;
        isMoving = false;
        transform.position = startPosition;


        if (gm.currentLevel == GameManager.Level.Level1)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level1"));        
        else if (gm.currentLevel == GameManager.Level.Level2)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level2"));        
        else if (gm.currentLevel == GameManager.Level.Level3)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level3"));   
   }


   void Running()
   {
        x  /= 1.5f;
        x += Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.LeftShift)){
        
            _baseSpeed = runningVel;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
            _baseSpeed = 6f;

        
        if (Math.Abs(x) > maxSpeed)
            x = (x > 0) ? (maxSpeed) : (-maxSpeed) ; 
        
        float z = Input.GetAxis("Vertical");

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        //Tratando a rotação da câmera
        cameraRotation -= mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        //Verificando se é preciso aplicar a gravidade

        if(characterController.isGrounded){ 
            y = -_gravidade * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
                y = jump;
                isFirstTime = true;
            }
        else if (isWallLeft || isWallRight){
            if (!isFirstTime)
                y -= _gravidade/50 * Time.deltaTime;
            else{
                isFirstTime = false;
                y = 0;} 
            if (Input.GetKeyDown(KeyCode.Space)){
                y += jump * _baseSpeed/10;

                if (isWallLeft)
                    x += horizontalJump;
                else 
                    x -= horizontalJump;
            }
        }

            else {
                isFirstTime = true;
                y -= _gravidade * Time.deltaTime;}
        

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;

        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);

        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
   }


   void Update()
    {
        
        if (gm.gameState != GameManager.GameState.GAME){
            Cursor.lockState = CursorLockMode.None;    
            return;
        }
        else {
            
            Cursor.lockState = CursorLockMode.Locked;    

        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            gm.ChangeState(GameManager.GameState.PAUSE);
            Cursor.lockState = CursorLockMode.None;}    


        if (Input.GetKeyDown(KeyCode.Q))
            tip.gameObject.SetActive(false);

        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 5)){ 
                if (hit.collider.tag == "Moveable"){ 
                    isMoving = true;
                    moveableOject = hit.collider.gameObject;}
                
                }
        }
        if (Input.GetMouseButtonUp(0)){
            isMoving = false;
        }
        if (isMoving){
            moveableOject.transform.position = new Vector3(transform.position.x, moveableOject.transform.position.y, transform.position.z +6.0f);
        }
    
        isWallRight = Physics.Raycast(transform.position, transform.right, 1.2f, isWall);
        isWallLeft = Physics.Raycast(transform.position, -transform.right, 1.2f, isWall);
        Running();
    }

   void LateUpdate()

   {
       if (transform.position.y < -100.0f)
            Die();
        RaycastHit hit;
        Debug.DrawRay(playerCamera.transform.position, transform.forward*10.0f, Color.magenta);
        if(Physics.Raycast(playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 5))
            Debug.Log(hit.collider.name); 
        }
    void Die()
    {
        transform.position = startPosition;

    } 
    void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.collider.tag == "Coin"){
            Destroy(hit.collider.gameObject);
            gm.coins++; 
        }
    }


} 