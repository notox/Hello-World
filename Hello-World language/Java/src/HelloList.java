import com.google.common.base.Function;
import com.google.common.base.Predicate;
import com.google.common.collect.FluentIterable;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class HelloList {
    public static void main(String[] args) {
        List<String> names = Arrays.asList("Jay");

        System.out.println("Old List Content: " + names.get(0));

        // Java7
        List<String> names7 = new ArrayList<>();
        names7.add("Jay");

        // List<String> namesByNewArrayList = newArrayList("Jay");
        // List<String> namesByOf = of("Jay");
        List<Person> persons = Arrays.asList(
                                            new Person("Jay", 13),
                                            new Person("Adam", 27),
                                            new Person("Andy", 80));

        transformListByOldStyle(persons);
        transformListByFunctionStyle(persons);
    }

    public static void transformListByOldStyle(List<Person> persons) {
        List<String> names = new ArrayList<>();
        for(Person person : persons) {
            int age = person.getAge();
            if (age >= 14 && age <= 28) {
                names.add(person.getName());
            }
        }

        for(String name : names) {
            System.out.println("Young Man: " + name);
        }
    }

    public static void transformListByFunctionStyle(List<Person> persons) {
        FluentIterable<String> names = FluentIterable.from(persons)
                                            .filter(isAgeQualified()).transform(toNames());
        for(String name : names) {
            System.out.println("Young Man: " + name);
        }
    }

    private static Predicate<Person> isAgeQualified() {
        return new Predicate<Person>() {
            @Override
            public boolean apply(Person person) {
                int age = person.getAge();
                return age >= 14 && age <= 28;
            }
        };
    }

    private static Function<Person, String> toNames() {
        return new Function<Person, String>() {
            @Override
            public String apply(Person person) {
                return person.getName();
            }
        };
    }

}
