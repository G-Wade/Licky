public abstract class Command
{
    
    protected IEntity pEntity;
    protected float pTime;

    public Command(IEntity entity, float time) {
        pEntity = entity;
        pTime = time;
    }

    public abstract void Execute();

    public abstract void Undo();

    public float getTime() {
        return pTime;
    }
}
