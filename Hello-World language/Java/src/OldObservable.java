import java.util.Observable;

public class OldObservable extends Observable{
    public void setDate() {
        setChanged();
        notifyObservers();
    }

}
