import java.util.Observable;
import java.util.Observer;

public class OldObserver implements Observer {

    @Override
    public void update(Observable o, Object arg) {
        System.out.println("I am an old observer. I have notified that something happened.");
    }
}
