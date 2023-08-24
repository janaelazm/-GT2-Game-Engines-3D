using UnityEngine;

    public class MenuStateMachine : StateMachine<MenuTransitions> 
    {

    [field: SerializeField] public StateHandler MainMenuHandler { get; private set; }
    [field: SerializeField] public StateHandler StartGameHandler { get; private set; }  
    [field: SerializeField] public StateHandler PlayerDeadHandler { get; private set; }
    [field: SerializeField] public StateHandler PlayerWinHandler { get; private set; }

    private void Awake() 
    {

        // Main Menu -> Start Game
        AddTransition(MainMenuHandler, StartGameHandler, MenuTransitions.StartGame);

        // Game -> Death
        AddTransition(StartGameHandler, PlayerDeadHandler, MenuTransitions.PlayerDead);
        
        // Death -> Main Menu
        AddTransition(PlayerDeadHandler, MainMenuHandler, MenuTransitions.MainMenuSelected);
        
        // Game -> Win
        AddTransition(StartGameHandler, PlayerWinHandler, MenuTransitions.PlayerWin);

        // Win -> Main Menu
        AddTransition(PlayerWinHandler, MainMenuHandler, MenuTransitions.MainMenuSelected);

    }
}