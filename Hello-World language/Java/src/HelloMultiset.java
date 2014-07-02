import com.google.common.collect.HashMultiset;
import com.google.common.collect.Multiset;

import java.util.Iterator;

public class HelloMultiset {
    public static void main(String[] args) {
        Multiset<String> set = HashMultiset.create();
        set.add("Hello");
        set.add("Hello");
        set.add("World");

        System.out.println("Multiset count:" + set.count("Hello"));
        System.out.println("Multiset size:" + set.size());

        Iterator items = set.iterator();
        System.out.println("Multiset items:");
        while(items.hasNext()) {
            System.out.println(items.next());
        }
    }
}
