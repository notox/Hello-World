import com.google.common.base.CharMatcher;
import com.google.common.base.Splitter;
import com.google.common.collect.HashMultiset;
import com.google.common.collect.Multiset;
import com.google.common.io.Files;

import java.io.File;
import java.io.IOException;
import java.nio.charset.Charset;

public class HelloWorld {
    public static void main(String[] args) {
        System.out.println("Hello World, Java!");
    }

    private static void count(String fileName) {
        try {

            String content = Files.toString(new File(fileName), Charset.defaultCharset());
            Iterable texts = Splitter.on(CharMatcher.WHITESPACE)
                    .omitEmptyStrings()
                    .trimResults()
                    .split(content);
            Multiset collection = HashMultiset.create(texts);
        }
        catch (IOException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
