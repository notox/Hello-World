import java.util.ArrayList;
import java.util.List;


public class HelloList {
    public static void main(String[] args) {
        List<String> names = new ArrayList<String>();
        names.add("Jay");

        System.out.println("Old List Content: " + names.get(0));

        // Java7
        // List<String> names7 = new ArrayList<>();
        // names.add("Jay");

        // List<String> namesByNewArrayList = newArrayList("Jay");
        // List<String> namesByOf = of("Jay");
    }

}
