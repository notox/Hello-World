import com.google.common.eventbus.Subscribe;

public class NewObserver {
    @Subscribe
    public void onMessage(String message) {
        System.out.println("I am a new observer. The message is: " + message);
    }

    @Subscribe
    public void onNumber(Integer number) {
        System.out.println("I am a new observer. The message is an integer: " + number);
    }
}
