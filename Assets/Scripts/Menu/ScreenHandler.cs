using StarterAssets;
using UnityEngine;

public class ScreenHandler : StateHandler
{
    [SerializeField] private string handlerName;
    [SerializeField] private CanvasGroup canvasGroup;
    private GameObject deathScreen;
    
    public override string Name => handlerName;
    private GameObject player;
    public MenuStateMachine stateMachine;
    
    public override void OnEnter<T>(T transition)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        if (stateMachine.CurrentState == stateMachine.PlayerDeadHandler || stateMachine.CurrentState == stateMachine.PlayerWinHandler || stateMachine.CurrentState == stateMachine.MainMenuHandler)
        {
            Time.timeScale = 0;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        }
        else if (stateMachine.CurrentState == stateMachine.StartGameHandler)
        {
            Time.timeScale = 1;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        }
    }

    public override void OnExit<T>(T transition)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        OnEnter(MenuTransitions.MainMenuSelected);
        OnExit(MenuTransitions.PlayerDead);
        OnExit(MenuTransitions.PlayerWin);
    }

    public void PlayerDeath() {
        stateMachine.Trigger(MenuTransitions.PlayerDead);
        OnEnter(MenuTransitions.PlayerDead);
    }

    public void PlayerWin()
    {
        stateMachine.Trigger(MenuTransitions.PlayerWin);
        OnEnter(MenuTransitions.PlayerWin);
        deathScreen.SetActive(false);
    }
}