import com.google.common.eventbus.Subscribe;

public class IntegerObserver {
    @Subscribe
    public void onNumber(Integer number) {
        System.out.println("I am a new observer. The message is an integer: " + number);
    }
}
