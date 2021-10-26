public class KeyEvent : FoddianEvent
{
    public enum KeyType
    {
        FIRST, SECOND
    }
    public KeyType type;
    public override void StartEvent(params System.Type[] parameters)
    {
        switch (type) {
            case KeyType.FIRST: KeyLockManager.Instance.firstKeyCollected = true; break;
            case KeyType.SECOND: KeyLockManager.Instance.secondKeyCollected = true; break;
        }
        Destroy(gameObject);
    }
}
