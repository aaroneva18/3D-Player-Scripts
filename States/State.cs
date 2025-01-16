public interface IState 
{
    public void Enter();
    public void Execute();
    public void FixedExecute();
    public void Exit();
}
