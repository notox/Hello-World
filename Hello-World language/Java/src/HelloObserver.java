import com.google.common.eventbus.EventBus;

import java.util.Observable;

public class HelloObserver {
    public static void main(String[] args) {
        OldObserver oldObserver = new OldObserver();

//        Observable observable = new Observable();
//        observable.addObserver(oldObserver);
//
//        observable.notifyObservers();

        OldObservable oldObservable = new OldObservable();
        oldObservable.addObserver(oldObserver);
        oldObservable.setDate();

        NewObserver newObserver = new NewObserver();
        IntegerObserver integerObserver = new IntegerObserver();

        EventBus eventBus = new EventBus();
        eventBus.register(newObserver);
        eventBus.register(integerObserver);

        eventBus.post("Hello, the message is from EventBus post");
        eventBus.post(1);
    }


}


