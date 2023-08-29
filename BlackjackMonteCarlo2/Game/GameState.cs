namespace BlackjackMonteCarlo2.Game
{
    public class GameState : GameSave
    {
        #region Setting properties
        public Common.Player CurrentPlayer { get; set; }
        public Common.PlayerHand HandInPlay { get; set; }
        #endregion
    }
}
